\ ----===< prefix >===-----
c-library sdl_platform
s" SDL2" add-lib
\c #include <SDL2/SDL_platform.h>

\ ------===< functions >===-------
c-function SDL_GetPlatform SDL_GetPlatform  -- a	( -- )

\ ----===< postfix >===-----
end-c-library
