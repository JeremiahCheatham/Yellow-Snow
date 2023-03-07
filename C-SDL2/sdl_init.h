#ifndef SDL_INIT_H
#define SDL_INIT_H

#include "main.h"

struct Sdl {
    SDL_Window *window;
    SDL_Renderer *renderer;
    bool error;
};

struct Sdl* sdl_new();
void sdl_free(struct Sdl *this);

#endif