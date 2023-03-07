#ifndef PLAYER_H
#define PLAYER_H

#include "main.h"
#include "player.h"

struct Player {
    Texture2D *image;
    float x;
    bool is_right;
    float y;
    unsigned int speed;
    int top_offset;
    int left_offset;
    int right_offset;
};

struct Player* player_new(Texture2D *image);
void player_update(struct Player *this, float delta_time);
void player_draw(struct Player *this);
Rectangle player_rect(struct Player *this);

#endif // PLAYER_H