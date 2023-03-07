// Included header files.
#include "game.h"
#include "fps.h"

struct Game* game_new(SDL_Renderer *renderer) {
    struct Game *this = calloc(1, sizeof(struct Game));
    if (!this) {
        fprintf(stderr, "Error in malloc of game!\n");
        return this;
    }

    this->renderer = renderer;
    this->ground = 550;
    this->delta_time = 0;
    this->frame_delay = 1000.0f / FPS;
    this->show_fps = SHOW_FPS;
    this->playing = true;

    return this;
}

void game_free(struct Game *this) {
    // Free loaded Textures
    SDL_DestroyTexture(this->background_image);
    this->background_image = NULL;
    SDL_DestroyTexture(this->player_image);
    this->player_image = NULL;
    SDL_DestroyTexture(this->white_image);
    this->white_image = NULL;
    SDL_DestroyTexture(this->yellow_image);
    this->yellow_image = NULL;

    //Free audio objects
    Mix_HaltMusic();
    Mix_FreeMusic(this->music);
    this->music = NULL;
    Mix_FreeChunk(this->collect);
    this->collect = NULL;
    Mix_FreeChunk(this->hit);
    this->hit = NULL;

    // Free font
    TTF_CloseFont(this->font);
    this->font = NULL;

    // Free player, score, and flakes then game.
    if (this->player) {
        free(this->player);
        this->player = NULL;
    }
    if (this->score) {
        if (this->score->image) {
            SDL_DestroyTexture(this->score->image);
        }
        free(this->score);
        this->score = NULL;
    }
    struct Flake *current = this->flakes;
    while (current != NULL) {
        struct Flake *next = current->next;
        free(current);
        current = next;
    }
    this->flakes = NULL;
    free(this);
}

bool game_run(struct Game *this) {

    this->player = player_new(this->renderer, this->player_image);
    if (!this->player || this->player->error) {
        return false;
    }

    this->flakes = NULL;
    for(short unsigned i = 0; i < 10; i++) {
        if (!flake_new(&this->flakes, this->renderer, this->white_image, true) || this->flakes->error) {
            return false;
        }
    }
    for(short unsigned i = 0; i < 5; i++) {
        if (!flake_new(&this->flakes, this->renderer, this->yellow_image, false) || this->flakes->error) {
            return false;
        }
    }

    this->score = score_new(this->renderer, this->font);
    if (!this->score || this->score->error) {
        return false;
    }

    //Play the music
    Mix_PlayMusic(this->music, -1);

    while (true) {

        // Check key events, key pressed or released.
        while (SDL_PollEvent(&this->event)) {
            switch (this->event.type) {

                case SDL_QUIT:
                    // handling of close button
                    return true;
                case SDL_KEYDOWN:
                    // keyboard API for key pressed
                    switch (this->event.key.keysym.scancode) {
                        case SDL_SCANCODE_ESCAPE:
                            return true;
                        case SDL_SCANCODE_SPACE:
                            if (!this->playing) {
                                if (!score_reset(this->score)) {
                                    return false;
                                }
                                this->playing = true;
                                for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
                                    flake_reset(flake, true);
                                }
                                Mix_PlayMusic(this->music, -1);
                            }
                            break;
                        default:
                            break;
                    }
            }
        }

        if (this->playing) {
            player_update(this->player, this->delta_time);
            for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
                flake_update(flake, this->delta_time);
                if (flake->rect.y + flake->rect.h > this->ground) {
                    flake_reset(flake, false);
                } else if (flake_check_collide(&flake->rect, &this->player->hit_box)) {
                    if (flake->is_white) {
                        Mix_PlayChannel(-1, this->collect, 0);
                        flake_reset(flake, false);
                        score_increment(this->score);
                    } else {
                        Mix_HaltMusic();
                        Mix_PlayChannel(-1, this->hit, 0);
                        this->playing = false;
                    }
                }
            }
        }

        // Clear the existing renderer.
        if (SDL_RenderClear(this->renderer)) {
            fprintf(stderr, "Error while clearing renderer: %s\n", SDL_GetError());
            return false;
        }

        // Draw the images to the renderer.
        if ( SDL_RenderCopy(this->renderer, this->background_image, NULL, NULL)) {
            fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
            return false;
        }

        // Draw player to the renderer.
        if (!player_draw(this->player)) {
            return false;
        }

        // Draw flakes to the renderer.
        for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
            if (!flake_draw(flake)) {
                return false;
            }
        }

        // Draw score to the renderer.
        if (!score_draw(this->score)) {
            return false;
        }
        
        // Swap the back buffer to the front.
        SDL_RenderPresent(this->renderer);

        // Print FPS to standard output.
        if (this->show_fps)
            fps_print();

        // Calculate delay needed for the FPS.
        this->delta_time = fps_delay(this->frame_delay);
    }
    
    return true;
}