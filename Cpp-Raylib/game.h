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
    Texture2D backgroundImage;
    Texture2D playerImage;
    Texture2D whiteImage;
    Texture2D yellowImage;
    Music music;
    Sound collect;
    Sound hit;
    Font font;
    const int ground = 550;
    float deltaTime = 0;
};

#endif // GAME_H