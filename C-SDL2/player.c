#include "player.h"

struct Player* player_new(SDL_Renderer *renderer, SDL_Texture *image) {
    struct Player *this = calloc(1, sizeof(struct Player));
    if (!this) {
        fprintf(stderr, "Error in calloc of player!\n");
        return this;
    }

    this->renderer = renderer;
    this->image = image;

    if (SDL_QueryTexture(this->image, NULL, NULL, &this->rect.w, &this->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        this->error = true;
        return this;
    }
    
    this->x = (WIDTH - this->rect.w) / 2;
    this->rect.x = this->x;
    this->rect.y = 374;
    this->speed = 300;
    this->top_offset = 10;
    this->left_offset = 47;
    this->right_offset = 43;
    this->flip = SDL_FLIP_HORIZONTAL;
    this->keystate = SDL_GetKeyboardState(NULL);

    // Create a smaller hit box rect.
    this->hit_box.x = this->rect.x + this->left_offset;
    this->hit_box.w = this->rect.w - this->right_offset - this->left_offset;
    this->hit_box.y = this->rect.y + this->top_offset;
    this->hit_box.h = this->rect.h - this->top_offset;

    this->error = false;
    return this;
}

void player_update(struct Player *this, float delta_time) {
    if (this->keystate[SDL_SCANCODE_LEFT]) {
        this->x -= delta_time * this->speed + 0.5;
        if (this->x + this->left_offset < 0) {
            this->x = -this->left_offset;
        }
        this->rect.x = this->x;
        this->hit_box.x = this->rect.x + this->left_offset;
        this->flip = SDL_FLIP_HORIZONTAL;
    }
    if (this->keystate[SDL_SCANCODE_RIGHT] ) {
        this->x += delta_time * this->speed + 0.5;
        if (this->x + this->rect.w - this->right_offset > WIDTH) {
            this->x = WIDTH + this->right_offset - this->rect.w;
        }
        this->rect.x = this->x;
        this->hit_box.x = this->rect.x + this->left_offset;
        this->flip = SDL_FLIP_NONE;
    }
}

bool player_draw(struct Player *this) {
    if (SDL_RenderCopyEx(this->renderer, this->image, NULL, &this->rect, 0, NULL, this->flip)) {
        fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
        return false;
    }

    return true;
}