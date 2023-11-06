
: texture-from-surface ( texture surface -- error )
    renderer @ OVER SDL_CreateTextureFromSurface DUP @ 0= IF
        ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
        DROP SDL_FreeSurface
        TRUE
    ELSE
        SWAP SDL_FreeSurface SWAP !
        FALSE
    THEN
;

: rect-from-surface ( surface rect -- )
    0 OVER SDL_Rect-x int32>!
    0 OVER SDL_Rect-y int32>!
    OVER SDL_Surface-w int32<@ OVER SDL_Rect-w int32>!
    OVER SDL_Surface-h int32<@ SWAP SDL_Rect-h int32>!
;

: create-texture-and-rect ( src texture rect -- error )
    ROT
    IMG_Load DUP 0= IF
        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
        DROP
        TRUE
    ELSE
        SWAP rect-from-surface
        texture-from-surface IF
            TRUE
        ELSE
            FALSE
        THEN
    THEN
;

