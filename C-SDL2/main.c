#include "main.h"
#include "game.h"

int main() {
    bool err = false;

    struct Game *game = NULL;
    
    err = game_new(&game);
    if (!err) {
        err = game_run(game);
    }

    game_free(&game);

    return err;
}