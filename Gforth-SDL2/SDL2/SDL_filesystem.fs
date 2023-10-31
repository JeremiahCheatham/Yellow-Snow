\ ----===< prefix >===-----
c-library sdl_filesystem
s" SDL2" add-lib
\c #include <SDL2/SDL_filesystem.h>

\ ------===< functions >===-------
c-function SDL_GetBasePath SDL_GetBasePath  -- a	( -- )
c-function SDL_GetPrefPath SDL_GetPrefPath a a -- a	( org app -- )

\ ----===< postfix >===-----
end-c-library
