#ifndef GAME_H
#define GAME_H

#include "main.h"
#include "player.h"
#include "flake.h"
#include "text.h"
#include "fps.h"

class Game {
public:
    Game();
    ~Game();

    void init();
    void run();

    static constexpr int width{800};
    static constexpr int height{600};
    unsigned int score;
    bool playing;

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
    std::unique_ptr<Player> player;
    std::unique_ptr<Text> text;
    std::unique_ptr<Fps> fps;
    std::random_device rd;
    std::mt19937 gen;
    std::vector<std::unique_ptr<Flake>> flakes;
    const int ground;
};

#endif // GAME_H