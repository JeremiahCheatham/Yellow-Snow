\ ----===< prefix >===-----
c-library sdl_guid
s" SDL2" add-lib
\c #include <SDL2/SDL_guid.h>

\ ----===< int constants >===-----

\ -------===< structs >===--------
\ SDL_GUID
begin-structure SDL_GUID
	drop 0 16 +field SDL_GUID-data
drop 16 end-structure

\ ------===< functions >===-------
\ c-function SDL_GUIDToString SDL_GUIDToString a{*(SDL_GUID*)} a n -- void	( guid pszGUID cbGUID -- )
\ c-function SDL_GUIDFromString SDL_GUIDFromString a -- struct	( pchGUID -- )

\ ----===< postfix >===-----
end-c-library
