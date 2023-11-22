VARIABLE player-image
300e FCONSTANT player-speed
0 VALUE player-delta
47 CONSTANT player-left-offset
43 CONSTANT player-right-offset
10 CONSTANT player-top-offset
CREATE player-rect SDL_Rect ALLOT
CREATE player-xpos FLOAT ALLOT
CREATE player-ypos FLOAT ALLOT
SDL_FLIP_NONE VALUE player-direction

: player-cleanup ( -- )
    player-image @ SDL_DestroyTexture
;

: player-init ( -- error )
    player-rect player-image s" images/player.png" >c-str load-texture-and-rect
    IF
        377 DUP player-rect SDL_Rect-y int32>!
        S>F player-ypos F!
        SCREEN_WIDTH player-rect SDL_Rect-w int32<@ - 2 / DUP player-rect SDL_Rect-x int32>!
        S>F player-xpos F!
        TRUE
    ELSE
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

: player-width ( -- n )
    player-rect SDL_Rect-w int32<@
;

: player-update ( -- )
    0 TO player-delta
    keystate SDL_Keysym-scancode @ SDL_SCANCODE_LEFT + C@ 1 = IF
        player-delta 1- TO player-delta
    THEN

    keystate SDL_Keysym-scancode @ SDL_SCANCODE_RIGHT + C@ 1 = IF
        player-delta 1+ TO player-delta
    THEN

    player-delta 0< IF
        player-xpos DUP F@ player-speed delta-time F@ F* F- FDUP F!
        F>S DUP 0 player-left-offset - <
        IF
            DROP 0 player-left-offset -
            DUP S>F player-xpos F!
        THEN
        player-rect SDL_Rect-x int32>!
        SDL_FLIP_HORIZONTAL TO player-direction
    THEN

    player-delta 0> IF
        player-xpos DUP F@ player-speed delta-time F@ F* F+ FDUP F!
        F>S DUP SCREEN_WIDTH player-width - player-right-offset + DUP -ROT >
        IF
            SWAP DROP
            DUP S>F player-xpos F!
        ELSE DROP THEN
        player-rect SDL_Rect-x int32>!
        SDL_FLIP_NONE TO player-direction
    THEN
;

: player-draw ( -- )
    renderer @ player-image @ 0 player-rect 0e 0 player-direction SDL_RenderCopyEX DROP
;
