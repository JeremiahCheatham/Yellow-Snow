#include "load_media.h"

bool game_load_media(struct Game *g) {

    g->background_image = IMG_LoadTexture(g->renderer, "images/background.png");
    if (!g->background_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return true;
    }

    if (SDL_QueryTexture(g->background_image, NULL, NULL, &g->background_rect.w, &g->background_rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        return true;
    }

    g->player_image = IMG_LoadTexture(g->renderer, "images/player.png");
    if (!g->player_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return true;
    }

    g->white_image = IMG_LoadTexture(g->renderer, "images/white.png");
    if (!g->white_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return true;
    }

    g->yellow_image = IMG_LoadTexture(g->renderer, "images/yellow.png");
    if (!g->yellow_image) {
        fprintf(stderr, "Error creating a texture: %s\n", SDL_GetError());
        return true;
    }

    g->winter_music = Mix_LoadMUS( "music/winter_loop.ogg" );
    if(!g->winter_music) {
        fprintf(stderr, "Failed to load music: %s\n", Mix_GetError());
        return true;
    }

    g->collect_sound = Mix_LoadWAV("sounds/collect.ogg");
    if(!g->collect_sound) {
        fprintf(stderr, "Failed to load sound effect: %s\n", Mix_GetError());
        return true;
    }

    g->hit_sound = Mix_LoadWAV("sounds/hit.ogg");
    if(!g->hit_sound) {
        fprintf(stderr, "Failed to load sound effect: %s\n", Mix_GetError());
        return true;
    }

    return false;
}