\ ----===< prefix >===-----
c-library sdl_log
s" SDL2" add-lib
\c #include <SDL2/SDL_log.h>

\ ----===< int constants >===-----
#4096	constant SDL_MAX_LOG_MESSAGE

\ --------===< enums >===---------
#0	constant SDL_LOG_CATEGORY_APPLICATION
#1	constant SDL_LOG_CATEGORY_ERROR
#2	constant SDL_LOG_CATEGORY_ASSERT
#3	constant SDL_LOG_CATEGORY_SYSTEM
#4	constant SDL_LOG_CATEGORY_AUDIO
#5	constant SDL_LOG_CATEGORY_VIDEO
#6	constant SDL_LOG_CATEGORY_RENDER
#7	constant SDL_LOG_CATEGORY_INPUT
#8	constant SDL_LOG_CATEGORY_TEST
#9	constant SDL_LOG_CATEGORY_RESERVED1
#10	constant SDL_LOG_CATEGORY_RESERVED2
#11	constant SDL_LOG_CATEGORY_RESERVED3
#12	constant SDL_LOG_CATEGORY_RESERVED4
#13	constant SDL_LOG_CATEGORY_RESERVED5
#14	constant SDL_LOG_CATEGORY_RESERVED6
#15	constant SDL_LOG_CATEGORY_RESERVED7
#16	constant SDL_LOG_CATEGORY_RESERVED8
#17	constant SDL_LOG_CATEGORY_RESERVED9
#18	constant SDL_LOG_CATEGORY_RESERVED10
#19	constant SDL_LOG_CATEGORY_CUSTOM
#1	constant SDL_LOG_PRIORITY_VERBOSE
#2	constant SDL_LOG_PRIORITY_DEBUG
#3	constant SDL_LOG_PRIORITY_INFO
#4	constant SDL_LOG_PRIORITY_WARN
#5	constant SDL_LOG_PRIORITY_ERROR
#6	constant SDL_LOG_PRIORITY_CRITICAL
#7	constant SDL_NUM_LOG_PRIORITIES

\ ------===< functions >===-------
c-function SDL_LogSetAllPriority SDL_LogSetAllPriority n -- void	( priority -- )
c-function SDL_LogSetPriority SDL_LogSetPriority n n -- void	( category priority -- )
c-function SDL_LogGetPriority SDL_LogGetPriority n -- n	( category -- )
c-function SDL_LogResetPriorities SDL_LogResetPriorities  -- void	( -- )
\ c-function SDL_Log SDL_Log a ... -- void	( fmt <noname> -- )
\ c-function SDL_LogVerbose SDL_LogVerbose n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogDebug SDL_LogDebug n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogInfo SDL_LogInfo n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogWarn SDL_LogWarn n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogError SDL_LogError n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogCritical SDL_LogCritical n a ... -- void	( category fmt <noname> -- )
\ c-function SDL_LogMessage SDL_LogMessage n n a ... -- void	( category priority fmt <noname> -- )
\ c-function SDL_LogMessageV SDL_LogMessageV n n a n -- void	( category priority fmt ap -- )
c-function SDL_LogGetOutputFunction SDL_LogGetOutputFunction a a -- void	( callback userdata -- )
c-function SDL_LogSetOutputFunction SDL_LogSetOutputFunction a a -- void	( callback userdata -- )

\ ----===< postfix >===-----
end-c-library
