
#ifndef FLAKES_H
#define FLAKES_H

#include "main.h"

// Struct for node of linked list.
struct Flake {
    struct Flake *next;
    SDL_Renderer *renderer;
    SDL_Texture *image;
    SDL_Rect rect;
    float y;
    bool is_white;
    unsigned int speed;
    bool error;
};

struct Flake* flake_new(struct Flake **flakes, SDL_Renderer *renderer, SDL_Texture *image, bool is_white);
void flake_update(struct Flake *this, float delta_time);
bool flake_draw(struct Flake *this);
bool flake_check_collide(SDL_Rect *flake, SDL_Rect *player);
void flake_reset(struct Flake *this, bool full);

#endif