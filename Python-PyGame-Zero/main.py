#!/usr/bin/env python

import pgzrun
from player import Player
from flake import Flake


# Game Constants.
WIDTH = 800
HEIGHT = 600
GROUND = 550
TITLE = "Don't Eat The Yellow Snow!"
ICON = "images/yellow.png"
MUSIC = "winter_loop"


# Game Variables.
score = 0
playing = True


player = Player("player", WIDTH)
flakes = []
for flake in range(0, 10):
    flake = Flake("white", WIDTH, HEIGHT)
    flakes.append(flake)
for flake in range(0, 5):
    flake = Flake("yellow", WIDTH, HEIGHT)
    flakes.append(flake)
music.play(MUSIC)


def update(dt):
    if playing:
        player.update(dt)
        for flake in flakes:
            flake.update(dt)
            check_collision(flake, player)


def draw():
    screen.blit("background", (0, 0))
    player.draw()
    for flake in flakes:
        flake.draw()
    screen.draw.text("Score: " + str(score), topleft=(10, 10), color="white", fontname="freesansbold", fontsize=24)


def on_key_down(key):
    global playing, score
    if key == keys.SPACE and not playing:
        for flake in flakes:
            flake.reset(playing)
        score = 0
        playing = True
        music.play(MUSIC)
    if key == keys.ESCAPE:
        exit()


def check_collision(flake, player):
    global playing, score
    if flake.bottom > GROUND:
        flake.reset(playing)
    elif flake.bottom > player.top_side and flake.right > player.left_side and flake.left < player.right_side:
        if flake.color == "white":
            sounds.collect.play()
            flake.reset(playing)
            score += 1
        else:
            music.stop()
            sounds.hit.play()
            playing = False


pgzrun.go()
