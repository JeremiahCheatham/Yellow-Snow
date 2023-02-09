// Included header files.
#include "common.h"
#include "sdl_init.h"
#include "media.h"
#include "player.h"
#include "flakes.h"
#include "text.h"
#include "fps.h"
#include "exit.h"

int main() {
    srand(time(NULL));

    struct Game game = {
        .event = {0},
        .win = NULL,
        .rend = NULL,
        .background = NULL,
        .player = NULL,
        .white = NULL,
        .yellow = NULL,
        .score_text = NULL,
        .music = NULL,
        .collect = NULL,
        .hit = NULL,
        .frame_delay = 1000.0f / FPS,
        .delta_time = 0,
        .show_fps = false,
        .exit_status = 0,
        .playing = true
    };

    struct Text text = {
        .rend = NULL,
        .image = NULL,
        .font = NULL
    };

    // Initialize SDL, create window and renderer.
    game.exit_status = sdl_setup(&game);
    if (game.exit_status)
        memory_release_exit(&game, &text);

    // load all the textures into a textures array.
    game.exit_status = texts_load(&game);
    if (game.exit_status)
        memory_release_exit(&game, &text);

    // load all audio.
    game.exit_status = audio_load(&game);
    if (game.exit_status)
        memory_release_exit(&game, &text);

    //Play the music
    Mix_PlayMusic(game.music, -1);

    struct Player player = {
        .rend = game.rend,
        .image = game.player,
        .keystate = SDL_GetKeyboardState(NULL)
    };

    game.exit_status = text_create(&text, game.rend);
    if (game.exit_status)
        memory_release_exit(&game, &text);

    struct Flakes flakes = { .first_flake = NULL };

    flakes_create(&flakes, game.white, true, 10, game.rend);
    flakes_create(&flakes, game.yellow, false, 5, game.rend);

    game.exit_status = player_create(&player);
    if (game.exit_status)
        memory_release_exit(&game, &text);

    if (SDL_QueryTexture(player.image, NULL, NULL, &player.rect.w, &player.rect.h))
        return ERROR_QTEX;

    while (!game.exit_status) {
        // process events

        // Check key events, key pressed or released.
        while (SDL_PollEvent(&game.event)) {
            switch (game.event.type) {

                case SDL_QUIT:
                    // handling of close button
                    game.exit_status = QUIT;
                    break;

                case SDL_KEYDOWN:
                    // keyboard API for key pressed
                    switch (game.event.key.keysym.scancode) {
                        case SDL_SCANCODE_ESCAPE:
                            game.exit_status = QUIT;
                            break;
                        case SDL_SCANCODE_SPACE:
                            if (!game.playing) {
                                text.score = 0;
                                game.exit_status = text_update(&text);
                                game.playing = true;
                                for(struct Flake *flake = flakes.first_flake; flake != NULL; flake = flake->next) {
                                    flake_reset(&flake->rect, true);
                                }
                                Mix_PlayMusic(game.music, -1);
                            }
                            break;
                        default:
                            break;
                    }
            }
        }

        if (game.exit_status)
            continue;

        if (game.playing) {
            player_update(&player, game.delta_time);

            flakes_update(&flakes, game.delta_time);

            for(struct Flake *flake = flakes.first_flake; flake != NULL; flake = flake->next) {
                if (flake->rect.y + flake->rect.h > GROUND) {
                    flake_reset(&flake->rect, false);
                } else if (flake_check_collide(&flake->rect, &player.hit_box)) {
                    if (flake->is_white) {
                        Mix_PlayChannel(-1, game.collect, 0);
                        flake_reset(&flake->rect, false);
                        text.score += 1;
                        game.exit_status = text_update(&text);
                    } else {
                        Mix_HaltMusic();
                        Mix_PlayChannel(-1, game.hit, 0);
                        game.playing = false;
                    }
                }
            }
        }
        if (game.exit_status)
            continue;

        // Clear the existing renderer.
        if (SDL_RenderClear(game.rend)) {
            game.exit_status = ERROR_CLR;
            continue;
        }

        // Draw the images to the renderer.
        if ( SDL_RenderCopy(game.rend, game.background, NULL, NULL)) {
            game.exit_status = ERROR_COPY;
            continue;
        }

        // Draw player to the renderer.
        game.exit_status = player_draw(&player);
        if (game.exit_status)
            continue;

        game.exit_status = flakes_draw(&flakes);
        if (game.exit_status)
            continue;

        game.exit_status = text_draw(&text);
        if (game.exit_status)
            continue;
        
        // Swap the back buffer to the front.
        SDL_RenderPresent(game.rend);

        // Print FPS to standard output.
        if (game.show_fps)
            fps_print();

        // Calculate delay needed for the FPS.
        fps_delay(&game);
    }

    // Release memory and null pointers before exiting.
    memory_release_exit(&game, &text);
}