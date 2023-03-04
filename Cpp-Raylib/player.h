#ifndef PLAYER_H
#define PLAYER_H

#include "main.h"

class Player {
public:
    Player(const Texture2D& image);

    void update(float deltaTime);
    void draw();

    inline float left() const { return this->x + this->leftOffset; }
    inline int right() const { return this->x + this->image.width - this->rightOffset; }
    inline float top() const { return this->y + this->topOffset; }
    inline float width() const { return this->image.width - this->leftOffset - this->rightOffset; }
    inline float height() const { return this->image.height - this->topOffset; }
    inline void set_left(int left) { this->x = left - this->leftOffset; }
    inline void set_right(int right) { this->x = right - this->image.width + this->rightOffset; }

private:
    Texture2D image;
    float x;
    bool isRight = true;
    float y = 378;
    const unsigned int speed = 300;
    const int topOffset = 12;
    const int leftOffset = 47;
    const int rightOffset = 43;
};

#endif // PLAYER_H