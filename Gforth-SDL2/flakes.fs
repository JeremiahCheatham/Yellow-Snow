VARIABLE flake-image
VARIABLE flake-speed 5 flake-speed !
VARIABLE flakes-length 20 flakes-length !
CREATE flakes-array flakes-length @ SDL_Rect * ALLOT


: flakes-cleanup ( -- )
    flake-image @ SDL_DestroyTexture
;

: flake-reset ( a -- )
    0 OVER SDL_Rect-h int32<@ - SCREEN_HEIGHT random - OVER SDL_Rect-y int32>!
    DUP SDL_Rect-w int32<@ SCREEN_WIDTH SWAP - random SWAP SDL_Rect-x int32>!
;

: flakes-init ( -- error )
    s\" images/white.png\0" DROP flake-image flakes-array create-texture-and-rect
    IF
        TRUE
    ELSE
        flakes-length @ 0 DO
            SDL_Rect I * flakes-array +
            DUP flake-reset 
            flakes-array SDL_Rect-w int32<@ OVER SDL_Rect-w int32>!
            flakes-array SDL_Rect-h int32<@ SWAP SDL_Rect-h int32>!
        LOOP
        FALSE
    THEN
;

: flake-left ( a -- n )
    SDL_Rect-y int32<@
;

: flake-right ( a -- n )
    DUP SDL_Rect-x int32<@ SWAP SDL_Rect-w int32<@ +
;

: flake-bottom ( a -- n )
    DUP SDL_Rect-y int32<@ SWAP SDL_Rect-h int32<@ +
;

: flakes-update ( -- )
    flakes-length @ 0 DO
        SDL_Rect I * flakes-array +
        DUP SDL_Rect-y int32<@ flake-speed @ + OVER SDL_Rect-y int32>!
        550 OVER flake-bottom < IF flake-reset ELSE DROP THEN
    LOOP
;

: flakes-draw ( -- )
    flakes-length @ 0 DO
        renderer @ flake-image @ 0 SDL_Rect I * flakes-array + SDL_RenderCopy DROP
    LOOP
;
