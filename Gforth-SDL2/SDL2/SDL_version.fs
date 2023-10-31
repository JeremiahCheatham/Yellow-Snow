\ ----===< prefix >===-----
c-library sdl_version
s" SDL2" add-lib
\c #include <SDL2/SDL_version.h>

\ ----===< int constants >===-----
#2	constant SDL_MAJOR_VERSION
#28	constant SDL_MINOR_VERSION
#0	constant SDL_PATCHLEVEL
#4800	constant SDL_COMPILEDVERSION

\ -------===< structs >===--------
\ struct SDL_version
begin-structure SDL_version
	drop 0 1 +field SDL_version-major
	drop 1 1 +field SDL_version-minor
	drop 2 1 +field SDL_version-patch
drop 3 end-structure

\ ------===< functions >===-------
c-function SDL_GetVersion SDL_GetVersion a -- void	( ver -- )
c-function SDL_GetRevision SDL_GetRevision  -- a	( -- )
\ c-function SDL_GetRevisionNumber SDL_GetRevisionNumber  -- n	( -- )

\ ----===< postfix >===-----
end-c-library
