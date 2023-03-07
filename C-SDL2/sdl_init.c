#include "sdl_init.h"

struct Sdl* sdl_new() {
    struct Sdl *this = calloc(1, sizeof(struct Sdl));
    if (!this) {
        fprintf(stderr, "Error in calloc of new sdl!\n");
        return this;
    }

    this->error = true;

    // Initialize SDL.
    if (SDL_Init(MY_SDL_FLAGS)) {
        fprintf(stderr, "Error initializing SDL: %s\n", SDL_GetError());
        return this;
    }

    // Created the SDL Window.
    this->window = SDL_CreateWindow(TITLE, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, WIDTH, HEIGHT, 0);
    if (!this->window) {
        fprintf(stderr, "Error creating window: %s\n", SDL_GetError());
        return this;
    }

    // Create the SDL Renderer.
    this->renderer = SDL_CreateRenderer(this->window, -1, SDL_RENDERER_ACCELERATED);
    if (!this->renderer) {
        fprintf(stderr, "Error creating renderer: %s\n", SDL_GetError());
        return this;
    }

    // Initialize SDL_ttf
    if(TTF_Init()) {
        fprintf(stderr, "Error initializing SDL_ttf: %s\n", TTF_GetError());
        return this;
    }

    // Initialize SDL_image
    int img_flags=IMG_INIT_PNG;
    int img_init=IMG_Init(img_flags);
    if((img_init & img_flags) != img_flags) {
        fprintf(stderr, "Error initializing SDL_image: %s\n", IMG_GetError());
        return this;
    }

        //Initialize SDL_mixer
    if( Mix_OpenAudio( 44100, MIX_DEFAULT_FORMAT, 2, 1024 ) < 0 ) {
        fprintf(stderr, "Error initializing SDL_mixer: %s\n", Mix_GetError());
        return this;
    }

    // load icon image as surface, set as window icon, then release surface.
    SDL_Surface *icon = IMG_Load(ICON);
    if (icon) {
        SDL_SetWindowIcon(this->window, icon);
        SDL_FreeSurface(icon);
    } else {
        fprintf(stderr, "Error creating icon surface: %s\n", SDL_GetError());
        return this;
    }

    this->error = false;
    return this;
}

void sdl_free(struct Sdl *this) {
    // Close audio device and quit SDL_mixer
    Mix_CloseAudio();
    Mix_Quit();

    // Close SDL_image
    IMG_Quit();
    
    // Close SDL_ttf
    TTF_Quit();

    // Destroy renderer and window then Close SDL2
    SDL_DestroyRenderer(this->renderer);
    SDL_DestroyWindow(this->window);
    SDL_Quit();

    free(this);
}