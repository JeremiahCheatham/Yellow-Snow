// Included header files.
#include "flake.h"

bool flake_new(struct Flake **flakes, Texture2D *image, bool is_white) {
    struct Flake *this = calloc(1, sizeof(struct Flake));
    if (!this) {
        fprintf(stderr, "Error in calloc of new_flake!\n");
        return false;
    }

    this->image = image;
    this->is_white = is_white;
    this->speed = 300;

    flake_reset(this, true);
    
    if (*flakes) {
        this->next = *flakes;
    } else {
        this->next = NULL;
    }

    *flakes = this;

    return true;
}

void flake_update(struct Flake *this, float delta_time) {
    this->y += delta_time * this->speed + 0.5;
}

void flake_draw(struct Flake *this) {
    DrawTexture(*(this->image), this->x, this->y, WHITE);
}

void flake_reset(struct Flake *this, bool full) {
    int height = full ? HEIGHT * 2 : HEIGHT;
    this->x = GetRandomValue(0, (WIDTH - this->image->width));
    this->y = -(GetRandomValue(0, height) + this->image->width);
}

Rectangle flake_rect(struct Flake *this) {
    return (Rectangle){this->x, this->y, this->image->width, this->image->height};
}