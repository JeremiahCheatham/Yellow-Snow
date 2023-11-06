require sdl_init.fs
require load_media.fs
require background.fs
require flakes.fs
require player.fs
require score.fs

VARIABLE playing TRUE playing !
VARIABLE score 0 score !

\ seed the random generator
utime DROP seed ! rnd DROP

: game-cleanup ( -- )
    score-cleanup
    player-cleanup
    flakes-cleanup
    background-cleanup
    sdl-cleanup
;

: game-init ( -- )
    sdl-init
    background-init IF game-cleanup THEN
    flakes-init IF game-cleanup THEN
    player-init IF game-cleanup THEN
    score-init IF game-cleanup THEN
;

: check-white-collision ( -- )
    white-array white-length 0 DO
        DUP SDL_Rect I * +
        DUP flake-bottom player-top > IF
            DUP flake-right player-left > IF
                DUP flake-left player-right < IF
                    DUP SCREEN_HEIGHT flake-reset
                    score @ 1 + score !
                    score @ . CR
                THEN
            THEN
        THEN DROP
    LOOP DROP
;

: check-yellow-collision ( -- )
    yellow-array yellow-length 0 DO
        DUP SDL_Rect I * +
        DUP flake-bottom player-top > IF
            DUP flake-right player-left > IF
                DUP flake-left player-right < IF
                    FALSE playing !
                THEN
            THEN
        THEN DROP
    LOOP DROP
;

: game-reset ( -- )
    white-array white-length flakes-array-reset
    yellow-array yellow-length flakes-array-reset
    TRUE playing !
    0 score !
    score @ . CR
;

: game-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF DROP game-cleanup THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                DUP SDL_SCANCODE_ESCAPE = IF DROP game-cleanup THEN
                SDL_SCANCODE_SPACE = IF
                    playing @ 0= IF
                        game-reset
                    THEN
                THEN
            THEN
        REPEAT
        
        playing @ IF
            player-update
            flakes-update
            check-white-collision
            check-yellow-collision
        THEN

        renderer @ SDL_RenderClear DROP

        background-draw
        player-draw
        flakes-draw
        score-draw

        renderer @ SDL_RenderPresent

        16 SDL_Delay
    FALSE UNTIL
;

: game-play ( -- )
    game-init
    game-loop
;
