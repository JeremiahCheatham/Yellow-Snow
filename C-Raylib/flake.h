#ifndef FLAKE_H
#define FLAKE_H

#include "main.h"
#include "flake.h"

// Struct for node of linked list.
struct Flake {
    struct Flake *next;
    Texture2D *image;
    float x;
    float y;
    unsigned int speed;
    bool is_white;
};

bool flake_new(struct Flake **first_flake, Texture2D *image, bool is_white);
void flake_update(struct Flake *this, float delta_time);
void flake_draw(struct Flake *this);
void flake_reset(struct Flake *this, bool full);
Rectangle flake_rect(struct Flake *this);

#endif // FLAKE_H