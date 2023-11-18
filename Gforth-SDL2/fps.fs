60e FCONSTANT TARGET_FPS
VARIABLE delay-target 1000e TARGET_FPS f/ delay-target f!
VARIABLE delay-cap TARGET_FPS 30e f/ delay-cap f!
VARIABLE delay-last SDL_GetTicks delay-last !
VARIABLE delay-elpsed
VARIABLE delay-carry
VARIABLE delay-current
VARIABLE fps-counter
VARIABLE fps-display FALSE fps-display !
VARIABLE fps-last-time SDL_GetTicks fps-last-time ! 
VARIABLE fps-elapsed-time

: fps-time-since ( fps-last-time -- elapsed-time )
    SDL_GetTicks DUP ROT 2DUP <= IF
        -
    ELSE
        0xFFFFFFFF SWAP - +
    THEN
    SWAP
;

: fps-toggle-display ( -- )
    fps-display @ 0= fps-display !
    0 fps-counter !
    SDL_GetTicks 1000 + fps-last-time !
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
    \ delay-target delay-carry + delay-current !
    \ delay-current F@ delay-elpsed @ > IF
    \     delay-current @ delay-elpsed @ - SDL_Delay
    \ THEN
    \ delay-last @ fps-time-since delay-last ! delay-elpsed !
;
    \ f->carry_delay = delay - elapsed_time;
    \ if (f->carry_delay > f->cap_delay) {
    \     f->carry_delay = f->cap_delay;
    \ } else if (f->carry_delay < -f->cap_delay) {
    \     f->carry_delay = -f->cap_delay;
    \ }

    \ if (f->fps_display) {
	\ 	f->fps_counter++;
	\ 	if (fps_time_since(f->fps_last_time, NULL) > 1000) {
	\ 		printf("%i\n", f->fps_counter);
	\ 		f->fps_counter = 0;
	\ 		f->fps_last_time += 1000;
	\ 	}
	\ }

    \ return (double)elapsed_time / 1000;
