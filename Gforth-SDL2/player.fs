VARIABLE player-image
CREATE player-rect SDL_Rect ALLOT
VARIABLE player-direction SDL_FLIP_NONE player-direction L!

: player-init ( -- error )
    s\" images/player.png\0" DROP player-image player-rect create-texture-and-rect
    IF
        -1
    ELSE
        377 player-rect SDL_Rect-y l!
        SCREEN_WIDTH player-rect SDL_Rect-w l@ - 2 / player-rect SDL_Rect-x l!
        0
    THEN
;

: player-cleanup ( -- )
    player-image @ SDL_DestroyTexture
;

: player-update ( -- )
    keystate SDL_Keysym-scancode @ SDL_SCANCODE_LEFT + C@ 1 = IF
        player-rect SDL_Rect-x L@ 5 - DUP 0 < IF DROP 0 THEN
        player-rect SDL_Rect-x L!
        SDL_FLIP_HORIZONTAL player-direction !
    THEN

    keystate SDL_Keysym-scancode @ SDL_SCANCODE_RIGHT + c@ 1 = IF
        player-rect SDL_Rect-x L@ 5 + DUP
        SCREEN_WIDTH player-rect SDL_Rect-w L@ - DUP
        ROT < IF SWAP THEN
        DROP player-rect SDL_Rect-x L!
        SDL_FLIP_NONE player-direction !
    THEN
;

: player-draw ( -- )
    renderer @ player-image @ 0 player-rect 0e 0 player-direction @ SDL_RenderCopyEX DROP
;
