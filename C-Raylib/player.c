// Included header files.
#include "player.h"

struct Player* player_new(Texture2D *image) {
    struct Player *this = calloc(1, sizeof(struct Player));
    if (!this) {
        fprintf(stderr, "Error in calloc of new_player!\n");
        return this;
    }

    this->image = image;
    this->x = (WIDTH - image->width) / 2;

    this->is_right = true;
    this->y = 378;
    this->speed = 300;
    this->top_offset = 12;
    this->left_offset = 47;
    this->right_offset = 43;

    return this;
}

void player_update(struct Player *this, float delta_time) {
    if (IsKeyDown(KEY_LEFT)) {
        this->x -= delta_time * this->speed + 0.5;
        if (this->x + this->left_offset < 0) {
            this->x = -this->left_offset;
        }
        this->is_right = false;
    }
    if (IsKeyDown(KEY_RIGHT)) {
        this->x += delta_time * this->speed + 0.5;
        if (this->x + this->image->width - this->right_offset > WIDTH) {
            this->x = WIDTH + this->right_offset - this->image->width;
        }
        this->is_right = true;
    }
}

void player_draw(struct Player *this) {
    if (this->is_right) {
        DrawTexture(*(this->image), this->x, this->y, WHITE);
    } else {
        DrawTextureRec(*this->image, (Rectangle){0, 0, -this->image->width, this->image->height}, (Vector2){this->x, this->y}, WHITE);
    }
}

Rectangle player_rect(struct Player *this) {
    return (Rectangle){this->x + this->left_offset,
        this->y + this->top_offset,
        this->image->width - this->right_offset - this->left_offset,
        this->image->height - this->top_offset};
}