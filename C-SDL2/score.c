#include "score.h"


struct Score* score_new(SDL_Renderer *renderer, TTF_Font *font) {
    struct Score *this = calloc(1, sizeof(struct Score));
    if (!this) {
        fprintf(stderr, "Error in calloc of score!\n");
        return this;
    }

    this->renderer = renderer;
    this->image = NULL;
    this->font = font;
    this->color = (SDL_Color){255, 255, 255, 255};
    this->rect.x = 10;
    this->rect.y = 10;
    this->score = 0;
    this->error = false;

    if (!score_update(this)) {
        this->error = true;
    }

    return this;
}


bool score_update(struct Score *this) {
    if (this->image)
        SDL_DestroyTexture(this->image);
    
    int length = snprintf(NULL, 0, "Score: %d", this->score) + 1;
    char score_str[length];
    snprintf(score_str, length, "Score: %d", this->score);

    SDL_Surface *surface = TTF_RenderText_Blended(this->font, score_str, this->color);
    if (!surface) {
        fprintf(stderr, "Error creating a surface: %s\n", SDL_GetError());
        return false;
    }

    this->image = SDL_CreateTextureFromSurface(this->renderer, surface);
    if (!this->image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return false;
    }

    SDL_FreeSurface(surface);

    // Get a rect from the original image.
    if (SDL_QueryTexture(this->image, NULL, NULL, &this->rect.w, &this->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        return false;
    }
    
    return true;
}

bool score_increment(struct Score *this) {
    this->score += 1;
    if (!score_update(this)) {
        return false;
    }

    return true;
}

bool score_draw(struct Score *this) {
    if (SDL_RenderCopy(this->renderer, this->image, NULL, &this->rect)) {
        fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
        return false;
    }

    return true;
}

bool score_reset(struct Score *this) {
    this->score = 0;
    if (!score_update(this)) {
        return false;
    }

    return true;
}
