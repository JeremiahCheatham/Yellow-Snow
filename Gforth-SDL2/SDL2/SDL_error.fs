require SDL_stdinc.fs

\ ----===< prefix >===-----
c-library sdl_error
s" SDL2" add-lib
\c #include <SDL2/SDL_error.h>

\ ----===< int constants >===-----

\ --------===< enums >===---------
#0	constant SDL_ENOMEM
#1	constant SDL_EFREAD
#2	constant SDL_EFWRITE
#3	constant SDL_EFSEEK
#4	constant SDL_UNSUPPORTED
#5	constant SDL_LASTERROR

\ ------===< functions >===-------
\ c-function SDL_SetError SDL_SetError a ... -- n	( fmt <noname> -- )
c-function SDL_GetError SDL_GetError  -- a	( -- )
c-function SDL_GetErrorMsg SDL_GetErrorMsg a n -- a	( errstr maxlen -- )
c-function SDL_ClearError SDL_ClearError  -- void	( -- )
c-function SDL_Error SDL_Error n -- n	( code -- )

\ ----===< postfix >===-----
end-c-library
