#include "sdl_init.h"

// Initialize SDL, create window and renderer.
enum Errors sdl_setup(struct Game *game) {
    // Initialize SDL.
    if (SDL_Init(MY_SDL_FLAGS))
        return ERROR_SDL;

    // Created the SDL Window.
    game->win = SDL_CreateWindow(TITLE, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, WIDTH, HEIGHT, 0);
    if (!game->win)
        return ERROR_WIN;

    // Create the SDL Renderer.
    game->rend = SDL_CreateRenderer(game->win, -1, SDL_RENDERER_ACCELERATED);
    if (!game->rend)
        return ERROR_REND;

    // Initialize SDL_ttf
    if(TTF_Init())
        return ERROR_TTF;

    // Initialize SDL_image
    int img_flags=IMG_INIT_PNG;
    int img_init=IMG_Init(img_flags);
    if((img_init & img_flags) != img_flags)
        return ERROR_IMG;

        //Initialize SDL_mixer
    if( Mix_OpenAudio( 44100, MIX_DEFAULT_FORMAT, 2, 4096 ) < 0 )
        return ERROR_MIX;

    // load icon image as surface, set as window icon, then release surface.
    SDL_Surface *icon = IMG_Load(ICON);
    if (icon) {
        SDL_SetWindowIcon(game->win, icon);
        SDL_FreeSurface(icon);
    } else
        return ERROR_ICON;
    return 0;
}