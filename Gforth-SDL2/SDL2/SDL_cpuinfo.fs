\ ----===< prefix >===-----
c-library sdl_cpuinfo
s" SDL2" add-lib
\c #include <SDL2/SDL_cpuinfo.h>

\ ----===< int constants >===-----
#128	constant SDL_CACHELINE_SIZE

\ ------===< functions >===-------
c-function SDL_GetCPUCount SDL_GetCPUCount  -- n	( -- )
c-function SDL_GetCPUCacheLineSize SDL_GetCPUCacheLineSize  -- n	( -- )
c-function SDL_HasRDTSC SDL_HasRDTSC  -- n	( -- )
c-function SDL_HasAltiVec SDL_HasAltiVec  -- n	( -- )
c-function SDL_HasMMX SDL_HasMMX  -- n	( -- )
c-function SDL_Has3DNow SDL_Has3DNow  -- n	( -- )
c-function SDL_HasSSE SDL_HasSSE  -- n	( -- )
c-function SDL_HasSSE2 SDL_HasSSE2  -- n	( -- )
c-function SDL_HasSSE3 SDL_HasSSE3  -- n	( -- )
c-function SDL_HasSSE41 SDL_HasSSE41  -- n	( -- )
c-function SDL_HasSSE42 SDL_HasSSE42  -- n	( -- )
c-function SDL_HasAVX SDL_HasAVX  -- n	( -- )
c-function SDL_HasAVX2 SDL_HasAVX2  -- n	( -- )
c-function SDL_HasAVX512F SDL_HasAVX512F  -- n	( -- )
c-function SDL_HasARMSIMD SDL_HasARMSIMD  -- n	( -- )
c-function SDL_HasNEON SDL_HasNEON  -- n	( -- )
c-function SDL_HasLSX SDL_HasLSX  -- n	( -- )
c-function SDL_HasLASX SDL_HasLASX  -- n	( -- )
c-function SDL_GetSystemRAM SDL_GetSystemRAM  -- n	( -- )
c-function SDL_SIMDGetAlignment SDL_SIMDGetAlignment  -- n	( -- )
c-function SDL_SIMDAlloc SDL_SIMDAlloc n -- a	( len -- )
c-function SDL_SIMDRealloc SDL_SIMDRealloc a n -- a	( mem len -- )
c-function SDL_SIMDFree SDL_SIMDFree a -- void	( ptr -- )

\ ----===< postfix >===-----
end-c-library
