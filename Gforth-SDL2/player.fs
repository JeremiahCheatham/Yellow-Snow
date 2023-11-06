VARIABLE player-image
5 CONSTANT player-speed
VARIABLE player-delta
47 CONSTANT player-left-offset
43 CONSTANT player-right-offset
10 CONSTANT player-top-offset
CREATE player-rect SDL_Rect ALLOT
VARIABLE player-direction SDL_FLIP_NONE player-direction L!

: player-cleanup ( -- )
    player-image @ SDL_DestroyTexture
;

: player-init ( -- error )
    S\" images/player.png\0" DROP player-image player-rect create-texture-and-rect
    IF
        TRUE
    ELSE
        377 player-rect SDL_Rect-y int32>!
        SCREEN_WIDTH player-rect SDL_Rect-w int32<@ - 2 / player-rect SDL_Rect-x int32>!
        FALSE
    THEN
;

: player-left ( -- n )
    player-rect SDL_Rect-x int32<@ player-left-offset +
;

: player-right ( -- n )
    player-rect DUP SDL_Rect-x int32<@ SWAP SDL_Rect-w int32<@ + player-right-offset -
;

: player-top ( -- n )
    player-rect SDL_Rect-y int32<@ player-top-offset +
;


: player-update ( -- )
    0 player-delta !
    keystate SDL_Keysym-scancode @ SDL_SCANCODE_LEFT + C@ 1 = IF
        player-delta @ player-speed - player-delta !
    THEN

    keystate SDL_Keysym-scancode @ SDL_SCANCODE_RIGHT + C@ 1 = IF
        player-delta @ player-speed + player-delta !
    THEN

    player-delta @ 0 < IF
        player-rect SDL_Rect-x int32<@ player-delta @ +
        DUP 0 player-left-offset - < IF DROP 0 player-left-offset - THEN
        player-rect SDL_Rect-x int32>!
        SDL_FLIP_HORIZONTAL player-direction !
    THEN

    player-delta @ 0> IF
        player-rect SDL_Rect-x int32<@ player-delta @ + DUP
        SCREEN_WIDTH player-rect SDL_Rect-w int32<@ - player-right-offset + DUP
        ROT < IF SWAP THEN
        DROP player-rect SDL_Rect-x int32>!
        SDL_FLIP_NONE player-direction !
    THEN
;

: player-draw ( -- )
    renderer @ player-image @ 0 player-rect 0e 0 player-direction @ SDL_RenderCopyEX DROP
;
