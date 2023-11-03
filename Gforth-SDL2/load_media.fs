: create-texture-and-rect ( -- )
    ROT
    IMG_Load DUP 0= IF
        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
        DROP clean-and-exit
    THEN
    SWAP 0 OVER SDL_Rect-x l!
    0 OVER SDL_Rect-y l!
    OVER SDL_Surface-w l@ OVER SDL_Rect-w l!
    OVER SDL_Surface-h l@ SWAP SDL_Rect-h l!
    renderer @ OVER SDL_CreateTextureFromSurface DUP 0= IF
        ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
        DROP SDL_FreeSurface clean-and-exit
    THEN SWAP SDL_FreeSurface SWAP ! ;


