Game = {
    playing = true,
    score = 0,
    _ground = 550
}

function Game:load()
    -- Seed random numbers.
    math.randomseed(os.time())

    -- Load Game Graphics.
    self.backgroundImage = love.graphics.newImage("images/background.png")
    self.playerImage = love.graphics.newImage("images/player.png")
    self.whiteImage = love.graphics.newImage("images/white.png")
    self.yellowImage = love.graphics.newImage("images/yellow.png")

    -- Load Game Sounds.
    self.collect = love.audio.newSource("sounds/collect.ogg", "static")
    self.hit = love.audio.newSource("sounds/hit.ogg", "static")
    self.music = love.audio.newSource("music/winter_loop.ogg", "stream")

    -- Load and set font.
    self.font = love.graphics.newFont("fonts/freesansbold.ttf", 24)
    love.graphics.setFont(self.font)

    -- Create Player objects.
    self.player = Player:new(self.playerImage)

    -- Generate list of flakes.
    self.flakes = {}
    for _ = 1, 10 do
        local flake = Flake:new(self.whiteImage, "white")
        flake:reset(true)
        table.insert(self.flakes, flake)
    end
    for _ = 1, 5 do
        local flake = Flake:new(self.yellowImage, "yellow")
        flake:reset(true)
        table.insert(self.flakes, flake)
    end

    -- Play background music on repeat.
    self.music:setLooping(true)
    self.music:play()
end

function Game:update(dt)
    if self.playing then
        self.player:update(dt)
        for _, flake in pairs(self.flakes) do
            flake:update(dt)
            self:checkCollision(flake)
        end
    end
end

function Game:draw()
    love.graphics.draw(self.backgroundImage)
    self.player:draw()
    for _, flake in pairs(self.flakes) do
        flake:draw()
    end
    love.graphics.print("Score: " .. math.floor(self.score), 10, 10)
end

function Game:playing()
    return self._playing
end

function Game:reset()
    self.score = 0
    for _, flake in pairs(self.flakes) do
        flake:reset()
    end
    self.playing = true
    self.music:play()
end

function Game:checkCollision(flake)
    if flake:bottom() > self._ground then
        flake:reset()
    elseif flake:bottom() > self.player:top() and flake:right() > self.player:left() and flake:left() < self.player:right() then
        if flake:color() == "white" then
            self.collect:clone():play()
            flake:reset(false)
            self.score = self.score + 1
        else
            self.music:stop()
            self.hit:play()
            self.playing = false
        end
    end
end