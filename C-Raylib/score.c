#include "score.h"


struct Score* score_new(Font *font) {
    struct Score *this = malloc(sizeof(struct Score));
    if (!this) {
        fprintf(stderr, "Error in malloc of score_new!\n");
        return this;
    }

    this->font = font;
    this->x = 10;
    this->y = 10;
    this->size = 24;
    this->score = 0;

    int len = snprintf(NULL, 0, "Score: %d", this->score) + 1;
    this->score_str = malloc(sizeof(char) * len);
    if (!this->score_str) {
        fprintf(stderr, "Error in malloc of score->score_str!\n");
        return this; 
    }
    snprintf(this->score_str, len, "Score: %d", this->score);

    return this;
}

void score_increment(struct Score *this) {
    this->score++;
    score_update(this);
}

void score_reset(struct Score *this) {
    this->score = 0;
    score_update(this);
}

void score_update(struct Score *this) {
    int len = snprintf(NULL, 0, "Score: %d", this->score) + 1;
    this->score_str = realloc(this->score_str, sizeof(char) * len);
    snprintf(this->score_str, len, "Score: %d", this->score);
}

void score_draw(struct Score *this) {
    DrawTextEx(*this->font, this->score_str, (Vector2){this->x, this->y}, this->size, 0, WHITE);
}