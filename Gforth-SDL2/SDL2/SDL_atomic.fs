\ ----===< prefix >===-----
c-library sdl_atomic
s" SDL2" add-lib
\c #include <SDL2/SDL_atomic.h>

\ -------===< structs >===--------
\ SDL_atomic_t
begin-structure SDL_atomic_t
	drop 0 4 +field SDL_atomic_t-value
drop 4 end-structure

\ ------===< functions >===-------
c-function SDL_AtomicTryLock SDL_AtomicTryLock a -- n	( lock -- )
c-function SDL_AtomicLock SDL_AtomicLock a -- void	( lock -- )
c-function SDL_AtomicUnlock SDL_AtomicUnlock a -- void	( lock -- )
c-function SDL_MemoryBarrierReleaseFunction SDL_MemoryBarrierReleaseFunction  -- void	( -- )
c-function SDL_MemoryBarrierAcquireFunction SDL_MemoryBarrierAcquireFunction  -- void	( -- )
c-function SDL_AtomicCAS SDL_AtomicCAS a n n -- n	( a oldval newval -- )
c-function SDL_AtomicSet SDL_AtomicSet a n -- n	( a v -- )
c-function SDL_AtomicGet SDL_AtomicGet a -- n	( a -- )
c-function SDL_AtomicAdd SDL_AtomicAdd a n -- n	( a v -- )
c-function SDL_AtomicCASPtr SDL_AtomicCASPtr a a a -- n	( a oldval newval -- )
c-function SDL_AtomicSetPtr SDL_AtomicSetPtr a a -- a	( a v -- )
c-function SDL_AtomicGetPtr SDL_AtomicGetPtr a -- a	( a -- )

\ ----===< postfix >===-----
end-c-library
