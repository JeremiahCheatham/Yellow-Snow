#include "flake.h"

struct Flake* flake_new(struct Flake **flakes, SDL_Renderer *renderer, SDL_Texture *image, bool is_white) {
    struct Flake *this = calloc(1, sizeof(struct Flake));
    if (!this) {
        fprintf(stderr, "Error in calloc of flake!\n");
        return this;
    }

    this->renderer = renderer;
    this->image = image;

    // Make this new flake the new had of the linked list.
    if (*flakes) {
        this->next = *flakes;
    } else {
        this->next = NULL;
    }
    *flakes = this;

    // Populate the flake rect width and height
    if (SDL_QueryTexture(image, NULL, NULL, &this->rect.w, &this->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        this->error = true;
        return this;
    }

    this->is_white = is_white;
    this->speed = 300;

    // Set the flake to a random location.
    flake_reset(this, true);

    this->error = false;
    return this;
}

void flake_update(struct Flake *this, float delta_time) {
    this->y += this->speed * delta_time + 0.5;
    this->rect.y = this->y;
}

bool flake_draw(struct Flake *this) {
    if (SDL_RenderCopy(this->renderer, this->image, NULL, &this->rect)) {
        fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
        return false;
    }
    return true;
}

bool flake_check_collide(SDL_Rect *flake, SDL_Rect *player) {
    if (flake->y + flake->h > player->y) {
        if (flake->x + flake->w > player->x) {
            if (flake->x < player->x + player->w) {
                return true;
            }
        }
    }
    return false;
}

void flake_reset(struct Flake *this, bool full) {
    int height = full ? HEIGHT * 2 : HEIGHT;
    this->rect.x = (rand() % (WIDTH - this->rect.w));
    this->rect.y = -((rand() % height) + this->rect.h);
    this->y = this->rect.y;
}