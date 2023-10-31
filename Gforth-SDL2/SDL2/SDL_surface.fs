\ ----===< prefix >===-----
c-library sdl_surface
s" SDL2" add-lib
\c #include <SDL2/SDL_surface.h>

\ ----===< int constants >===-----
#0	constant SDL_SWSURFACE
#1	constant SDL_PREALLOC
#2	constant SDL_RLEACCEL
#4	constant SDL_DONTFREE
#8	constant SDL_SIMD_ALIGNED

\ --------===< enums >===---------
#0	constant SDL_YUV_CONVERSION_JPEG
#1	constant SDL_YUV_CONVERSION_BT601
#2	constant SDL_YUV_CONVERSION_BT709
#3	constant SDL_YUV_CONVERSION_AUTOMATIC

\ -------===< structs >===--------
\ struct SDL_Surface
begin-structure SDL_Surface
	drop 16 4 +field SDL_Surface-w
	drop 88 4 +field SDL_Surface-refcount
	drop 64 16 +field SDL_Surface-clip_rect
	drop 24 4 +field SDL_Surface-pitch
	drop 80 8 +field SDL_Surface-map
	drop 0 4 +field SDL_Surface-flags
	drop 8 8 +field SDL_Surface-format
	drop 40 8 +field SDL_Surface-userdata
	drop 48 4 +field SDL_Surface-locked
	drop 56 8 +field SDL_Surface-list_blitmap
	drop 20 4 +field SDL_Surface-h
	drop 32 8 +field SDL_Surface-pixels
drop 96 end-structure

\ ------===< functions >===-------
c-function SDL_CreateRGBSurface SDL_CreateRGBSurface n n n n n n n n -- a	( flags width height depth Rmask Gmask Bmask Amask -- )
c-function SDL_CreateRGBSurfaceWithFormat SDL_CreateRGBSurfaceWithFormat n n n n n -- a	( flags width height depth format -- )
c-function SDL_CreateRGBSurfaceFrom SDL_CreateRGBSurfaceFrom a n n n n n n n n -- a	( pixels width height depth pitch Rmask Gmask Bmask Amask -- )
c-function SDL_CreateRGBSurfaceWithFormatFrom SDL_CreateRGBSurfaceWithFormatFrom a n n n n n -- a	( pixels width height depth pitch format -- )
c-function SDL_FreeSurface SDL_FreeSurface a -- void	( surface -- )
c-function SDL_SetSurfacePalette SDL_SetSurfacePalette a a -- n	( surface palette -- )
c-function SDL_LockSurface SDL_LockSurface a -- n	( surface -- )
c-function SDL_UnlockSurface SDL_UnlockSurface a -- void	( surface -- )
c-function SDL_LoadBMP_RW SDL_LoadBMP_RW a n -- a	( src freesrc -- )
c-function SDL_SaveBMP_RW SDL_SaveBMP_RW a a n -- n	( surface dst freedst -- )
c-function SDL_SetSurfaceRLE SDL_SetSurfaceRLE a n -- n	( surface flag -- )
c-function SDL_HasSurfaceRLE SDL_HasSurfaceRLE a -- n	( surface -- )
c-function SDL_SetColorKey SDL_SetColorKey a n n -- n	( surface flag key -- )
c-function SDL_HasColorKey SDL_HasColorKey a -- n	( surface -- )
c-function SDL_GetColorKey SDL_GetColorKey a a -- n	( surface key -- )
c-function SDL_SetSurfaceColorMod SDL_SetSurfaceColorMod a n n n -- n	( surface r g b -- )
c-function SDL_GetSurfaceColorMod SDL_GetSurfaceColorMod a a a a -- n	( surface r g b -- )
c-function SDL_SetSurfaceAlphaMod SDL_SetSurfaceAlphaMod a n -- n	( surface alpha -- )
c-function SDL_GetSurfaceAlphaMod SDL_GetSurfaceAlphaMod a a -- n	( surface alpha -- )
c-function SDL_SetSurfaceBlendMode SDL_SetSurfaceBlendMode a n -- n	( surface blendMode -- )
c-function SDL_GetSurfaceBlendMode SDL_GetSurfaceBlendMode a a -- n	( surface blendMode -- )
c-function SDL_SetClipRect SDL_SetClipRect a a -- n	( surface rect -- )
c-function SDL_GetClipRect SDL_GetClipRect a a -- void	( surface rect -- )
c-function SDL_DuplicateSurface SDL_DuplicateSurface a -- a	( surface -- )
c-function SDL_ConvertSurface SDL_ConvertSurface a a n -- a	( src fmt flags -- )
c-function SDL_ConvertSurfaceFormat SDL_ConvertSurfaceFormat a n n -- a	( src pixel_format flags -- )
c-function SDL_ConvertPixels SDL_ConvertPixels n n n a n n a n -- n	( width height src_format src src_pitch dst_format dst dst_pitch -- )
c-function SDL_PremultiplyAlpha SDL_PremultiplyAlpha n n n a n n a n -- n	( width height src_format src src_pitch dst_format dst dst_pitch -- )
c-function SDL_FillRect SDL_FillRect a a n -- n	( dst rect color -- )
c-function SDL_FillRects SDL_FillRects a a n n -- n	( dst rects count color -- )
c-function SDL_UpperBlit SDL_UpperBlit a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_LowerBlit SDL_LowerBlit a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_SoftStretch SDL_SoftStretch a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_SoftStretchLinear SDL_SoftStretchLinear a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_UpperBlitScaled SDL_UpperBlitScaled a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_LowerBlitScaled SDL_LowerBlitScaled a a a a -- n	( src srcrect dst dstrect -- )
c-function SDL_SetYUVConversionMode SDL_SetYUVConversionMode n -- void	( mode -- )
c-function SDL_GetYUVConversionMode SDL_GetYUVConversionMode  -- n	( -- )
c-function SDL_GetYUVConversionModeForResolution SDL_GetYUVConversionModeForResolution n n -- n	( width height -- )

\ ----===< postfix >===-----
end-c-library
