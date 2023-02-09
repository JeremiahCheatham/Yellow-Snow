#include "flakes.h"

enum Errors flake_create(struct Flakes *flakes, SDL_Texture *image, SDL_Rect rect, bool is_white, SDL_Renderer *rend) {
    struct Flake *new_flake = malloc (sizeof(struct Flake));
    if (!new_flake)
        return ERROR_MALC;

    new_flake->image = image;
    new_flake->is_white = is_white;
    new_flake->rend = rend;
    new_flake->rect = rect;
    new_flake->speed = FLAKE_SPEED;

    new_flake->previous = NULL;
    
    if (flakes->first_flake) {
        new_flake->next = flakes->first_flake;
        flakes->first_flake->previous = new_flake;
    } else {
        new_flake->next = NULL;
    }

    flakes->first_flake = new_flake;

    return 0;
}

enum Errors flakes_create(struct Flakes *flakes, SDL_Texture *image, bool is_white, Uint8 num, SDL_Renderer *rend) {

    SDL_Rect rect;
    if (SDL_QueryTexture(image, NULL, NULL, &rect.w, &rect.h))
        return ERROR_QTEX;

    for(short unsigned i = 0; i < num; i++) {
        rect.x = (rand() % (WIDTH - rect.w ));
        rect.y = -((rand() % (HEIGHT * 2)) + rect.h);

        enum Errors rvalue = flake_create(flakes, image, rect, is_white, rend);
        if (rvalue)
            return rvalue;
    }
    return 0;
}

void flakes_update(struct Flakes *flakes, const float delta_time) {
    for(struct Flake *flake = flakes->first_flake; flake != NULL; flake = flake->next) {
        flake->rect.y += flake->speed * delta_time;
    }
}

enum Errors flakes_draw(struct Flakes *flakes) {
    for(struct Flake *flake = flakes->first_flake; flake != NULL; flake = flake->next) {
        if ( SDL_RenderCopy(flake->rend, flake->image, NULL, &flake->rect)) {
            return ERROR_COPY;
        }
    }
    return 0;
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

void flake_reset(SDL_Rect *flake, bool full_reset) {
    flake->x = (rand() % (WIDTH - flake->w));
    if (full_reset) {
        flake->y = -((rand() % (HEIGHT * 2)) + flake->h);
    } else {
        flake->y = -((rand() % HEIGHT) + flake->h);
    }
}