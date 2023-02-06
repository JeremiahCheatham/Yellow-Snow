import pygame

class Player(pygame.sprite.Sprite):
    def __init__(self, surface, win_width, screen):
        pygame.sprite.Sprite.__init__(self)
        self.image = surface
        self.img_flip = pygame.transform.flip(self.image, True, False)
        self.rect = self.image.get_rect()
        self.win_width = win_width
        self.rect.center = self.win_width / 2, 458
        self.speed = 300
        self.left_offset = 48
        self.right_offset = 44
        self.top = 390
        self.is_right = True
        self.screen = screen

    @property
    def left(self):
        return self.rect.left + self.left_offset

    @left.setter
    def left(self, left):
        self.rect.left = left - self.left_offset

    @property
    def right(self):
        return self.rect.right - self.right_offset

    @right.setter
    def right(self, right):
        self.rect.right = right + self.right_offset

    def update(self, dt):
        keys = pygame.key.get_pressed()
        if keys[pygame.K_RIGHT]:
            self.rect.x += self.speed * dt
            if self.right >= self.win_width:
                self.right = self.win_width
            self.is_right = True
        if keys[pygame.K_LEFT]:
            self.rect.x -= self.speed * dt
            if self.left <= 0:
                self.left = 0
            self.is_right = False
        
    def draw(self):
        if self.is_right:
            self.screen.blit(self.image, self.rect)
        else:
            self.screen.blit(self.img_flip, self.rect)