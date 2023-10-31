\ ----===< prefix >===-----
c-library sdl_loadso
s" SDL2" add-lib
\c #include <SDL2/SDL_loadso.h>

\ ------===< functions >===-------
c-function SDL_LoadObject SDL_LoadObject a -- a	( sofile -- )
c-function SDL_LoadFunction SDL_LoadFunction a a -- a	( handle name -- )
c-function SDL_UnloadObject SDL_UnloadObject a -- void	( handle -- )

\ ----===< postfix >===-----
end-c-library
