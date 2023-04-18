#include "text.h"

Text::Text(std::shared_ptr<SDL_Renderer> renderer)
    : renderer{renderer},
      image{nullptr, SDL_DestroyTexture},
      font{nullptr, TTF_CloseFont},
      rect{10, 10, 0, 0},
      color{255, 255, 255, 255}
{
    this->font.reset(TTF_OpenFont("fonts/freesansbold.ttf", 24));
    if (!this->font) {
        auto error = fmt::format("Error creating font: {}", TTF_GetError());
        throw std::runtime_error(error);
    }

    this->update(0);
}

void Text::update(int num) {

    std::string score_text{"Score: " + std::to_string(num)};

    std::shared_ptr<SDL_Surface> surface{TTF_RenderText_Blended(this->font.get(), score_text.c_str(), this->color)};
    if (!surface) {
        auto error = fmt::format("Error creating a surface: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->image.reset(SDL_CreateTextureFromSurface(this->renderer.get(), surface.get()));
    if (!this->image) {
        auto error = fmt::format("Error creating a texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    // Get a rect from the image.
    if (SDL_QueryTexture(this->image.get(), nullptr, nullptr, &this->rect.w, &this->rect.h)) {
        auto error = fmt::format("Error while querying texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }
}

void Text::draw() {
    if (SDL_RenderCopy(this->renderer.get(), this->image.get(), nullptr, &this->rect)) {
        auto error = fmt::format("Error while rendering texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }
}