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
    const char* title = "Don't Eat the Yellow Snow!";
    SDL_Window* window = nullptr;
    SDL_Renderer* renderer = nullptr;
    SDL_Texture* background = nullptr;
    SDL_Texture* white = nullptr;
    SDL_Texture* yellow = nullptr;
    Mix_Music* music = nullptr;
    Mix_Chunk* collect = nullptr;
    Mix_Chunk* hit = nullptr;
    const int ground = 550;
};

#endif // GAME_H