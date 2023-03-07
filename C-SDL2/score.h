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
    bool error;
};

struct Score* score_new(SDL_Renderer *renderer, TTF_Font *font);
bool score_update(struct Score *this);
bool score_increment(struct Score *this);
bool score_draw(struct Score *this);
bool score_reset(struct Score *this);

#endif