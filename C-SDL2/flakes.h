
#ifndef FLAKES_H
#define FLAKES_H

#include "common.h"

// Struct for the linked list.
struct Flakes {
    struct Flake *first_flake;
};

// Struct for node of linked list.
struct Flake {
    struct Flake *previous;
    struct Flake *next;
    SDL_Renderer *rend;
    SDL_Texture *image;
    SDL_Rect rect;
    bool is_white;
    Uint32 speed;
};

enum Errors flakes_create(struct Flakes *flakes, SDL_Texture *image, bool is_white, Uint8 num, SDL_Renderer *rend);
enum Errors flake_create(struct Flakes *flakes, SDL_Texture *image, SDL_Rect rect, bool is_white, SDL_Renderer *rend);
void flakes_update(struct Flakes *flakes, const float delta_time);
enum Errors flakes_draw(struct Flakes *flakes);
bool flake_check_collide(SDL_Rect *flake, SDL_Rect *player);
void flake_reset(SDL_Rect *flake, bool full_reset);

#endif