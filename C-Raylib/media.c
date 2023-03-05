#include "media.h"

bool media_load(struct Game *game) {

    game->background_image = LoadTexture("images/background.png");
    if(game->background_image.id == 0) {
        fprintf(stderr, "Error in LoadTexture of background_image!\n");
        return false;
    }

    game->player_image = LoadTexture("images/player.png");
    if(game->player_image.id == 0) {
        fprintf(stderr, "Error in LoadTexture of player_image!\n");
        return false;
    }

    game->white_image = LoadTexture("images/white.png");
    if(game->white_image.id == 0) {
        fprintf(stderr, "Error in LoadTexture of white_image!\n");
        return false;
    }

    game->yellow_image = LoadTexture("images/yellow.png");
    if(game->yellow_image.id == 0) {
        fprintf(stderr, "Error in LoadTexture of yellow_image!\n");
        return false;
    }

    // Load background song
    game->music = LoadMusicStream("music/winter_loop.ogg");
        if(!game->music.frameCount) {
        fprintf(stderr, "Error in LoadMuscStream of music!\n");
        return false;
    }

    // Load short sound effect
    game->collect = LoadSound("sounds/collect.ogg");
    if(!game->collect.frameCount) {
        fprintf(stderr, "Error in LoadSound of collect!\n");
        return false;
    }

    game->hit = LoadSound("sounds/hit.ogg");
    if(!game->hit.frameCount) {
        fprintf(stderr, "Error in LoadSound of hit!\n");
        return false;
    }

    game->font = LoadFontEx("fonts/freesansbold.ttf", 24, NULL, 0);

    return true;
}