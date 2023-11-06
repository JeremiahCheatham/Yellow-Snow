VARIABLE score-image
CREATE score-rect SDL_Rect ALLOT
CREATE score-color SDL_Color ALLOT
24 CONSTANT score-font-size
VARIABLE score-font

: score-cleanup ( -- )
    score-font @ TTF_CloseFont
    score-image @ SDL_DestroyTexture
;

: score-init ( -- )
    score-color
    255 OVER SDL_Color-r C!
    255 OVER SDL_Color-g C!
    255 OVER SDL_Color-b C!
    255 SWAP SDL_Color-a C!

    s\" fonts/freesansbold.ttf\0" DROP score-font-size TTF_OpenFont score-font !
    score-font @ 0= IF
        ." Error creating font: " SDL_GetError c-str> TYPE CR
        TRUE
    ELSE
        \ score-font @ s\" 0\0" score-color TTF_RenderText_Blended DUP @ 0= IF
        \    ." Error creating font surface: " SDL_GetError c-str> TYPE CR
        \    DROP
        \    TRUE
        \ ELSE
        \    score-rect @ rect-from-surface
        \    10 score-rect SDL_Rect-x int32>!
        \    10 score-rect SDL_Rect-y int32>!
        \    score-image SWAP texture-from-surface IF
        \        TRUE
        \    ELSE
                FALSE
        \    THEN
        \ THEN
    THEN
;

: score-draw ( -- )
    renderer @ score-image @ 0 score-rect SDL_RenderCopy DROP
;

