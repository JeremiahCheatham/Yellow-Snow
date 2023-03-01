Flake = {
    _speed = 300
}

function Flake:new(image, color)
    local newFlake = {}
    newFlake._image = image
    newFlake._color = color
    newFlake._width, newFlake._height = image:getDimensions()
    setmetatable(newFlake, { __index = self })
    return newFlake
end

function Flake:reset(full)
    if Playing then
        self._y = -self._height - math.random(0, love.graphics.getHeight())
    else
        self._y = -self._height - math.random(0, love.graphics.getHeight() * 2 )
    end
    self._x = math.random(0, (love.graphics.getWidth() - self._width))
end

function Flake:update(dt)
    self._y = self._y + self._speed * dt
end

function Flake:left()
    return self._x
end

function Flake:right()
    return self._x + self._width
end

function Flake:bottom()
    return self._y + self._height
end

function Flake:color()
    return self._color
end

function Flake:draw()
    love.graphics.draw(self._image, self._x, self._y)
end