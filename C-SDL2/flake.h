
#ifndef FLAKES_H
#define FLAKES_H

#include "main.h"

struct Flake {
    struct Flake *next;
    SDL_Renderer *renderer;
    SDL_Texture *image;
    SDL_Rect rect;
    double y_pos;
    bool is_white;
    double speed;
};

bool flake_new(struct Flake **flakes, SDL_Renderer *renderer, SDL_Texture *image, bool is_white);
void flakes_free(struct Flake **flakes);
void flake_reset(struct Flake *f, bool full);
void flakes_reset(struct Flake *f, bool full);
int flake_left(struct Flake *f);
int flake_right(struct Flake *f);
int flake_bottom(struct Flake *f);
void flakes_update(struct Flake *f, double dt);
bool flakes_draw(struct Flake *f);

#endif