#ifndef PLAYER_H
#define PLAYER_H

#include "main.h"

struct Player{
    SDL_Renderer *renderer;
    SDL_Texture *image;
    SDL_Rect rect;
    SDL_Rect hit_box;
    SDL_RendererFlip flip;
    const Uint8 *keystate;
    float x;
    unsigned int speed;
    int top_offset;
    int left_offset;
    int right_offset;
    bool error;

};

struct Player* player_new(SDL_Renderer *renderer, SDL_Texture *image);
void player_update(struct Player *this, float delta_time);
bool player_draw(struct Player *this);

#endif // PLAYER_H