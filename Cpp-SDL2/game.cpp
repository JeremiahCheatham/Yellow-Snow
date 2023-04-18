#include "game.h"
#include "player.h"
#include "flake.h"
#include "text.h"
#include "fps.h"


Game::Game()
    : title{"Don't Eat the Yellow Snow!"},
      window{nullptr, SDL_DestroyWindow},
      renderer{nullptr, SDL_DestroyRenderer},
      background{nullptr, SDL_DestroyTexture},
      white{nullptr, SDL_DestroyTexture},
      yellow{nullptr, SDL_DestroyTexture},
      music{nullptr, Mix_FreeMusic},
      collect{nullptr, Mix_FreeChunk},
      hit{nullptr, Mix_FreeChunk},
      ground{550}
{
    // Initialize SDL2
    if (SDL_Init(SDL_INIT_VIDEO) != 0) {
        auto error = fmt::format("Error initializing SDL: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    // Create a window
    this->window = std::shared_ptr<SDL_Window>(SDL_CreateWindow(this->title.c_str(), SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, this->width, this->height, SDL_WINDOW_SHOWN), SDL_DestroyWindow);
    if (!this->window) {
        auto error = fmt::format("Error creating window: {}", SDL_GetError());
        throw std::runtime_error(error);
        SDL_Quit();
    }

    // Create a renderer
    this->renderer.reset(SDL_CreateRenderer(this->window.get(), -1, SDL_RENDERER_ACCELERATED), SDL_DestroyRenderer);
    if (!this->renderer) {
        SDL_Quit();
        auto error = fmt::format("Error creating renderer: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    // Initialize SDL_ttf
    if(TTF_Init()) {
        SDL_Quit();
        auto error = fmt::format("Error initializing SDL_ttf: {}", TTF_GetError());
        throw std::runtime_error(error);
    }

    // Initialize SDL_image
    if ((IMG_Init(IMG_INIT_PNG) & IMG_INIT_PNG) != IMG_INIT_PNG) {
        TTF_Quit();
        SDL_Quit();
        auto error = fmt::format("Error initializing SDL_image: {}", IMG_GetError());
        throw std::runtime_error(error);
    }

    //Initialize SDL_mixer
    if( Mix_OpenAudio( 44100, MIX_DEFAULT_FORMAT, 2, 1024 ) < 0 ) {
        TTF_Quit();
        IMG_Quit();
        SDL_Quit();
        auto error = fmt::format("Error initializing SDL_mixer: {}", Mix_GetError());
        throw std::runtime_error(error);
    }
}

void Game::init() {
    SDL_Surface* surface = IMG_Load("images/yellow.png");
    if (surface) {
        SDL_SetWindowIcon(this->window.get(), surface);
        SDL_FreeSurface(surface);
    } else {
        auto error = fmt::format("Error creating a surface: {}", SDL_GetError());
        throw std::runtime_error(error); 
    }

    this->background.reset(IMG_LoadTexture(this->renderer.get(), "images/background.png"));
    if (!this->background) {
        auto error = fmt::format("Error creating a texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->white.reset(IMG_LoadTexture(this->renderer.get(), "images/white.png"), SDL_DestroyTexture);
    if (!this->white) {
        auto error = fmt::format("Error creating a texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->yellow.reset(IMG_LoadTexture(this->renderer.get(), "images/yellow.png"), SDL_DestroyTexture);
    if (!this->yellow) {
        auto error = fmt::format("Error creating a texture: {}", SDL_GetError());
        throw std::runtime_error(error);
    }

    this->music.reset(Mix_LoadMUS( "music/winter_loop.ogg" ));
    if(!this->music) {
        auto error = fmt::format("Failed to load music: {}", Mix_GetError());
        throw std::runtime_error(error);
    }

    this->collect.reset(Mix_LoadWAV("sounds/collect.ogg"));
    if(!this->collect) {
        auto error = fmt::format("Failed to load sound effect: {}", Mix_GetError());
        throw std::runtime_error(error);
    }

    this->hit.reset(Mix_LoadWAV("sounds/hit.ogg"));
    if(!this->hit) {
        auto error = fmt::format("Failed to load sound effect: {}", Mix_GetError());
        throw std::runtime_error(error);
    }
}

Game::~Game() {
    // Clean up SDL_mixer, SDL_ttf, SDL_image and SDL2.
    Mix_CloseAudio();
    Mix_Quit();
    TTF_Quit();
    IMG_Quit();
    SDL_Quit();
}

void Game::run() {
    //Play the music
    Mix_PlayMusic(this->music.get(), -1);

    Player player(this->renderer);

    std::random_device rd;
    std::mt19937 gen(rd());

    std::vector<Flake> flakes;
    for (int i = 0; i < 10; i++) {
        flakes.emplace_back(this->renderer, this->white, true, gen);
    }
        for (int i = 0; i < 5; i++) {
        flakes.emplace_back(this->renderer, this->yellow, false, gen);
    }

    Text text(this->renderer);

    Fps fps(60);

    // Main game loop
    while (true) {
        // Handle events
        SDL_Event event;
        while (SDL_PollEvent(&event)) {
            if (event.type == SDL_QUIT) {
                return;
            } else if (event.type == SDL_KEYDOWN) {
                // keyboard API for key pressed
                switch (event.key.keysym.scancode) {
                    case SDL_SCANCODE_ESCAPE:
                        return;
                    case SDL_SCANCODE_SPACE:
                        if (!this->playing) {
                            this->score = 0;
                            text.update(this->score);
                            this->playing = true;
                            Mix_PlayMusic(this->music.get(), -1);
                            for (auto& flake : flakes) {
                                flake.reset(true);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        if (this->playing) {
            player.update(fps.delta_time());
            for (auto& flake : flakes) {
                flake.update(fps.delta_time());

                if (flake.bottom() > this->ground) {
                    flake.reset(false);
                } else if (flake.bottom() > player.top() && flake.right() > player.left() && flake.left() < player.right()) {
                    if (flake.is_white()) {
                        Mix_PlayChannel(-1, this->collect.get(), 0);
                        flake.reset(false);
                        this->score++;
                        text.update(this->score);
                        // game.exit_status = text_update(&text);
                    } else {
                        Mix_HaltMusic();
                        Mix_PlayChannel(-1, this->hit.get(), 0);
                        this->playing = false;
                    }
                }
            }
        }

        // Clear the screen
        SDL_RenderClear(this->renderer.get());

        // Draw the images to the renderer.
        if (SDL_RenderCopy(this->renderer.get(), this->background.get(), nullptr, nullptr)) {
            auto error = fmt::format("Error while rendering texture: {}", SDL_GetError());
            throw std::runtime_error(error);
        }

        player.draw();
        for (auto& flake : flakes) {
            flake.draw();
        }

        text.draw();

        // Present the screen
        SDL_RenderPresent(this->renderer.get());

        fps.update();
    }
}