VARIABLE white-image
VARIABLE yellow-image
5 CONSTANT flake-speed
10 CONSTANT white-length
5 CONSTANT yellow-length
CREATE white-array white-length SDL_Rect * ALLOT
CREATE yellow-array yellow-length SDL_Rect * ALLOT


: flakes-cleanup ( -- )
    white-image @ SDL_DestroyTexture
    yellow-image @ SDL_DestroyTexture
;

: flake-reset ( flake-address range -- )
    SWAP 0 OVER SDL_Rect-h int32<@ - ROT random - OVER SDL_Rect-y int32>!
    DUP SDL_Rect-w int32<@ SCREEN_WIDTH SWAP - random SWAP SDL_Rect-x int32>!
;

: flakes-array-init ( array-adress length -- )
    0 DO
        DUP SDL_Rect I * +
        OVER SDL_Rect-w int32<@ OVER SDL_Rect-w int32>!
        OVER SDL_Rect-h int32<@ SWAP SDL_Rect-h int32>!
    LOOP DROP
;

: flakes-array-reset ( array-adress length -- )
    0 DO
        DUP SDL_Rect I * +
        SCREEN_HEIGHT 2 * flake-reset 
    LOOP DROP
;

: flakes-init ( -- error )
    white-array white-image s" images/white.png" >c-str load-texture-and-rect
    IF
        yellow-array yellow-image s" images/yellow.png" >c-str load-texture-and-rect
        IF
            white-array white-length flakes-array-init
            yellow-array yellow-length flakes-array-init
            TRUE
        ELSE
            FALSE
        THEN
    ELSE
        FALSE
    THEN
;

: flake-left ( a -- n )
    SDL_Rect-x int32<@
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
        DUP SDL_Rect-y int32<@ flake-speed + OVER SDL_Rect-y int32>!
        550 OVER flake-bottom < IF SCREEN_HEIGHT flake-reset ELSE DROP THEN
    LOOP DROP
;

: flakes-update ( -- )
    white-array white-length flakes-array-update
    yellow-array yellow-length flakes-array-update
;

: flakes-draw ( -- )
    white-length 0 DO
        renderer @ white-image @ 0 SDL_Rect I * white-array + SDL_RenderCopy DROP
    LOOP
    yellow-length 0 DO
        renderer @ yellow-image @ 0 SDL_Rect I * yellow-array + SDL_RenderCopy DROP
    LOOP

;
