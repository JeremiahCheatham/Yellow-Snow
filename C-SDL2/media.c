#include "media.h"

 // Loads image by name and returns texture.
enum Errors texts_load(struct Game *game) {
    SDL_Surface* surface = IMG_Load("images/background.png");
    if (!surface)
        return ERROR_SURF;
    game->background = SDL_CreateTextureFromSurface(game->rend, surface);
    if (!game->background)
        return ERROR_TEXT;
    SDL_FreeSurface(surface);
    surface = NULL;

    surface = IMG_Load("images/player.png");
    if (!surface)
        return ERROR_SURF;
    game->player = SDL_CreateTextureFromSurface(game->rend, surface);
    if (!game->player)
        return ERROR_TEXT;
    SDL_FreeSurface(surface);
    surface = NULL;

    surface = IMG_Load("images/white.png");
    if (!surface)
        return ERROR_SURF;
    game->white = SDL_CreateTextureFromSurface(game->rend, surface);
    if (!game->white)
        return ERROR_TEXT;
    SDL_FreeSurface(surface);
    surface = NULL;

    surface = IMG_Load("images/yellow.png");
    if (!surface)
        return ERROR_SURF;
    game->yellow = SDL_CreateTextureFromSurface(game->rend, surface);
    if (!game->yellow)
        return ERROR_TEXT;
    SDL_FreeSurface(surface);
    surface = NULL;

    return 0;
}

enum Errors audio_load(struct Game *game) {
    game->music = Mix_LoadMUS( "music/winter_loop.ogg" );
    if(!game->music)
        return ERROR_MUSC;

    game->collect = Mix_LoadWAV("sounds/collect.wav");
    if(!game->collect)
        return ERROR_SND;

    game->hit = Mix_LoadWAV("sounds/hit.wav");
    if(!game->hit)
        return ERROR_SND;

    return 0;
}