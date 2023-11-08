require sdl_init.fs
require load_media.fs
require background.fs
require flakes.fs
require player.fs
require score.fs

VARIABLE winter-music
VARIABLE collect-sound
VARIABLE hit-sound
VARIABLE playing TRUE playing !

\ seed the random generator
utime DROP seed ! rnd DROP

: game-cleanup ( -- )
    winter-music @ Mix_FreeMusic
    collect-sound @ Mix_FreeChunk
    hit-sound @ Mix_FreeChunk
    score-cleanup
    player-cleanup
    flakes-cleanup
    background-cleanup
    sdl-cleanup
;

: game-reset ( -- )
    white-array white-length flakes-array-reset
    yellow-array yellow-length flakes-array-reset
    TRUE playing !
    score-reset IF game-cleanup THEN
    winter-music @ -1 Mix_PlayMusic IF
        ." Error while playing music: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN
;

: game-init ( -- )
    sdl-init
    background-init IF game-cleanup THEN
    flakes-init IF game-cleanup THEN
    player-init IF game-cleanup THEN
    score-init IF game-cleanup THEN

    s\" music/winter_loop.ogg\0" DROP Mix_LoadMUS winter-music !
    winter-music @ 0= IF
        ." Error loading music: " SDL_GetError c-str> TYPE CR
        game-cleanup
    THEN

    s\" sounds/collect.ogg\0" DROP Mix_LoadWAV collect-sound !
    collect-sound @ 0= IF
        ." Error loading sound effect: " SDL_GetError c-str> TYPE CR
        game-cleanup
    THEN

    s\" sounds/hit.ogg\0" DROP Mix_LoadWAV hit-sound !
    hit-sound @ 0= IF
        ." Error loading sound effect: " SDL_GetError c-str> TYPE CR
        game-cleanup
    THEN

    game-reset
;

: check-white-collision ( -- )
    white-array white-length 0 DO
        DUP SDL_Rect I * +
        DUP flake-bottom player-top > IF
            DUP flake-right player-left > IF
                DUP flake-left player-right < IF
                    DUP SCREEN_HEIGHT flake-reset
                    score-increment IF game-cleanup THEN
                    -1 collect-sound @ 0 Mix_PlayChannel DROP
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
                    Mix_HaltMusic DROP
                    -1 hit-sound @ 0 Mix_PlayChannel DROP
                THEN
            THEN
        THEN DROP
    LOOP DROP
;


: game-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF DROP game-cleanup THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                DUP SDL_SCANCODE_ESCAPE = IF DROP game-cleanup THEN
                SDL_SCANCODE_SPACE = IF
                    .s CR
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
