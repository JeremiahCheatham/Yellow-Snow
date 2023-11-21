VARIABLE white-image
VARIABLE yellow-image
300e FCONSTANT flake-speed
10 CONSTANT white-length
5 CONSTANT yellow-length
CREATE white-array white-length SDL_Rect * ALLOT
CREATE yellow-array yellow-length SDL_Rect * ALLOT
CREATE white-farray white-length 2 * CELLS ALLOT
CREATE yellow-farray yellow-length 2 * CELLS ALLOT
white-farray white-length 2 * CELLS 0 FILL
yellow-farray yellow-length 2 * CELLS 0 FILL

: flakes-cleanup ( -- )
    white-image @ SDL_DestroyTexture
    yellow-image @ SDL_DestroyTexture
;

: flake-reset { address faddress range -- }
    SCREEN_WIDTH address SDL_Rect-w int32<@ - random DUP address SDL_Rect-x int32>!
    S>F faddress F!
    0 address SDL_Rect-h int32<@ - range random - DUP address SDL_Rect-y int32>!
    S>F faddress CELL + F!
    
;

: flakes-array-init ( array-adress length -- )
    0 DO
        DUP SDL_Rect I * +
        OVER SDL_Rect-w int32<@ OVER SDL_Rect-w int32>!
        OVER SDL_Rect-h int32<@ SWAP SDL_Rect-h int32>!
    LOOP DROP
;

: flakes-array-reset { array farray length -- }
    length 0 DO
        array SDL_Rect I * +
        farray 2 I * FLOATS +
        SCREEN_HEIGHT 2 * flake-reset
    LOOP
;

: flakes-reset ( -- )
    white-array white-farray white-length flakes-array-reset
    yellow-array yellow-farray yellow-length flakes-array-reset
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

: flakes-array-update { array farray range -- }
    range 0 DO
        array SDL_Rect I * +
        farray I 2 * CELLS +
        DUP CELL + { flake xpos ypos }
        ypos F@ flake-speed delta-time F@ F* F+ FDUP ypos F!
        F>S flake SDL_Rect-y int32>!
        550 flake flake-bottom < IF flake xpos SCREEN_HEIGHT flake-reset THEN
    LOOP
;

: flakes-update ( -- )
    white-array white-farray white-length flakes-array-update
    yellow-array yellow-farray yellow-length flakes-array-update
;

: flakes-draw ( -- )
    white-length 0 DO
        renderer @ white-image @ 0 SDL_Rect I * white-array + SDL_RenderCopy DROP
    LOOP
    yellow-length 0 DO
        renderer @ yellow-image @ 0 SDL_Rect I * yellow-array + SDL_RenderCopy DROP
    LOOP

;
