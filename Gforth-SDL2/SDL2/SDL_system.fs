\ ----===< prefix >===-----
c-library sdl_system
s" SDL2" add-lib
\c #include <SDL2/SDL_system.h>

\ ------===< functions >===-------
c-function SDL_IsTablet SDL_IsTablet  -- n	( -- )
c-function SDL_OnApplicationWillTerminate SDL_OnApplicationWillTerminate  -- void	( -- )
c-function SDL_OnApplicationDidReceiveMemoryWarning SDL_OnApplicationDidReceiveMemoryWarning  -- void	( -- )
c-function SDL_OnApplicationWillResignActive SDL_OnApplicationWillResignActive  -- void	( -- )
c-function SDL_OnApplicationDidEnterBackground SDL_OnApplicationDidEnterBackground  -- void	( -- )
c-function SDL_OnApplicationWillEnterForeground SDL_OnApplicationWillEnterForeground  -- void	( -- )
c-function SDL_OnApplicationDidBecomeActive SDL_OnApplicationDidBecomeActive  -- void	( -- )

\ ----===< postfix >===-----
end-c-library
