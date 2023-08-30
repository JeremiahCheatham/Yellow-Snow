#include "game.h"
#include "initialize.h"
#include "load_media.h"

bool game_new(struct Game **game) {
    *game = calloc(1, sizeof(struct Game));
    if (*game == NULL) {
        fprintf(stderr, "Error in calloc of new game.\n");
        return true;
    }
    struct Game *g = *game;

    if (game_initilize(g)) {
        return true;
    }

    if (game_load_media(g)) {
        return true;
    }

    if (player_new(&g->player, g->renderer, g->player_image)) {
        return true;
    }

    for (unsigned int i = 0; i < 10; i++) {
        if (flake_new(&g->flakes, g->renderer, g->white_image, true)) {
            return true;
        }
    }

    for (unsigned int i = 0; i < 5; i++) {
        if (flake_new(&g->flakes, g->renderer, g->yellow_image, false)) {
            return true;
        }
    }

    if (score_new(&g->score, g->renderer)) {
        return true;
    }

    if (fps_new(&g->fps)) {
        return true;
    }

    g->playing = true;

    return false;
}

void game_free(struct Game **game) {
    struct Game *g = *game;

    player_free(&g->player);
    flakes_free(&g->flakes);
    score_free(&g->score);
    fps_free(&g->fps);

    Mix_FreeChunk(g->hit_sound);
    g->hit_sound = NULL;
    Mix_FreeChunk(g->collect_sound);
    g->collect_sound = NULL;
    Mix_FreeMusic(g->winter_music);
    g->winter_music = NULL;
    SDL_DestroyTexture(g->white_image);
    g->white_image = NULL;
    SDL_DestroyTexture(g->yellow_image);
    g->yellow_image = NULL;
    SDL_DestroyTexture(g->player_image);
    g->player_image = NULL;
    SDL_DestroyTexture(g->background_image);
    g->background_image = NULL;
    SDL_DestroyRenderer(g->renderer);
    g->renderer = NULL;
    SDL_DestroyWindow(g->window);
    g->window = NULL;
    TTF_Quit();
    Mix_Quit();
    SDL_Quit();
    free(g);
    g = NULL;
    *game = NULL;
}

bool game_reset(struct Game *g) {

    flakes_reset(g->flakes, true);
    if (score_reset(g->score)) {
        return true;
    }
    if (Mix_PlayMusic(g->winter_music, -1)) {
        fprintf(stderr, "Error while playing music: %s\n", Mix_GetError());
        return true;
    }
    g->playing = true;

    return false;
}

bool handle_collision(struct Game *g, struct Flake *f) {
    if (f->is_white) {
        Mix_PlayChannel(-1, g->collect_sound, 0);
        if (score_increment(g->score)) {
            return true;
        }
        flake_reset(f, false);
    } else {
        Mix_HaltMusic();
        Mix_PlayChannel(-1, g->hit_sound, 0);
        g->playing = false;
    }
    return false;
}

bool check_collision(struct Game *g) {
    struct Flake *f = g->flakes;
    while (f) {
        if (flake_bottom(f) > player_top(g->player)) {
            if (flake_right(f) > player_left(g->player)) {
                if (flake_left(f) < player_right(g->player)) {
                    if (handle_collision(g, f)) {
                        return true;
                    }

                }
            }
        }
        f = f->next;
    }
    return false;
}

bool game_run(struct Game *g) {

    if (Mix_PlayMusic(g->winter_music, -1)) {
        fprintf(stderr, "Error while playing music: %s\n", Mix_GetError());
        return true;
    }

    while (true) {
        while (SDL_PollEvent(&g->event)) {
            switch (g->event.type) {
                case SDL_QUIT:
                    return false;
                    break;
                case SDL_KEYDOWN:
                    switch (g->event.key.keysym.scancode) {
                        case SDL_SCANCODE_ESCAPE:
                            return false;
                            break;
                        case SDL_SCANCODE_SPACE:
                            if (!g->playing) {
                                if (game_reset(g)) {
                                    return true;
                                }
                            }
                            break;
                        case SDL_SCANCODE_F:
                            fps_toggle_display(g->fps);
                            break;
                        default:
                            break;
                    }
                default:
                    break;
            }
        }

        if (g->playing) {
            player_update(g->player, g->delta_time);

            flakes_update(g->flakes, g->delta_time);

            if (check_collision(g)) {
                return true;
            }
        }

        if (SDL_RenderClear(g->renderer)) {
            fprintf(stderr, "Error while clearing renderer: %s\n", SDL_GetError());
            return true;
        }

        if ( SDL_RenderCopy(g->renderer, g->background_image, NULL, &g->background_rect)) {
            fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
            return true;
        }

        if (player_draw(g->player)) {
            return true;
        }

        if (flakes_draw(g->flakes)) {
            return true;
        }

        if (score_draw(g->score)) {
            return true;
        }

        SDL_RenderPresent(g->renderer);

        g->delta_time = fps_update(g->fps);
    }
    
    return false;
}