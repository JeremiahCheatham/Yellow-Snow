from pgzhelper import *
from pgzero.builtins import keyboard

class Player(Actor):
    def __init__(self, player, win_width):
        super().__init__(player)
        self.win_width = win_width
        self.pos = self.win_width / 2, 458
        self.speed = 300
        self.left_offset = 48
        self.right_offset = 44
        self.top_side = 390

    @property
    def left_side(self):
        return self.left + self.left_offset

    @left_side.setter
    def left_side(self, left_side):
        self.left = left_side - self.left_offset

    @property
    def right_side(self):
        return self.right - self.right_offset

    @right_side.setter
    def right_side(self, right_side):
        self.right = right_side + self.right_offset

    def update(self, dt):
        if keyboard.right:
            self.x += self.speed * dt
            if self.right_side >= self.win_width:
                self.right_side = self.win_width
            self.flip_x = False
        if keyboard.left:
            self.x -= self.speed * dt
            if self.left_side <= 0:
                self.left_side = 0
            self.flip_x = True