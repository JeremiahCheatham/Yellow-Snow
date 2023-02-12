#ifndef PLAYER_H
#define PLAYER_H

#include "main.h"

class Player {
public:
    Player(SDL_Renderer* renderer);
    ~Player();

    void update(double delta_time);
    void draw();

    inline int left() const { return this->rect.x + this->left_offset; }
    inline int right() const { return this->rect.x + this->rect.w - this->right_offset; }
    inline int top() const { return this->rect.y + this->top_offset; }
    inline void set_left(int left) { this->rect.x = left - this->left_offset; }
    inline void set_right(int right) { this->rect.x = right - this->rect.w + this->right_offset; }

private:
    SDL_Renderer* renderer = nullptr;
    SDL_Texture* image = nullptr;
    SDL_Rect rect;
    SDL_RendererFlip flip = SDL_FLIP_NONE;
    const unsigned int y = 374;
    const unsigned int speed = 300;
    const int top_offset = 16;
    const int left_offset = 47;
    const int right_offset = 43;
    const Uint8 *keystate;
};

#endif // PLAYER_H