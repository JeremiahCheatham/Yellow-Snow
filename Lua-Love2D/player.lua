Player = {
    _speed = 300,
    _y = 378,
    _isRight = true,
    _topOffset = 12,
    _leftOffset = 47,
    _rightOffset = 47
}


function Player:new(image)
    local newPlayer = {}
    newPlayer._image = image
    newPlayer._width, newPlayer._height = image:getDimensions()
    self._x = (love.graphics.getWidth() - newPlayer._width) / 2
    setmetatable(newPlayer, { __index = self })
    return newPlayer
end


function Player:update(dt)
    if love.keyboard.isDown("left") then
        self._isRight = false
        self._x = self._x - self._speed * dt
        if self:left() < 0 then
            self._x = -self._leftOffset
        end
    end
    if love.keyboard.isDown("right") then
        self._isRight = true
        self._x = self._x + self._speed * dt
        if self:right() > love.graphics.getWidth() then
            self._x = love.graphics.getWidth() + self._rightOffset - self._width
        end
    end
end


function Player:left()
    return self._x + self._leftOffset
end


function Player:right()
    return self._x + self._width - self._rightOffset
end


function Player:top()
    return self._y + self._topOffset
end


function Player:draw()
    if self._isRight then
        love.graphics.draw(self._image, self._x, self._y, 0, 1, 1)
    else
        love.graphics.draw(self._image, self._x + self._width, self._y, 0, -1, 1)
    end
end
