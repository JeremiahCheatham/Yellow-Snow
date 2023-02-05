from pgzero.builtins import Actor
from random import randint

class Flake(Actor):
    def __init__(self, color, win_width, win_height):
        super().__init__(color)
        self.speed = 300
        self.color = color
        self.win_width = win_width
        self.win_height = win_height
        self.reset(False)
    
    def update(self, dt):
        self.y += self.speed * dt

    def reset(self, playing):
        self.left = randint(0, self.win_width - self.width)
        if playing:
            self.bottom = randint(-self.win_height, 0)
        else:
            self.bottom = randint(-self.win_height * 2, 0)