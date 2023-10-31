\ ----===< prefix >===-----
c-library sdl_timer
s" SDL2" add-lib
\c #include <SDL2/SDL_timer.h>

\ ------===< functions >===-------
c-function SDL_GetTicks SDL_GetTicks  -- n	( -- )
c-function SDL_GetTicks64 SDL_GetTicks64  -- n	( -- )
c-function SDL_GetPerformanceCounter SDL_GetPerformanceCounter  -- n	( -- )
c-function SDL_GetPerformanceFrequency SDL_GetPerformanceFrequency  -- n	( -- )
c-function SDL_Delay SDL_Delay n -- void	( ms -- )
c-function SDL_AddTimer SDL_AddTimer n a a -- n	( interval callback param -- )
c-function SDL_RemoveTimer SDL_RemoveTimer n -- n	( id -- )

\ ----===< postfix >===-----
end-c-library
