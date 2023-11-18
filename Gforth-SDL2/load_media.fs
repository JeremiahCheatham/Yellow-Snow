: load-texture-and-rect ( rect texture file -- error )
    renderer @ SWAP IMG_LoadTexture OVER !
    DUP @ 0= IF
        ." Error creating texuture from file: " IMG_GeTerror c-str> TYPE CR
        2DROP FALSE
    ELSE
        @ SWAP NULL NULL ROT DUP SDL_Rect-w SWAP SDL_Rect-h SDL_QueryTexture
        IF
            ." Error querying texuture for rect: " IMG_GeTerror c-str> TYPE CR
            FALSE
        ELSE
            TRUE
        THEN
    THEN
;

: rect-from-surface ( surface rect -- )
    0 OVER SDL_Rect-x int32>!
    0 OVER SDL_Rect-y int32>!
    OVER SDL_Surface-w int32<@ OVER SDL_Rect-w int32>!
    OVER SDL_Surface-h int32<@ SWAP SDL_Rect-h int32>!
;


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


