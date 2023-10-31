\ ----===< prefix >===-----
c-library sdl_power
s" SDL2" add-lib
\c #include <SDL2/SDL_power.h>

\ --------===< enums >===---------
#0	constant SDL_POWERSTATE_UNKNOWN
#1	constant SDL_POWERSTATE_ON_BATTERY
#2	constant SDL_POWERSTATE_NO_BATTERY
#3	constant SDL_POWERSTATE_CHARGING
#4	constant SDL_POWERSTATE_CHARGED

\ ------===< functions >===-------
c-function SDL_GetPowerInfo SDL_GetPowerInfo a a -- n	( seconds percent -- )

\ ----===< postfix >===-----
end-c-library
