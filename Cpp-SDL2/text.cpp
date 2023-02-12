#include "text.h"

Text::Text(SDL_Renderer* renderer)
    : renderer(renderer) {
    this->rect.x = this->x;
    this->rect.y = this->y;
    this->update(0);

}

void Text::update(int num) {
    if (this->image)
        SDL_DestroyTexture(this->image);

    std::string score_text = "Score: " + std::to_string(num);

    SDL_Surface *surface = TTF_RenderText_Blended(this->font, score_text.c_str(), this->color);
    if (!surface) {
        auto error = fmt::format("Error creating a surface: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->image = SDL_CreateTextureFromSurface(this->renderer, surface);
    if (!this->image) {
        auto error = fmt::format("Error creating a texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    SDL_FreeSurface(surface);

    // Get a rect from the image.
    if (SDL_QueryTexture(this->image, nullptr, nullptr, &this->rect.w, &this->rect.h)) {
        auto error = fmt::format("Error while querying texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }
}

Text::~Text() {
    SDL_DestroyTexture(this->image);
}

void Text::draw() {
    if (SDL_RenderCopy(this->renderer, this->image, nullptr, &this->rect)) {
        auto error = fmt::format("Error while rendering texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }
}