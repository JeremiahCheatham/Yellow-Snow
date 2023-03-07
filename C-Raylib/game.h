#ifndef GAME_H
#define GAME_H

#include "main.h"
#include "player.h"
#include "flake.h"
#include "score.h"

struct Game {
    Texture2D background_image;
    Texture2D player_image;
    Texture2D white_image;
    Texture2D yellow_image;
    Music music;
    Sound collect;
    Sound hit;
    Font font;
    int ground;
    float delta_time;
    bool playing;
    struct Player *player;
    struct Flake *flakes;
    struct Score *score;
};

struct Game* game_new();
bool game_run(struct Game *this);
void game_free(struct Game *this);

#endif // GAME_H