#ifndef TEXT_H
#define TEXT_H

#include "common.h"

struct Text {
    SDL_Color color;
    TTF_Font *font;
    SDL_Renderer *rend;
    SDL_Texture* image;
    SDL_Rect rect;
    Uint32 score;
};

enum Errors text_create(struct Text *text, SDL_Renderer *rend);
enum Errors text_update(struct Text *text);
enum Errors text_draw(struct Text *text);

#endif