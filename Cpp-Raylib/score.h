#ifndef SCORE_H
#define SCORE_H

#include "main.h"

class Score {
public:
    Score(const Font& font);

    void increment();
    void reset();
    void draw();

private:
    Font font;
    std::string scoreText;
    unsigned int score;
    const float size = 24;
    const float x = 10;
    const float y = 10;
};

#endif // SCORE_H