\ ----===< prefix >===-----
c-library sdl_assert
s" SDL2" add-lib
\c #include <SDL2/SDL_assert.h>

\ ----===< int constants >===-----
#2	constant SDL_ASSERT_LEVEL
#205	constant SDL_LINE
#0	constant SDL_NULL_WHILE_LOOP_CONDITION

\ --------===< enums >===---------
#0	constant SDL_ASSERTION_RETRY
#1	constant SDL_ASSERTION_BREAK
#2	constant SDL_ASSERTION_ABORT
#3	constant SDL_ASSERTION_IGNORE
#4	constant SDL_ASSERTION_ALWAYS_IGNORE

\ -------===< structs >===--------
\ struct SDL_AssertData
begin-structure SDL_AssertData
	drop 8 8 +field SDL_AssertData-condition
	drop 4 4 +field SDL_AssertData-trigger_count
	drop 16 8 +field SDL_AssertData-filename
	drop 32 8 +field SDL_AssertData-function
	drop 0 4 +field SDL_AssertData-always_ignore
	drop 40 8 +field SDL_AssertData-next
	drop 24 4 +field SDL_AssertData-linenum
drop 48 end-structure

\ ------===< functions >===-------
c-function SDL_ReportAssertion SDL_ReportAssertion a a a n -- n	( <noname> <noname> <noname> <noname> -- )
c-function SDL_SetAssertionHandler SDL_SetAssertionHandler a a -- void	( handler userdata -- )
c-function SDL_GetDefaultAssertionHandler SDL_GetDefaultAssertionHandler  -- a	( -- )
c-function SDL_GetAssertionHandler SDL_GetAssertionHandler a -- a	( puserdata -- )
c-function SDL_GetAssertionReport SDL_GetAssertionReport  -- a	( -- )
c-function SDL_ResetAssertionReport SDL_ResetAssertionReport  -- void	( -- )

\ ----===< postfix >===-----
end-c-library
