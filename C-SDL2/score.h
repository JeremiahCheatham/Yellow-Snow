#ifndef SCORE_H
#define SCORE_H

#include "main.h"

struct Score {
    SDL_Renderer *renderer;
    SDL_Texture* image;
    TTF_Font *font;
    SDL_Color color;
    SDL_Rect rect;
    Uint32 score;
};

bool score_new(struct Score **score, SDL_Renderer *renderer);
void score_free(struct Score **score);
bool score_reset(struct Score *s);
bool score_update(struct Score *s);
bool score_increment(struct Score *s);
bool score_draw(struct Score *s);

#endif