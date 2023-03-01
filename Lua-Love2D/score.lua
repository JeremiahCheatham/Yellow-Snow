Score = {
    _x = 10,
    _y = 10,
    _score = 0
}

function Score:new(font, size)
    local newScore = {}
    newScore._font = love.graphics.newFont(font, size)
    love.graphics.setFont(newScore._font)
    setmetatable(newScore, { __index = self })
    return newScore
end


function Score:draw()
    love.graphics.print("Score: " .. math.floor(self._score), self._x, self._y)
end


function Score:increment()
    self._score = self._score + 1
end


function Score:reset()
    self._score = 0
end