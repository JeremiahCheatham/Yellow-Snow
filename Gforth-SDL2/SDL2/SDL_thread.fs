require SDL_stdinc.fs
require SDL_error.fs
require SDL_atomic.fs
require SDL_mutex.fs

\ ----===< prefix >===-----
c-library sdl_thread
s" SDL2" add-lib
\c #include <SDL2/SDL_thread.h>

\ ----===< int constants >===-----

\ --------===< enums >===---------
#0	constant SDL_THREAD_PRIORITY_LOW
#1	constant SDL_THREAD_PRIORITY_NORMAL
#2	constant SDL_THREAD_PRIORITY_HIGH
#3	constant SDL_THREAD_PRIORITY_TIME_CRITICAL

\ ------===< functions >===-------
c-function SDL_CreateThread SDL_CreateThread a a a -- a	( fn name data -- )
c-function SDL_CreateThreadWithStackSize SDL_CreateThreadWithStackSize a a n a -- a	( fn name stacksize data -- )
c-function SDL_GetThreadName SDL_GetThreadName a -- a	( thread -- )
c-function SDL_ThreadID SDL_ThreadID  -- n	( -- )
c-function SDL_GetThreadID SDL_GetThreadID a -- n	( thread -- )
c-function SDL_SetThreadPriority SDL_SetThreadPriority n -- n	( priority -- )
c-function SDL_WaitThread SDL_WaitThread a a -- void	( thread status -- )
c-function SDL_DetachThread SDL_DetachThread a -- void	( thread -- )
c-function SDL_TLSCreate SDL_TLSCreate  -- n	( -- )
c-function SDL_TLSGet SDL_TLSGet n -- a	( id -- )
c-function SDL_TLSSet SDL_TLSSet n a a -- n	( id value destructor -- )
c-function SDL_TLSCleanup SDL_TLSCleanup  -- void	( -- )

\ ----===< postfix >===-----
end-c-library
