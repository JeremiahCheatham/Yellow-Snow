#include "flake.h"

bool flake_new(struct Flake **flakes, SDL_Renderer *renderer, SDL_Texture *image, bool is_white) {

    struct Flake *new_flake = calloc(1, sizeof(struct Flake));
    if (!new_flake) {
        fprintf(stderr, "Error in calloc of new flake!\n");
        return true;
    }

    if (SDL_QueryTexture(image, NULL, NULL, &new_flake->rect.w, &new_flake->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        return true;
    }
    
    new_flake->renderer = renderer;
    new_flake->image = image;
    new_flake->is_white = is_white;
    new_flake->speed = 300;

    flake_reset(new_flake, true);

    if (*flakes) {
        new_flake->next = *flakes;
    } else {
        new_flake->next = NULL;
    }
    *flakes = new_flake;

    return false;
}

void flakes_free(struct Flake **flakes) {
    struct Flake *f = *flakes;
    while (f) {
        f->image =  NULL;
        f->renderer = NULL;
        struct Flake *next = f->next;
        free(f);
        f = next;
    }
    *flakes = NULL;
}

void flake_reset(struct Flake *f, bool full) {
    int height = full ? WINDOW_HEIGHT * 2 : WINDOW_HEIGHT;
    f->rect.x = (rand() % (WINDOW_WIDTH - f->rect.w));
    f->rect.y = -((rand() % height) + f->rect.h);
    f->y_pos = f->rect.y;
}

void flakes_reset(struct Flake *f, bool full) {
    while (f) {
        flake_reset(f, full);
        f = f->next;
    }
}

int flake_left(struct Flake *f) {
    return f->rect.x;
}

int flake_right(struct Flake *f) {
    return f->rect.x + f->rect.w;
}

int flake_bottom(struct Flake *f) {
    return f->rect.y + f->rect.h;
}

void flakes_update(struct Flake *f, double dt) {
    while (f) {
        f->y_pos += f->speed * dt;
        if (f->y_pos > 514) {
            flake_reset(f, false);
        } else {
            f->rect.y = (int)(f->y_pos + 0.5);
        }
        f = f->next;
    }
}

bool flakes_draw(struct Flake *f) {
    while (f) {
        if (SDL_RenderCopy(f->renderer, f->image, NULL, &f->rect)) {
            fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
            return true;
        }
        f = f->next;
    }
    return false;
}