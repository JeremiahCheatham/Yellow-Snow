Player = {
    speed = 300,
    y = 378,
    top = 390,
    leftOffset = 48,
    rightOffset = 48
}

function Player:load(image)
    self.image = love.graphics.newImage(image)
    self.width, self.height = self.image:getDimensions()
    self.x = (love.graphics.getWidth() - self.width) / 2
    self.left = self.x + self.leftOffset
    self.right = self.x + self.width - self.rightOffset
end


function Player:new()
    setmetatable(newPlayer, self)
    self.__index = self
    return newPlayer
end


function Player:update(dt)
    if love.keyboard.isDown("left") then
        self.left = self.left - self.speed * dt
        if self.left < 0 then
            self.left = 0
        end
        self.x = self.left - self.leftOffset
        self.right = self.x + self.width - self.rightOffset
        self.isRight = false
    end
    if love.keyboard.isDown("right") then
        self.right = self.right + self.speed * dt
        if self.right > love.graphics.getWidth() then
            self.right = love.graphics.getWidth()
        end
        self.x = self.right - self.width + self.rightOffset
        self.left = self.x + self.leftOffset
        self.isRight = true
    end
end

function Player:draw()
    if self.isRight then
        love.graphics.draw(self.image, self.x, self.y, 0, 1, 1)
    else
        love.graphics.draw(self.image, self.x + self.width, self.y, 0, -1, 1)
    end
end
