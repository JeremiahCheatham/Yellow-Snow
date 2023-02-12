#ifndef TEXT_H
#define TEXT_H

#include "main.h"

class Text {
public:
    Text(SDL_Renderer* renderer);
    ~Text();

    void update(int num);
    void draw();

private:
    SDL_Renderer* renderer = nullptr;
    SDL_Texture* image = nullptr;
    SDL_Rect rect;
    SDL_Color color = {255, 255, 255, 255};
    TTF_Font* font = TTF_OpenFont("fonts/freesansbold.ttf", 24);
    const int x = 10;
    const int y = 10;
};

#endif // TEXT_H