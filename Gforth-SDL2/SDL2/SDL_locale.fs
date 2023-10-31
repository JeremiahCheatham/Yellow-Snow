\ ----===< prefix >===-----
c-library sdl_locale
s" SDL2" add-lib
\c #include <SDL2/SDL_locale.h>

\ -------===< structs >===--------
\ struct SDL_Locale
begin-structure SDL_Locale
	drop 8 8 +field SDL_Locale-country
	drop 0 8 +field SDL_Locale-language
drop 16 end-structure

\ ------===< functions >===-------
c-function SDL_GetPreferredLocales SDL_GetPreferredLocales  -- a	( -- )

\ ----===< postfix >===-----
end-c-library
