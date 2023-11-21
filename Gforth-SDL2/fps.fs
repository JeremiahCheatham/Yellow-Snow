60e FCONSTANT TARGET_FPS
VARIABLE delay-target 1000e TARGET_FPS F/ delay-target F!
VARIABLE delay-cap 20e delay-cap F!
VARIABLE delay-last SDL_GetTicks delay-last !
VARIABLE delay-elpsed
VARIABLE delay-carry
VARIABLE delay-current
VARIABLE fps-counter
VARIABLE fps-display FALSE fps-display !
VARIABLE fps-last-time SDL_GetTicks fps-last-time ! 
VARIABLE fps-elapsed-time
VARIABLE delta-time 0e delta-time F!


: fps-time-since ( fps-last-time -- elapsed-time )
    SDL_GetTicks DUP ROT 2DUP >= IF
        -
    ELSE
        0xFFFFFFFF SWAP - +
    THEN
    SWAP
;

: fps-toggle-display ( -- )
    fps-display @ 0= fps-display !
    0 fps-counter !
    SDL_GetTicks fps-last-time !
;

: fps-show ( -- )
    fps-display @ IF
        fps-counter @ 1+ fps-counter !
        fps-last-time @ fps-time-since DROP 1000 > IF
            fps-counter @ . CR
            0 fps-counter !
            fps-last-time @ 1000 + fps-last-time !
        THEN
    THEN
;

: delay-update ( -- )
    delay-last @ fps-time-since DROP delay-elpsed !
    delay-target F@ delay-carry F@ F+ delay-current F!
    delay-current F@ delay-elpsed @ S>F F> IF
        delay-current F@ F>S delay-elpsed @ - SDL_Delay
    THEN
    delay-last @ fps-time-since delay-last ! DUP delay-elpsed !
    
    delay-current F@ S>F F- delay-carry F!
    delay-carry F@ delay-cap F@ F> IF
        delay-cap F@ delay-carry F!
    THEN
    delay-carry F@ delay-cap F@ FNEGATE F< IF
        delay-cap F@ FNEGATE delay-carry F!
    THEN

    fps-show 

    delay-elpsed @ S>F 1000e F/
;

