Flake = {
    speed = 300
}

function Flake:load(white, yellow)
    self.__index = self
    self.white = love.graphics.newImage(white)
    self.yellow = love.graphics.newImage(yellow)
    self.width, self.height = self.white:getDimensions()
end

function Flake:new(color)
    local newFlake = {}
    setmetatable(newFlake, self)
    if color == "white" then
        newFlake.image = self.white
        newFlake.color = "white"
    else
        newFlake.image = self.yellow
        newFlake.color = "yellow"
    end
    return newFlake
end

function Flake:reset()
    if Playing then
        self.y = -self.height - math.random(0, love.graphics.getHeight())
    else
        self.y = -self.height - math.random(0, love.graphics.getHeight() * 2 )
    end
    self.x = math.random(0, (love.graphics.getWidth() - self.width))
    self.left = self.x
    self.right = self.x + self.width
    self.top = self.y
    self.bottom = self.y + self.height
end

function Flake:update(dt)
    self.y = self.y + self.speed * dt
    self.top = self.y
    self.bottom = self.y + self.height
end

function Flake:draw()
    love.graphics.draw(self.image, self.x, self.y)
end