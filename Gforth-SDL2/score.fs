VARIABLE score-image
CREATE score-rect SDL_Rect ALLOT
CREATE score-color SDL_Color ALLOT
24 CONSTANT score-font-size
VARIABLE score-font
VARIABLE score 0 score !

: score-cleanup ( -- )
    score-font @ TTF_CloseFont
    score-image @ SDL_DestroyTexture
;

: score-update ( -- error )
    score-image @ SDL_DestroyTexture
    0 score-image !
    score-font @
    s" Score: " PAD PLACE
    score @ 0 <<# #s #> #>> PAD +PLACE
    s\" \0" PAD +PLACE
    PAD COUNT DROP
    score-color TTF_RenderText_Blended DUP @ 0= IF
        ." Error creating font surface: " SDL_GetError c-str> TYPE CR
        DROP
        TRUE
    ELSE
        score-rect rect-from-surface
        10 score-rect SDL_Rect-x int32>!
        10 score-rect SDL_Rect-y int32>!
        score-image SWAP texture-from-surface IF
            TRUE
        ELSE
            FALSE
        THEN
    THEN
;

: score-reset ( -- error )
    0 score !
    score-update
;

: score-increment ( -- error )
    1 score @ + score !
    score-update
;

: score-init ( -- error )
    score-color
    255 OVER SDL_Color-r C!
    255 OVER SDL_Color-g C!
    255 OVER SDL_Color-b C!
    255 SWAP SDL_Color-a C!

    s" fonts/freesansbold.ttf" >c-str score-font-size TTF_OpenFont score-font !
    score-font @ 0= IF
        ." Error creating font: " SDL_GetError c-str> TYPE CR
        FALSE
    ELSE
        score-update IF
            FALSE
        ELSE
            TRUE
        THEN
    THEN
;

: score-draw ( -- )
    renderer @ score-image @ 0 score-rect SDL_RenderCopy DROP
;

