#ifndef PLAYER_H
#define PLAYER_H

#include "common.h"

struct Player{
    SDL_Renderer *rend;
    SDL_Texture *image;
    SDL_Rect rect;
    SDL_Rect hit_box;
    Uint32 speed;
    SDL_RendererFlip flip;
    const Uint8 *keystate;
};

enum Errors player_create(struct Player *player);
void player_update(struct Player *player, const float delta_time);
enum Errors player_draw(struct Player *player);

#endif