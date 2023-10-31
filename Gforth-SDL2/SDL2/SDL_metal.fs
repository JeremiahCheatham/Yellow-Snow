\ ----===< prefix >===-----
c-library sdl_metal
s" SDL2" add-lib
\c #include <SDL2/SDL_metal.h>

\ ------===< functions >===-------
c-function SDL_Metal_CreateView SDL_Metal_CreateView a -- a	( window -- )
c-function SDL_Metal_DestroyView SDL_Metal_DestroyView a -- void	( view -- )
c-function SDL_Metal_GetLayer SDL_Metal_GetLayer a -- a	( view -- )
c-function SDL_Metal_GetDrawableSize SDL_Metal_GetDrawableSize a a a -- void	( window w h -- )

\ ----===< postfix >===-----
end-c-library
