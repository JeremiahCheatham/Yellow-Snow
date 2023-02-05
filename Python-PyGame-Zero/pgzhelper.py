import math
import pygame
from pgzero.actor import Actor, POS_TOPLEFT, ANCHOR_CENTER, transform_anchor
from pgzero import game, loaders
import types
import sys
import time

mod = sys.modules['__main__']
_fullscreen = False

def set_fullscreen():
  global _fullscreen
  mod.screen.surface = pygame.display.set_mode((mod.WIDTH, mod.HEIGHT), pygame.FULLSCREEN)
  _fullscreen = True

def set_windowed():
  global _fullscreen
  mod.screen.surface = pygame.display.set_mode((mod.WIDTH, mod.HEIGHT))
  _fullscreen = False

def toggle_fullscreen():
  if _fullscreen:
    set_windowed()
  else:
    set_fullscreen()

def hide_mouse():
   pygame.mouse.set_visible(False)

def show_mouse():
   pygame.mouse.set_visible(True)

class Actor(Actor):
  def __init__(self, image, pos=POS_TOPLEFT, anchor=ANCHOR_CENTER, **kwargs):
    self._flip_x = False
    self._flip_y = False
    self._scale = 1
    self._mask = None
    self._animate_counter = 0
    self.fps = 5
    self.direction = 0
    super().__init__(image, pos, anchor, **kwargs)

  def distance_to(self, actor):
    dx = actor.x - self.x
    dy = actor.y - self.y
    return math.sqrt(dx**2 + dy**2)

  def direction_to(self, actor):
    dx = actor.x - self.x
    dy = self.y - actor.y

    angle = math.degrees(math.atan2(dy, dx))
    if angle > 0:
      return angle

    return 360 + angle

  def move_towards(self, actor, dist):
    angle = math.radians(self.direction_to(actor))
    dx = dist * math.cos(angle)
    dy = dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  def point_towards(self, actor):
    print(self.direction_to(actor))
    self.angle = self.direction_to(actor)

  def move_in_direction(self, dist):
    angle = math.radians(self.direction)
    dx = dist * math.cos(angle)
    dy = dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  def move_forward(self, dist):
    angle = math.radians(self.angle)
    dx = dist * math.cos(angle)
    dy = dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  def move_left(self, dist):
    angle = math.radians(self.angle + 90)
    dx = dist * math.cos(angle)
    dy = dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  def move_right(self, dist):
    angle = math.radians(self.angle - 90)
    dx = dist * math.cos(angle)
    dy = dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  def move_back(self, dist):
    angle = math.radians(self.angle)
    dx = -dist * math.cos(angle)
    dy = -dist * math.sin(angle)
    self.x += dx
    self.y -= dy

  @property
  def images(self):
    return self._images

  @images.setter
  def images(self, images):
    self._images = images
    if len(self._images) != 0:
      self.image = self._images[0]

  def next_image(self):
    if self.image in self._images:
      current = self._images.index(self.image)
      if current == len(self._images) - 1:
        self.image = self._images[0]
      else:
        self.image = self._images[current + 1]
    else:
      self.image = self._images[0]

  def animate(self):
    now = int(time.time() * self.fps)
    if now != self._animate_counter:
      self._animate_counter = now
      self.next_image()

  @property
  def angle(self):
    return self._angle

  @angle.setter
  def angle(self, angle):
    self._angle = angle
    self._transform_surf()

  @property
  def scale(self):
    return self._scale

  @scale.setter
  def scale(self, scale):
    self._scale = scale
    self._transform_surf()

  @property
  def flip_x(self):
    return self._flip_x

  @flip_x.setter
  def flip_x(self, flip_x):
    self._flip_x = flip_x
    self._transform_surf()

  @property
  def flip_y(self):
    return self._flip_y

  @flip_y.setter
  def flip_y(self, flip_y):
    self._flip_y = flip_y
    self._transform_surf()

  @property
  def image(self):
    return self._image_name

  @image.setter
  def image(self, image):
    self._image_name = image
    self._orig_surf = self._surf = loaders.images.load(image)
    self._update_pos()
    self._transform_surf()

  def _transform_surf(self):
    self._surf = self._orig_surf
    p = self.pos

    if self._scale != 1:
      size = self._orig_surf.get_size()
      self._surf = pygame.transform.scale(self._surf, (int(size[0] * self.scale), int(size[1] * self.scale)))
    if self._flip_x:
      self._surf = pygame.transform.flip(self._surf, True, False)
    if self._flip_y:
      self._surf = pygame.transform.flip(self._surf, False, True)

    self._surf = pygame.transform.rotate(self._surf, self._angle)

    self.width, self.height = self._surf.get_size()
    w, h = self._orig_surf.get_size()
    ax, ay = self._untransformed_anchor
    anchor = transform_anchor(ax, ay, w, h, self._angle)
    self._anchor = (anchor[0] * self.scale, anchor[1] * self.scale)

    self.pos = p
    self._mask = None

  def collidepoint_pixel(self, x, y=0):
    if isinstance(x, tuple):
      y = x[1]
      x = x[0]
    if self._mask == None:
      self._mask = pygame.mask.from_surface(self._surf)

    xoffset = int(x - self.left)
    yoffset = int(y - self.top)
    if xoffset < 0 or yoffset < 0:
      return 0

    width, height = self._mask.get_size()
    if xoffset > width or yoffset > height:
      return 0

    return self._mask.get_at((xoffset, yoffset))

  def collide_pixel(self, actor):
    for a in [self, actor]:
      if a._mask == None:
        a._mask = pygame.mask.from_surface(a._surf)

    xoffset = int(actor.left - self.left)
    yoffset = int(actor.top - self.top)

    return self._mask.overlap(actor._mask, (xoffset, yoffset))

  def collidelist_pixel(self, actors):
    for i in range(len(actors)):
      if self.collide_pixel(actors[i]):
        return i
    return -1

  def collidelistall_pixel(self, actors):
    collided = []
    for i in range(len(actors)):
      if self.collide_pixel(actors[i]):
        collided.append(i)
    return collided

  def obb_collidepoints(self, actors):
    angle = math.radians(self._angle)
    costheta = math.cos(angle)
    sintheta = math.sin(angle)
    width, height = self._orig_surf.get_size()
    half_width = width / 2
    half_height = height / 2

    i = 0
    for actor in actors:
      tx = actor.x - self.x
      ty = actor.y - self.y
      rx = tx * costheta - ty * sintheta
      ry = ty * costheta + tx * sintheta

      if rx > -half_width and rx < half_width and ry > -half_height and ry < half_height:
        return i
      i += 1

    return -1

  def obb_collidepoint(self, x, y=0):
    if isinstance(x, tuple):
      y = x[1]
      x = x[0]
    angle = math.radians(self._angle)
    costheta = math.cos(angle)
    sintheta = math.sin(angle)
    width, height = self._orig_surf.get_size()
    half_width = width / 2
    half_height = height / 2

    tx = x - self.x
    ty = y - self.y
    rx = tx * costheta - ty * sintheta
    ry = ty * costheta + tx * sintheta

    if rx > -half_width and rx < half_width and ry > -half_height and ry < half_height:
      return True

    return False

  def circle_collidepoints(self, radius, actors):
    rSquare = radius ** 2

    i = 0
    for actor in actors:
      dSquare = (actor.x - self.x)**2 + (actor.y - self.y)**2

      if dSquare < rSquare:
        return i
      i += 1

    return -1

  def circle_collidepoint(self, radius, x, y=0):
    if isinstance(x, tuple):
      y = x[1]
      x = x[0]
    rSquare = radius ** 2
    dSquare = (x - self.x)**2 + (y - self.y)**2

    if dSquare < rSquare:
      return True

    return False
      

  def draw(self):
    game.screen.blit(self._surf, self.topleft)

  def get_rect(self):
    return self._rect
