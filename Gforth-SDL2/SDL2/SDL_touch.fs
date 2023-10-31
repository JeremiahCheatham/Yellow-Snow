\ ----===< prefix >===-----
c-library sdl_touch
s" SDL2" add-lib
\c #include <SDL2/SDL_touch.h>

\ --------===< enums >===---------
#-1	constant SDL_TOUCH_DEVICE_INVALID
#0	constant SDL_TOUCH_DEVICE_DIRECT
#1	constant SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE
#2	constant SDL_TOUCH_DEVICE_INDIRECT_RELATIVE

\ -------===< structs >===--------
\ struct SDL_Finger
begin-structure SDL_Finger
	drop 8 4 +field SDL_Finger-x
	drop 0 8 +field SDL_Finger-id
	drop 12 4 +field SDL_Finger-y
	drop 16 4 +field SDL_Finger-pressure
drop 24 end-structure

\ ------===< functions >===-------
c-function SDL_GetNumTouchDevices SDL_GetNumTouchDevices  -- n	( -- )
c-function SDL_GetTouchDevice SDL_GetTouchDevice n -- n	( index -- )
c-function SDL_GetTouchName SDL_GetTouchName n -- a	( index -- )
c-function SDL_GetTouchDeviceType SDL_GetTouchDeviceType n -- n	( touchID -- )
c-function SDL_GetNumTouchFingers SDL_GetNumTouchFingers n -- n	( touchID -- )
c-function SDL_GetTouchFinger SDL_GetTouchFinger n n -- a	( touchID index -- )

\ ----===< postfix >===-----
end-c-library
