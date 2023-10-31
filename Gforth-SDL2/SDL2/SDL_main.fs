\ ----===< prefix >===-----
c-library sdl_main
s" SDL2" add-lib
\c #include <SDL2/SDL_main.h>

\ ----===< int constants >===-----

\ ------===< functions >===-------
c-function SDL_main SDL_main n a -- n	( argc argv -- )
c-function SDL_SetMainReady SDL_SetMainReady  -- void	( -- )

\ ----===< postfix >===-----
end-c-library
