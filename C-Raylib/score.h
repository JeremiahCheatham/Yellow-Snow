#ifndef SCORE_H
#define SCORE_H

#include "main.h"

// Struct for node of linked list.
struct Score {
    Font *font;
    char *score_str;
    float x;
    float y;
    float size;
    unsigned int score;
};

struct Score* score_new(Font *font);
void score_increment(struct Score *this);
void score_update(struct Score *this);
void score_draw(struct Score *this);
void score_reset(struct Score *this);

#endif // SCORE_H