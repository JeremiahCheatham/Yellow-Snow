#include "player.h"
#include "game.h"

Player::Player(const Texture2D& image)
    : image(image) {
    this->x = (Game::width - image.width) / 2;
}

void Player::update(float deltaTime) {
    if (IsKeyDown(KEY_LEFT)) {
        this->x -= deltaTime * this->speed + 0.5;
        if (this->left() < 0) {
            this->set_left(0);
        }
        this->isRight = false;
    }
    if (IsKeyDown(KEY_RIGHT)) {
        this->x += deltaTime * this->speed + 0.5;
        if (this->right() > Game::width) {
            this->set_right(Game::width);
        }
        this->isRight = true;
    }
}

void Player::draw() {
    if (this->isRight) {
        DrawTexture(this->image, this->x, this->y, WHITE);
    } else {
        DrawTextureRec(this->image, {0, 0, (float)-this->image.width, (float)this->image.height}, {this->x, this->y}, WHITE);
    }
}