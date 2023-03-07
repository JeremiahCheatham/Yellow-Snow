// Included header files.
#include "main.h"
#include "init_raylib.h"
#include "game.h"
#include "media.h"

int main() {
    if (!init_raylib()) {
        close_raylib();
        return 1;
    }

    struct Game *game = game_new();
    if (!game) {
        close_raylib();
        return 1;
    }

    int exit_val = 1;
    if (media_load(game)) {
        if (game_run(game)) {
            exit_val = 0;
        }
    }
    
    game_free(game);
    close_raylib();
    return exit_val;
}