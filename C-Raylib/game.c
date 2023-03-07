// Included header files.
#include "game.h"

struct Game* game_new() {
    struct Game *this = calloc(1, sizeof(struct Game));
    if (!this) {
        fprintf(stderr, "Error in calloc of new game!\n");
        return this;
    }

    this->ground = 550;
    this->delta_time = 0;
    this->playing = true;

    this->player = NULL;
    this->flakes = NULL;
    this->score = NULL;
    return this;
}

void game_free(struct Game *this) {
    // Free loaded Textures
    UnloadTexture(this->background_image);
    UnloadTexture(this->player_image);
    UnloadTexture(this->white_image);
    UnloadTexture(this->yellow_image);

    // Free all Audio
    StopMusicStream(this->music);
    UnloadMusicStream(this->music);
    UnloadSound(this->collect);
    UnloadSound(this->hit);

    // Free font
    UnloadFont(this->font);

    // Free all heap allocations
    if (this->player) {
        free(this->player);
    }
    if (this->score) {
        if (this->score->score_str) {
            free(this->score->score_str);
        }
        free(this->score);
    }
    struct Flake *current = this->flakes;
    while (current != NULL) {
        struct Flake *next = current->next;
        free(current);
        current = next;
    }
    free(this);
}

bool game_run(struct Game *this) {
    //Play the music
    PlayMusicStream(this->music);

    this->player = player_new(&this->player_image);
    if (!this->player) {
        return false;
    }

    this->flakes = NULL;
    for(short unsigned i = 0; i < 10; i++) {
        if (!flake_new(&this->flakes, &this->white_image, true)) {
            return false;
        }
    }
    for(short unsigned i = 0; i < 5; i++) {
        if (!flake_new(&this->flakes, &this->yellow_image, false)) {
            return false;
        }
    }

    this->score = score_new(&this->font);
    if (!this->score || !this->score->score_str) {
        return false;
    }

    // Main game loop
    while (!WindowShouldClose()) {
        this->delta_time = GetFrameTime();

        UpdateMusicStream(this->music);

        if (this->playing) {
            player_update(this->player, this->delta_time);
            Rectangle p_rect = player_rect(this->player);
            for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
                flake_update(flake, this->delta_time);
                if (flake->y + flake->image->height > this->ground) {
                    flake_reset(flake, false);
                } else if (CheckCollisionRecs(p_rect, flake_rect(flake))) {
                    if (flake->is_white) {
                        PlaySound(this->collect);
                        flake_reset(flake, false);
                        score_increment(this->score);
                    } else {
                        StopMusicStream(this->music);
                        PlaySound(this->hit);
                        this->playing = false;
                    }
                }
            }
        } else {
            if (IsKeyPressed(KEY_SPACE)) {
                score_reset(this->score);
                this->playing = true;
                PlayMusicStream(this->music);
                for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
                    flake_reset(flake, true);
                }
            }
        }

        BeginDrawing();

        // Draw the background image
        DrawTexture(this->background_image, 0, 0, WHITE);

        player_draw(this->player);
        for(struct Flake *flake = this->flakes; flake != NULL; flake = flake->next) {
            flake_draw(flake);
        }

        score_draw(this->score);

        EndDrawing();
    }
    return true;
}