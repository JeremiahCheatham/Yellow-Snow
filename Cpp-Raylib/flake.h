#ifndef FLAKE_H
#define FLAKE_H

#include "main.h"

class Flake {
public:
    Flake(const Texture2D& image, bool white);

    void update(float deltaTime);
    void draw();
    void reset(bool full);

    inline float top() const { return this->y; }
    inline float left() const { return this->x; }
    inline float right() const { return this->x + this->image.width; }
    inline float bottom() const { return this->y + this->image.height; }
    inline float width() const { return this->image.width; }
    inline float height() const { return this->image.height; }
    inline bool is_white() const { return this->white; }

private:
    Texture2D image;
    bool white;
    float y;
    float x;
    const unsigned int speed = 300;
};

#endif // FLAKE_H