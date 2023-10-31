\ ----===< prefix >===-----
c-library sdl_keyboard
s" SDL2" add-lib
\c #include <SDL2/SDL_keyboard.h>

\ -------===< structs >===--------
\ struct SDL_Keysym
begin-structure SDL_Keysym
	drop 0 4 +field SDL_Keysym-scancode
	drop 4 4 +field SDL_Keysym-sym
	drop 12 4 +field SDL_Keysym-unused
	drop 8 2 +field SDL_Keysym-mod
drop 16 end-structure

\ ------===< functions >===-------
c-function SDL_GetKeyboardFocus SDL_GetKeyboardFocus  -- a	( -- )
c-function SDL_GetKeyboardState SDL_GetKeyboardState a -- a	( numkeys -- )
c-function SDL_ResetKeyboard SDL_ResetKeyboard  -- void	( -- )
c-function SDL_GetModState SDL_GetModState  -- n	( -- )
c-function SDL_SetModState SDL_SetModState n -- void	( modstate -- )
c-function SDL_GetKeyFromScancode SDL_GetKeyFromScancode n -- n	( scancode -- )
c-function SDL_GetScancodeFromKey SDL_GetScancodeFromKey n -- n	( key -- )
c-function SDL_GetScancodeName SDL_GetScancodeName n -- a	( scancode -- )
c-function SDL_GetScancodeFromName SDL_GetScancodeFromName a -- n	( name -- )
c-function SDL_GetKeyName SDL_GetKeyName n -- a	( key -- )
c-function SDL_GetKeyFromName SDL_GetKeyFromName a -- n	( name -- )
c-function SDL_StartTextInput SDL_StartTextInput  -- void	( -- )
c-function SDL_IsTextInputActive SDL_IsTextInputActive  -- n	( -- )
c-function SDL_StopTextInput SDL_StopTextInput  -- void	( -- )
c-function SDL_ClearComposition SDL_ClearComposition  -- void	( -- )
c-function SDL_IsTextInputShown SDL_IsTextInputShown  -- n	( -- )
c-function SDL_SetTextInputRect SDL_SetTextInputRect a -- void	( rect -- )
c-function SDL_HasScreenKeyboardSupport SDL_HasScreenKeyboardSupport  -- n	( -- )
c-function SDL_IsScreenKeyboardShown SDL_IsScreenKeyboardShown a -- n	( window -- )

\ ----===< postfix >===-----
end-c-library
