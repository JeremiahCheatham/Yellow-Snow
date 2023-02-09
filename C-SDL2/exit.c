#include "exit.h"

// Release memory and null pointers before exiting.
void memory_release_exit(struct Game *game, struct Text *text) {
    switch (game->exit_status) {
        case ERROR_SDL:
            fprintf(stderr, "Error initializing SDL: %s\n", SDL_GetError());
            break;
        case ERROR_WIN:
            fprintf(stderr, "Error creating window: %s\n", SDL_GetError());
            break;
        case ERROR_REND:
            fprintf(stderr, "Error creating renderer: %s\n", SDL_GetError());
            break;
        case ERROR_TTF:
            fprintf(stderr, "Error initializing SDL_ttf: %s\n", TTF_GetError());
            break;
        case ERROR_IMG:
            fprintf(stderr, "Error initializing SDL_image: %s\n", IMG_GetError());
            break;
        case ERROR_NIMG:
            fprintf(stderr, "Expected loaded image missing!\n");
            break;
        case ERROR_ICON:
            fprintf(stderr, "Error creating icon surface: %s\n", SDL_GetError());
            break;
        case ERROR_BOND:
            fprintf(stderr, "Populating rectv array went out of bounds!\n");
            break;
        case ERROR_FONT:
            fprintf(stderr, "Error creating font: %s\n", TTF_GetError());
            break;
        case ERROR_SURF:
            fprintf(stderr, "Error creating a surface: %s\n", SDL_GetError());
            break;
        case ERROR_TEXT:
            fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
            break;
        case ERROR_ARRY:
            fprintf(stderr, "Error an array was not the expected length:\n");
            break;
        case ERROR_MUSC:
            fprintf(stderr, "Failed to load music: %s\n", Mix_GetError());
            break;
        case ERROR_SND:
            fprintf(stderr, "Failed to load sound effect: %s\n", Mix_GetError());
            break;
        case ERROR_MIX:
            fprintf(stderr, "Error initializing SDL_mixer: %s\n", Mix_GetError());
            break;
        case ERROR_MALC:
            fprintf(stderr, "Failed to malloc new asteroid!\n");
            break;
        case ERROR_TARG:
            fprintf(stderr, "Error setting renderer target: %s\n", SDL_GetError());
            break;
        case ERROR_COPY:
            fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
            break;
        case ERROR_XCPY:
            fprintf(stderr, "Error while rotating texture: %s\n", SDL_GetError());
            break;
        case ERROR_CLR:
            fprintf(stderr, "Error while clearing renderer: %s\n", SDL_GetError());
            break;
        case ERROR_QTEX:
            fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
            break;
        case ERROR_BLND:
            fprintf(stderr, "Error setting texture blend mode: %s\n", SDL_GetError());
            break;
        case ERROR_PRES:
            fprintf(stderr, "Error during Render Present: %s\n", SDL_GetError());
            break;
        default:
            break;
    }

    // Free music and sounds chunks. Close Audio.
    Mix_FreeMusic(game->music);
    game->music = NULL;
    Mix_FreeChunk(game->collect);
    game->collect = NULL;
    Mix_FreeChunk(game->hit);
    game->hit = NULL;
    Mix_Quit();

    // Free text textures and fonts.
    SDL_DestroyTexture(text->image);
    text->image = NULL;
    TTF_CloseFont(text->font);
    text->font = NULL;

    // Close SDL_ttf.
    TTF_Quit();

    // Free game textures.
    SDL_DestroyTexture(game->background);
    game->background = NULL;
    SDL_DestroyTexture(game->player);
    game->player = NULL;
    SDL_DestroyTexture(game->white);
    game->white = NULL;
    SDL_DestroyTexture(game->yellow);
    game->yellow = NULL;

    // Close SDL_image
    IMG_Quit();

    // Destroy window and render.
    SDL_DestroyRenderer(game->rend);
    game->rend = NULL;
    SDL_DestroyWindow(game->win);
    game->win = NULL;

    // Close SDL
    SDL_Quit();
    exit(game->exit_status);
}