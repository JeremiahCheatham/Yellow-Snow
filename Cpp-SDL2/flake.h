#ifndef FLAKE_H
#define FLAKE_H

#include "main.h"

class Flake {
public:
    Flake(SDL_Renderer* renderer, SDL_Texture* image, bool white, std::mt19937& gen);

    void update(double delta_time);
    void draw();
    void reset(bool full);

    inline int left() const { return this->rect.x; }
    inline int right() const { return this->rect.x + this->rect.w; }
    inline int bottom() const { return this->rect.y + this->rect.h; }
    inline bool is_white() const { return this->white; }

private:
    SDL_Renderer* renderer = nullptr;
    SDL_Texture* image = nullptr;
    SDL_Rect rect;
    bool white;
    const unsigned int speed = 300;
    std::mt19937& gen;
};

#endif // FLAKE_H