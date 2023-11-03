require sdl_init.fs
require load_media.fs
require background.fs
require player.fs

: game-cleanup ( -- )
    player-cleanup
    background-cleanup
    sdl-cleanup
;

: game-init ( -- )
    sdl-init
    background-init IF game-cleanup THEN
    player-init IF game-cleanup THEN
;

: game-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF DROP game-cleanup THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                DUP SDL_SCANCODE_ESCAPE = IF DROP game-cleanup THEN
                SDL_SCANCODE_SPACE = IF .s CR THEN
            THEN
        REPEAT

        player-update
        
        renderer @ SDL_RenderClear DROP

        background-draw
        player-draw

        renderer @ SDL_RenderPresent

        16 SDL_Delay
    FALSE UNTIL
;

: game-play ( -- )
    game-init
    game-loop
;
