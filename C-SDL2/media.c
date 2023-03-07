#include "media.h"

 // Loads image by name and returns texture.
bool media_load(struct Game *game) {

    game->background_image = IMG_LoadTexture(game->renderer, "images/background.png");
    if (!game->background_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return false;
    }

    game->player_image = IMG_LoadTexture(game->renderer, "images/player.png");
    if (!game->player_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return false;
    }

    game->white_image = IMG_LoadTexture(game->renderer, "images/white.png");
    if (!game->white_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return false;
    }

    game->yellow_image = IMG_LoadTexture(game->renderer, "images/yellow.png");
    if (!game->yellow_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return false;
    }

    game->music = Mix_LoadMUS( "music/winter_loop.ogg" );
    if(!game->music) {
        fprintf(stderr, "Failed to load music: %s\n", Mix_GetError());
        return false;
    }

    game->collect = Mix_LoadWAV("sounds/collect.ogg");
    if(!game->collect) {
        fprintf(stderr, "Failed to load sound effect: %s\n", Mix_GetError());
        return false;
    }

    game->hit = Mix_LoadWAV("sounds/hit.ogg");
    if(!game->hit) {
        fprintf(stderr, "Failed to load sound effect: %s\n", Mix_GetError());
        return false;
    }
    
    game->font = TTF_OpenFont("fonts/freesansbold.ttf", 24);
    if (!game->font) {
        fprintf(stderr, "Error creating font: %s\n", TTF_GetError());
        return false;
    }

    return true;
}