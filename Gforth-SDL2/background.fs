VARIABLE background-image
CREATE background-rect SDL_Rect ALLOT

: background-init ( -- error )
    background-rect background-image s" images/background.png" >c-str load-texture-and-rect
;

: background-cleanup ( -- )
    background-image @ SDL_DestroyTexture
;

: background-draw ( -- )
    renderer @ background-image @ 0 background-rect SDL_RenderCopy DROP
;
