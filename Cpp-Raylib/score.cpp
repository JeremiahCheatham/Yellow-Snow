#include "score.h"

Score::Score(const Font& font)
    : font(font) {
    this->reset();
}

void Score::increment() {
    this->score++;
    this->scoreText = "Score: " + std::to_string(score);
}

void Score::reset() {
    this->score = 0;
    this->scoreText = "Score: " + std::to_string(score);
}

void Score::draw() {
    DrawTextEx(this->font, this->scoreText.c_str(), {this->x, this->y}, this->size, 0, WHITE);
}