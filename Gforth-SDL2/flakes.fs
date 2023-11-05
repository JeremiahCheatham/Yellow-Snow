VARIABLE white-image
VARIABLE yellow-image
VARIABLE flake-speed 5 flake-speed !
VARIABLE white-length 10 white-length !
VARIABLE yellow-length 5 yellow-length !
CREATE white-array white-length @ SDL_Rect * ALLOT
CREATE yellow-array yellow-length @ SDL_Rect * ALLOT


: flakes-cleanup ( -- )
    white-image @ SDL_DestroyTexture
    yellow-image @ SDL_DestroyTexture
;

: flake-reset ( flake-address range -- )
    SWAP 0 OVER SDL_Rect-h int32<@ - ROT random - OVER SDL_Rect-y int32>!
    DUP SDL_Rect-w int32<@ SCREEN_WIDTH SWAP - random SWAP SDL_Rect-x int32>!
;

: flake-array-init ( array-adress length -- )
    0 DO
        DUP SDL_Rect I * +
        DUP SCREEN_HEIGHT 2 * flake-reset 
        OVER SDL_Rect-w int32<@ OVER SDL_Rect-w int32>!
        OVER SDL_Rect-h int32<@ SWAP SDL_Rect-h int32>!
    LOOP DROP
;

: flakes-init ( -- error )
    s\" images/white.png\0" DROP white-image white-array create-texture-and-rect
    IF
        TRUE
    ELSE
        s\" images/yellow.png\0" DROP yellow-image yellow-array create-texture-and-rect
        IF
            TRUE
        ELSE
            white-array white-length @ flake-array-init
            yellow-array yellow-length @ flake-array-init
            FALSE
        THEN
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

: flakes-array-update ( array-adress length -- )
    0 DO
        DUP SDL_Rect I * +
        DUP SDL_Rect-y int32<@ flake-speed @ + OVER SDL_Rect-y int32>!
        550 OVER flake-bottom < IF SCREEN_HEIGHT flake-reset ELSE DROP THEN
    LOOP DROP
;

: flakes-update ( -- )
    white-array white-length @ flakes-array-update
    yellow-array yellow-length @ flakes-array-update
;

: flakes-draw ( -- )
    white-length @ 0 DO
        renderer @ white-image @ 0 SDL_Rect I * white-array + SDL_RenderCopy DROP
    LOOP
    yellow-length @ 0 DO
        renderer @ yellow-image @ 0 SDL_Rect I * yellow-array + SDL_RenderCopy DROP
    LOOP

;
