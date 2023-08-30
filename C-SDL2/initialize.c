#include "initialize.h"

bool game_initilize(struct Game *g) {

    if (SDL_Init(SDL_FLAGS)) {
        fprintf(stderr, "Error initializing SDL: %s\n", SDL_GetError());
        return true;
    }

    int img_flags = IMG_INIT_PNG;
    int img_init = IMG_Init(img_flags);
    if((img_init & img_flags) != img_flags) {
        fprintf(stderr, "Error initializing SDL_image: %s\n", IMG_GetError());
        return true;
    }

    if( Mix_OpenAudio( 44100, MIX_DEFAULT_FORMAT, 2, 1024 ) < 0 ) {
        fprintf(stderr, "Error initializing SDL_mixer: %s\n", Mix_GetError());
        return true;
    }

    if(TTF_Init()) {
        fprintf(stderr, "Error initializing SDL_ttf: %s\n", TTF_GetError());
        return true;
    }

    g->window = SDL_CreateWindow(WINDOW_TITLE, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, WINDOW_WIDTH, WINDOW_HEIGHT, 0);
    if (!g->window) {
        fprintf(stderr, "Error creating window: %s\n", SDL_GetError());
        return true;
    }

    g->renderer = SDL_CreateRenderer(g->window, -1, SDL_RENDERER_ACCELERATED);
    if (!g->renderer) {
        fprintf(stderr, "Error creating renderer: %s\n", SDL_GetError());
        return true;
    }

    SDL_Surface *icon_surf = IMG_Load(WINDOW_ICON);
    if (icon_surf) {
        SDL_SetWindowIcon(g->window, icon_surf);
        SDL_FreeSurface(icon_surf);
    } else {
        fprintf(stderr, "Error creating icon surface: %s\n", SDL_GetError());
        return true;
    }

    srand((Uint32)time(NULL));

    return false;
}