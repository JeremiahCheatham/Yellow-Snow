import pygame
from random import randint

class Flake(pygame.sprite.Sprite):
    def __init__(self, screen, surface, color, win_width, win_height):
        pygame.sprite.Sprite.__init__(self)
        self.image = surface
        self.rect = self.image.get_rect()
        self.speed = 300
        self.color = color
        self.win_width = win_width
        self.win_height = win_height
        self.reset(False)
        self.screen = screen
    
    def update(self, dt):
        self.rect.y += self.speed * dt
    
    def draw(self):
        self.screen.blit(self.image, self.rect)

    def reset(self, playing):
        self.rect.left = randint(0, self.win_width - self.rect.width)
        if playing:
            self.rect.bottom = randint(-self.win_height, 0)
        else:
            self.rect.bottom = randint(-self.win_height * 2, 0)