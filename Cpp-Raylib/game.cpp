#include "game.h"
#include "player.h"
#include "flake.h"
#include "score.h"

Game::Game()
    : backgroundImage{}, playerImage{}, whiteImage{}, yellowImage{}, music{}, collect{}, hit{}, font{} {
    // Initialize Raylib
    InitWindow(this->width, this->height, this->title);
    if (!IsWindowReady()) {
        throw std::runtime_error("Failed to initialize raylib!");
    }

    // Initialize Raylib Audio
    InitAudioDevice();
    if (!IsAudioDeviceReady()) {
        throw std::runtime_error("Failed to initialize raylib!");
    }

    SetTargetFPS(60);
}

void Game::init() {
    this->backgroundImage = LoadTexture("images/background.png");
    if(this->backgroundImage.id == 0) {
        throw std::runtime_error("Failed to load backgroundImage texture!");
    }

    this->playerImage = LoadTexture("images/player.png");
    if(this->playerImage.id == 0) {
        throw std::runtime_error("Failed to load playerImage texture!");
    }

    this->whiteImage = LoadTexture("images/white.png");
    if(this->whiteImage.id == 0) {
        throw std::runtime_error("Failed to load whiteImage texture!");
    }

    this->yellowImage = LoadTexture("images/yellow.png");
    if(this->yellowImage.id == 0) {
        throw std::runtime_error("Failed to load yellowImage texture!");
    }

    // Load background song
    this->music = LoadMusicStream("music/winter_loop.ogg");
    if(!this->music.frameCount) {
        throw std::runtime_error("Failed to load music Music: ");
    }

    // Load short sound effect
    this->collect = LoadSound("sounds/collect.ogg");
    if (!this->collect.frameCount) {
        throw std::runtime_error("Failed to load collect Sound: ");
    }

    this->hit = LoadSound("sounds/hit.ogg");
    if (!this->hit.frameCount) {
        throw std::runtime_error("Failed to load hit Sound: ");
    }

    this->font = LoadFontEx("fonts/freesansbold.ttf", 24, nullptr, 0);
}

Game::~Game() {
    UnloadTexture(this->backgroundImage);
    UnloadTexture(this->playerImage);
    UnloadTexture(this->whiteImage);
    UnloadTexture(this->yellowImage);

    StopMusicStream(this->music);
    UnloadMusicStream(this->music);
    UnloadSound(this->collect);
    UnloadSound(this->hit);

    UnloadFont(this->font);
    
    CloseAudioDevice();
    CloseWindow();
    
}

void Game::run() {
    //Play the music
    PlayMusicStream(this->music);

    // Create player
    Player player(this->playerImage);

    // Create flakes
    std::vector<Flake> flakes;
    for (int i = 0; i < 10; i++) {
        flakes.emplace_back(this->whiteImage, true);
    }
        for (int i = 0; i < 5; i++) {
        flakes.emplace_back(this->yellowImage, false);
    }

    // Create score
    Score score(this->font);

    // Main game loop
    while (!WindowShouldClose()) {
        this->deltaTime = GetFrameTime();

        UpdateMusicStream(this->music);

        if (this->playing) {
            player.update(deltaTime);
            Rectangle playerRect = {player.left(), player.top(), player.width(), player.height()};
            for (auto& flake : flakes) {
                flake.update(deltaTime);
                if (flake.bottom() > this->ground) {
                    flake.reset(false);
                } else if (CheckCollisionRecs(playerRect,
                        {flake.left(), flake.top(), flake.width(), flake.height()})) {
                    if (flake.is_white()) {
                        PlaySound(this->collect);
                        flake.reset(false);
                        score.increment();
                    } else {
                        StopMusicStream(this->music);
                        PlaySound(this->hit);
                        this->playing = false;
                    }
                }
            }
        } else {
            if (IsKeyPressed(KEY_SPACE)) {
                score.reset();
                this->playing = true;
                PlayMusicStream(this->music);
                for (auto& flake : flakes) {
                    flake.reset(true);
                }
            }
        }

        BeginDrawing();

        // Draw the background image
        DrawTexture(this->backgroundImage, 0, 0, WHITE);

        player.draw();
        for (auto& flake : flakes) {
            flake.draw();
        }

        score.draw();

        EndDrawing();
    }
}