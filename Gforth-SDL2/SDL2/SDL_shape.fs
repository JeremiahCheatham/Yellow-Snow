\ ----===< prefix >===-----
c-library sdl_shape
s" SDL2" add-lib
\c #include <SDL2/SDL_shape.h>

\ ----===< int constants >===-----
#-1	constant SDL_NONSHAPEABLE_WINDOW
#-2	constant SDL_INVALID_SHAPE_ARGUMENT
#-3	constant SDL_WINDOW_LACKS_SHAPE

\ --------===< enums >===---------
#0	constant ShapeModeDefault
#1	constant ShapeModeBinarizeAlpha
#2	constant ShapeModeReverseBinarizeAlpha
#3	constant ShapeModeColorKey

\ -------===< structs >===--------
\ SDL_WindowShapeParams
begin-structure SDL_WindowShapeParams
	drop 0 4 +field SDL_WindowShapeParams-colorKey
	drop 0 1 +field SDL_WindowShapeParams-binarizationCutoff
drop 4 end-structure
\ struct SDL_WindowShapeMode
begin-structure SDL_WindowShapeMode
	drop 4 4 +field SDL_WindowShapeMode-parameters
	drop 0 4 +field SDL_WindowShapeMode-mode
drop 8 end-structure

\ ------===< functions >===-------
c-function SDL_CreateShapedWindow SDL_CreateShapedWindow a n n n n n -- a	( title x y w h flags -- )
c-function SDL_IsShapedWindow SDL_IsShapedWindow a -- n	( window -- )
c-function SDL_SetWindowShape SDL_SetWindowShape a a a -- n	( window shape shape_mode -- )
c-function SDL_GetShapedWindowMode SDL_GetShapedWindowMode a a -- n	( window shape_mode -- )

\ ----===< postfix >===-----
end-c-library
