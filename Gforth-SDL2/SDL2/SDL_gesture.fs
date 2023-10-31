\ ----===< prefix >===-----
c-library sdl_gesture
s" SDL2" add-lib
\c #include <SDL2/SDL_gesture.h>

\ ------===< functions >===-------
c-function SDL_RecordGesture SDL_RecordGesture n -- n	( touchId -- )
c-function SDL_SaveAllDollarTemplates SDL_SaveAllDollarTemplates a -- n	( dst -- )
c-function SDL_SaveDollarTemplate SDL_SaveDollarTemplate n a -- n	( gestureId dst -- )
c-function SDL_LoadDollarTemplates SDL_LoadDollarTemplates n a -- n	( touchId src -- )

\ ----===< postfix >===-----
end-c-library
