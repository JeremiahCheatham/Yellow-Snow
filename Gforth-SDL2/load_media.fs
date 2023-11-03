: create-texture-and-rect ( src texture rect -- error )
    ROT
    IMG_Load DUP 0= IF
        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
        DROP -1
    ELSE
        SWAP 0 OVER SDL_Rect-x l!
        0 OVER SDL_Rect-y l!
        OVER SDL_Surface-w l@ OVER SDL_Rect-w l!
        OVER SDL_Surface-h l@ SWAP SDL_Rect-h l!
        renderer @ OVER SDL_CreateTextureFromSurface DUP 0= IF
            ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
            DROP SDL_FreeSurface -1
        ELSE
            SWAP SDL_FreeSurface SWAP ! 0
        THEN
    THEN
;
