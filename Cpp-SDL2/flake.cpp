#include "flake.h"
#include "game.h"

Flake::Flake(std::shared_ptr<SDL_Renderer> renderer,
             std::shared_ptr<SDL_Texture> image,
             bool white,
             std::mt19937& gen)
    : renderer{renderer},
      image{image},
      white{white},
      speed{300},
      gen{gen}
{

    if (SDL_QueryTexture(this->image.get(), nullptr, nullptr, &this->rect.w, &this->rect.h)) {
        auto error = fmt::format("Error while querying texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->reset(true);
}

void Flake::update(double delta_time) {
    this->rect.y += static_cast<int>(delta_time * this->speed + 0.5);
}

void Flake::reset(bool full) {
    std::uniform_int_distribution<int> randx(0, (Game::width - this->rect.w));

    int height = full ? Game::height * 2 : Game::height;
    std::uniform_int_distribution<int> randy(0, height);
 
    this->rect.x = randx(this->gen);
    this->rect.y = -randy(this->gen) - this->rect.h;
}

void Flake::draw() {
    if (SDL_RenderCopy(this->renderer.get(), this->image.get(), nullptr, &this->rect)) {
        auto error = fmt::format("Error while rendering texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }
}