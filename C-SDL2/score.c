#include "score.h"

bool score_new(struct Score **score, SDL_Renderer *renderer) {

    *score = calloc(1, sizeof(struct Score));
    if (!*score) {
        fprintf(stderr, "Error in calloc of score!\n");
        return true;
    }
    struct Score *s = *score;

    s->renderer = renderer;
    s->color = (SDL_Color){255, 255, 255, 255};

    s->font = TTF_OpenFont("fonts/freesansbold.ttf", FONT_SIZE);
    if (!s->font) {
        fprintf(stderr, "Error creating font: %s\n", TTF_GetError());
        return true;
    }

    s->rect.x = 10;
    s->rect.y = 10;

    if (score_reset(s)) {
        return true;
    }

    return false;
}

void score_free(struct Score **score) {
    if (*score) {
        TTF_CloseFont((*score)->font);
        (*score)->font = NULL;
        SDL_DestroyTexture((*score)->image);
        (*score)->image = NULL;
        (*score)->renderer = NULL;
        free(*score);
        *score = NULL;
    }
}

bool score_reset(struct Score *s) {
    s->score = 0;
    if (score_update(s)) {
        return true;
    }

    return false;
}

bool score_update(struct Score *s) {
    if (s->image) {
        SDL_DestroyTexture(s->image);
    }
    
    int length = snprintf(NULL, 0, "Score: %d", s->score) + 1;
    char score_str[length];
    snprintf(score_str, (size_t)length, "Score: %d", s->score);

    SDL_Surface *surface = TTF_RenderText_Blended(s->font, score_str, s->color);
    if (!surface) {
        fprintf(stderr, "Error creating a surface: %s\n", SDL_GetError());
        return true;
    }

    s->image = SDL_CreateTextureFromSurface(s->renderer, surface);
    if (!s->image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return true;
    }

    SDL_FreeSurface(surface);

    if (SDL_QueryTexture(s->image, NULL, NULL, &s->rect.w, &s->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        return true;
    }
    
    return false;
}

bool score_increment(struct Score *s) {
    s->score++;
    if (score_update(s)) {
        return true;
    }

    return false;
}

bool score_draw(struct Score *s) {
    if (SDL_RenderCopy(s->renderer, s->image, NULL, &s->rect)) {
        fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
        return true;
    }

    return false;
}