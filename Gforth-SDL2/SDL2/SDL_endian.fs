require SDL_stdinc.fs

\ ----===< prefix >===-----
c-library sdl_endian
s" SDL2" add-lib
\c #include <SDL2/SDL_endian.h>

\ ----===< int constants >===-----
#1234	constant SDL_LIL_ENDIAN
#4321	constant SDL_BIG_ENDIAN
#1234	constant SDL_BYTEORDER
#1234	constant SDL_FLOATWORDORDER

\ ------===< functions >===-------
c-function SDL_Swap16 SDL_Swap16 n -- n	( x -- )
c-function SDL_Swap32 SDL_Swap32 n -- n	( x -- )
c-function SDL_Swap64 SDL_Swap64 n -- n	( x -- )
c-function SDL_SwapFloat SDL_SwapFloat r -- r	( x -- )

\ ----===< postfix >===-----
end-c-library
