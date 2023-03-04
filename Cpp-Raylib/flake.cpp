#include "flake.h"
#include "game.h"

Flake::Flake(const Texture2D& image, bool white)
    : image(image), white(white) {

    this->reset(true);
}

void Flake::update(float deltaTime) {
    this->y += deltaTime * this->speed + 0.5;
}

void Flake::reset(bool full) {
    int height = full ? Game::height * 2 : Game::height;

    this->x = GetRandomValue(0, (Game::width - this->image.width));
    this->y = -(GetRandomValue(0, height) + this->image.width);
}

void Flake::draw() {
    DrawTexture(this->image, this->x, this->y, WHITE);
}