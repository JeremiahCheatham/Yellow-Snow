#ifndef GAME_H
#define GAME_H

#include "main.h"
#include "player.h"
#include "flake.h"
#include "score.h"

struct Game {
    SDL_Event event;
    SDL_Renderer *renderer;
    SDL_Texture *background_image;
    SDL_Texture *player_image;
    SDL_Texture *white_image;
    SDL_Texture *yellow_image;
    Mix_Music *music;
    Mix_Chunk *collect;
    Mix_Chunk *hit;
    TTF_Font *font;
    float frame_delay;
    bool show_fps;
    int ground;
    float delta_time;
    bool playing;
    struct Player *player;
    struct Flake *flakes;
    struct Score *score;
};

struct Game* game_new(SDL_Renderer *renderer);
bool game_run(struct Game *this);
void game_free(struct Game *this);

#endif // GAME_H