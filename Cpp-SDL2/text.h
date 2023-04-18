#ifndef TEXT_H
#define TEXT_H

#include "main.h"

class Text {
public:
    Text(std::shared_ptr<SDL_Renderer> renderer);

    void update(int num);
    void draw();

private:
    std::shared_ptr<SDL_Renderer> renderer;
    std::unique_ptr<SDL_Texture, decltype(&SDL_DestroyTexture)> image;
    std::unique_ptr<TTF_Font, decltype(&TTF_CloseFont)> font;
    SDL_Rect rect;
    SDL_Color color;
};

#endif // TEXT_H