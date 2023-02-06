#!/usr/bin/env python

import pygame
from player import Player
from flake import Flake

pygame.init()

WIDTH = 800
HEIGHT = 600
GROUND = 550
TITLE = "Don't Eat The Yellow Snow!"
ICON = "images/yellow.png"
FPS = 60
score = 0
running = True
playing = True
prev_time = pygame.time.get_ticks()

screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption(TITLE)
pygame.display.set_icon(pygame.image.load(ICON).convert_alpha())

background = pygame.image.load("images/background.png").convert()
player_surf = pygame.image.load("images/player.png").convert_alpha()
white_surf = pygame.image.load("images/white.png").convert_alpha()
yellow_surf = pygame.image.load("images/yellow.png").convert_alpha()

collect = pygame.mixer.Sound("sounds/collect.wav")
hit = pygame.mixer.Sound("sounds/hit.wav")
music = pygame.mixer.music.load("music/winter_loop.ogg")
pygame.mixer.music.play(-1)

font = pygame.font.Font("fonts/freesansbold.ttf", 24)
def create_text(score):
    return font.render("Score: {}".format(score), True, (255, 255, 255))
score_surf = create_text(score)


player = Player(player_surf, WIDTH, screen)
flakes = []
for flake in range(0, 10):
    flake = Flake(screen, white_surf, "white", WIDTH, HEIGHT)
    flakes.append(flake)
for flake in range(0, 5):
    flake = Flake(screen, yellow_surf, "yellow", WIDTH, HEIGHT)
    flakes.append(flake)


def input():
    global running, score, score_surf, playing
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_ESCAPE:
                running = False
            elif event.key == pygame.K_SPACE and not playing:
                for flake in flakes:
                    flake.reset(playing)
                score = 0
                score_surf = create_text(score)
                pygame.mixer.music.play(-1)
                playing = True


def update(dt):
    if playing:
        player.update(dt)
        for flake in flakes:
            flake.update(dt)
            check_collision(flake, player)


def draw():
    screen.blit(background, (0, 0))
    player.draw()
    for flake in flakes:
        flake.draw()
    screen.blit(score_surf, (10, 10))
    pygame.display.flip()


def check_collision(flake, player):
    global playing, score, score_surf
    if flake.rect.bottom > GROUND:
        flake.reset(playing)
    elif flake.rect.bottom > player.top and flake.rect.right > player.left and flake.rect.left < player.right:
        if flake.color == "white":
            pygame.mixer.Sound.play(collect)
            flake.reset(playing)
            score += 1
            score_surf = create_text(score)
        else:
            pygame.mixer.music.stop()
            pygame.mixer.Sound.play(hit)
            playing = False


while running:
    input()

    curr_time = pygame.time.get_ticks()
    delta_time = (curr_time - prev_time) / 1000
    prev_time = curr_time

    update(delta_time)

    draw()
    
    pygame.time.Clock().tick(FPS)


pygame.quit()