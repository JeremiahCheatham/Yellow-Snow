#ifndef GAME_H
#define GAME_H

#include "main.h"
#include "player.h"
#include "flake.h"
#include "score.h"
#include "fps.h"

struct Game {
    SDL_Event event;
    SDL_Window *window;
    SDL_Renderer *renderer;
    SDL_Texture *background_image;
    SDL_Rect background_rect;
    SDL_Texture *player_image;
    SDL_Texture *white_image;
    SDL_Texture *yellow_image;
    Mix_Music *winter_music;
    Mix_Chunk *collect_sound;
    Mix_Chunk *hit_sound;
    struct Player *player;
    struct Flake *flakes;
    struct Score *score;
    struct Fps *fps;
    bool playing;
    double delta_time;
};

bool game_new(struct Game **game);
void game_free(struct Game **game);
bool game_reset(struct Game *g);
bool handle_collision(struct Game *g, struct Flake *f);
bool check_collision(struct Game *g);
bool game_run(struct Game *g);

#endif