#ifndef GAME_H
#define GAME_H

#include "main.h"

class Game {
public:
    Game();
    ~Game();

    void init();
    void run();

    static constexpr int width = 800;
    static constexpr int height = 600;
    unsigned int score = 0;
    bool playing = true;

private:
    const std::string title;
    std::shared_ptr<SDL_Window> window;
    std::shared_ptr<SDL_Renderer> renderer;
    std::unique_ptr<SDL_Texture, decltype(&SDL_DestroyTexture)> background;
    std::shared_ptr<SDL_Texture> white;
    std::shared_ptr<SDL_Texture> yellow;
    std::unique_ptr<Mix_Music, decltype(&Mix_FreeMusic)> music;
    std::unique_ptr<Mix_Chunk, decltype(&Mix_FreeChunk)> collect;
    std::unique_ptr<Mix_Chunk, decltype(&Mix_FreeChunk)> hit;
    const int ground;
};

#endif // GAME_H