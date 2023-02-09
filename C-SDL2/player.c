#include "player.h"

enum Errors player_create(struct Player *player) {
    // Get the rectangles from player texture.

    if (SDL_QueryTexture(player->image, NULL, NULL, &player->rect.w, &player->rect.h))
        return ERROR_QTEX;
    
    player->rect.x = (WIDTH - player->rect.w) / 2;
    player->rect.y = PLAYER_TOP;

    player->hit_box.x = player->rect.x + PLAYER_LEFT_OFFSET;
    player->hit_box.y = player->rect.y + PLAYER_TOP_OFFSET;
    player->hit_box.w = player->rect.w - PLAYER_LEFT_OFFSET - PLAYER_RIGHT_OFFSET;
    player->hit_box.h = player->rect.h - PLAYER_TOP_OFFSET;
    player->speed = PLAYER_SPEED;
    player->flip = SDL_FLIP_HORIZONTAL;

    return 0;
}

void player_update(struct Player *player, const float delta_time) {
    if (player->keystate[SDL_SCANCODE_LEFT] ) {
        player->rect.x -= player->speed * delta_time;
        if (player->rect.x < -PLAYER_LEFT_OFFSET) {
            player->rect.x = -PLAYER_LEFT_OFFSET;
        }
        player->hit_box.x = player->rect.x + PLAYER_LEFT_OFFSET;
        player->flip = SDL_FLIP_HORIZONTAL;
    }
    if (player->keystate[SDL_SCANCODE_RIGHT] ) {
        player->rect.x += player->speed * delta_time;
        if (player->rect.x > WIDTH - player->rect.w + PLAYER_RIGHT_OFFSET) {
            player->rect.x = WIDTH - player->rect.w + PLAYER_RIGHT_OFFSET;
        }
        player->hit_box.x = player->rect.x + PLAYER_LEFT_OFFSET;
        player->flip = SDL_FLIP_NONE;
    }
}

enum Errors player_draw(struct Player *player) {
    if (SDL_RenderCopyEx(player->rend, player->image, NULL, &player->rect, 0, NULL, player->flip))
        return ERROR_XCPY;
    return 0;
}