\ ----===< prefix >===-----
c-library sdl_clipboard
s" SDL2" add-lib
\c #include <SDL2/SDL_clipboard.h>

\ ------===< functions >===-------
c-function SDL_SetClipboardText SDL_SetClipboardText a -- n	( text -- )
c-function SDL_GetClipboardText SDL_GetClipboardText  -- a	( -- )
c-function SDL_HasClipboardText SDL_HasClipboardText  -- n	( -- )
c-function SDL_SetPrimarySelectionText SDL_SetPrimarySelectionText a -- n	( text -- )
c-function SDL_GetPrimarySelectionText SDL_GetPrimarySelectionText  -- a	( -- )
c-function SDL_HasPrimarySelectionText SDL_HasPrimarySelectionText  -- n	( -- )

\ ----===< postfix >===-----
end-c-library
