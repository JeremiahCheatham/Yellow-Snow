VARIABLE background-image
CREATE background-rect SDL_Rect ALLOT

: background-init ( -- error )
    s\" images/background.png\0" DROP background-image background-rect create-texture-and-rect
;

: background-cleanup ( -- )
    background-image @ SDL_DestroyTexture
;

: background-draw ( -- )
    renderer @ background-image @ 0 background-rect SDL_RenderCopy DROP
;
