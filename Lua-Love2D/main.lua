require("player")
require("flake")

function love.load()
    -- Game variables.
    Score = 0
    Playing = false

    -- Seed random numbers.
    math.randomseed(os.time())

    -- Load Game Graphics.
    Background = love.graphics.newImage("images/background.png")
    Player:load("images/player.png")
    Flake:load("images/white.png", "images/yellow.png")

    -- Generate list of flakes.
    Flakes = {}
    for _ = 1, 10 do
        local flake = Flake:new("white")
        flake:reset()
        table.insert(Flakes, flake)
    end
    for _ = 1, 5 do
        local flake = Flake:new("yellow")
        flake:reset()
        table.insert(Flakes, flake)
    end

    Playing = true

    -- Game Font Sizes.
    ScoreFont = love.graphics.newFont("fonts/freesansbold.ttf", 24)
    love.graphics.setFont(ScoreFont)

    -- Load Game Sounds.
    Collect = love.audio.newSource("sounds/collect.wav", "static")
    Hit = love.audio.newSource("sounds/hit.wav", "static")
    Music = love.audio.newSource("music/winter_loop.mp3", "stream")

    -- Play background music on repeat.
    Music:setLooping(true)
    Music:play()
end

function love.update(dt)
    if Playing then
        Player:update(dt)
        for _, flake in pairs(Flakes) do
            flake:update(dt)
            CheckCollision(flake, Player)
        end
    end
end

function love.draw()
    love.graphics.draw(Background)
    Player:draw()
    for _, flake in pairs(Flakes) do
        flake:draw()
    end
    love.graphics.print("Score: " .. math.floor(Score), 10, 10)
end

function love.keypressed(k)
    if k == "escape" then
       love.event.quit()
    elseif k == "space" and not Playing then
        Score = 0
        for _, flake in pairs(Flakes) do
            flake:reset()
        end
        Playing = true
        Music:play()
    end
 end

function CheckCollision(flake, player)
    if flake.bottom > 550 then
        flake:reset()
    elseif flake.bottom > player.top and flake.right > player.left and flake.left < player.right then
        if flake.color == "white" then
            Collect:clone():play()
            flake:reset()
            Score = Score + 1
        else
            Music:stop()
            Hit:play()
            Playing = false
        end
    end
end