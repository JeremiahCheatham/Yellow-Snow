\ ----===< prefix >===-----
c-library sdl_render
s" SDL2" add-lib
\c #include <SDL2/SDL_render.h>

\ --------===< enums >===---------
#1	constant SDL_RENDERER_SOFTWARE
#2	constant SDL_RENDERER_ACCELERATED
#4	constant SDL_RENDERER_PRESENTVSYNC
#8	constant SDL_RENDERER_TARGETTEXTURE
#0	constant SDL_ScaleModeNearest
#1	constant SDL_ScaleModeLinear
#2	constant SDL_ScaleModeBest
#0	constant SDL_TEXTUREACCESS_STATIC
#1	constant SDL_TEXTUREACCESS_STREAMING
#2	constant SDL_TEXTUREACCESS_TARGET
#0	constant SDL_TEXTUREMODULATE_NONE
#1	constant SDL_TEXTUREMODULATE_COLOR
#2	constant SDL_TEXTUREMODULATE_ALPHA
#0	constant SDL_FLIP_NONE
#1	constant SDL_FLIP_HORIZONTAL
#2	constant SDL_FLIP_VERTICAL

\ -------===< structs >===--------
\ struct SDL_RendererInfo
begin-structure SDL_RendererInfo
	drop 0 8 +field SDL_RendererInfo-name
	drop 80 4 +field SDL_RendererInfo-max_texture_width
	drop 84 4 +field SDL_RendererInfo-max_texture_height
	drop 12 4 +field SDL_RendererInfo-num_texture_formats
	drop 16 64 +field SDL_RendererInfo-texture_formats
	drop 8 4 +field SDL_RendererInfo-flags
drop 88 end-structure
\ struct SDL_Vertex
begin-structure SDL_Vertex
	drop 8 4 +field SDL_Vertex-color
	drop 0 8 +field SDL_Vertex-position
	drop 12 8 +field SDL_Vertex-tex_coord
drop 20 end-structure

\ ------===< functions >===-------
c-function SDL_GetNumRenderDrivers SDL_GetNumRenderDrivers  -- n	( -- )
c-function SDL_GetRenderDriverInfo SDL_GetRenderDriverInfo n a -- n	( index info -- )
c-function SDL_CreateWindowAndRenderer SDL_CreateWindowAndRenderer n n n a a -- n	( width height window_flags window renderer -- )
c-function SDL_CreateRenderer SDL_CreateRenderer a n n -- a	( window index flags -- )
c-function SDL_CreateSoftwareRenderer SDL_CreateSoftwareRenderer a -- a	( surface -- )
c-function SDL_GetRenderer SDL_GetRenderer a -- a	( window -- )
c-function SDL_RenderGetWindow SDL_RenderGetWindow a -- a	( renderer -- )
c-function SDL_GetRendererInfo SDL_GetRendererInfo a a -- n	( renderer info -- )
c-function SDL_GetRendererOutputSize SDL_GetRendererOutputSize a a a -- n	( renderer w h -- )
c-function SDL_CreateTexture SDL_CreateTexture a n n n n -- a	( renderer format access w h -- )
c-function SDL_CreateTextureFromSurface SDL_CreateTextureFromSurface a a -- a	( renderer surface -- )
c-function SDL_QueryTexture SDL_QueryTexture a a a a a -- n	( texture format access w h -- )
c-function SDL_SetTextureColorMod SDL_SetTextureColorMod a n n n -- n	( texture r g b -- )
c-function SDL_GetTextureColorMod SDL_GetTextureColorMod a a a a -- n	( texture r g b -- )
c-function SDL_SetTextureAlphaMod SDL_SetTextureAlphaMod a n -- n	( texture alpha -- )
c-function SDL_GetTextureAlphaMod SDL_GetTextureAlphaMod a a -- n	( texture alpha -- )
c-function SDL_SetTextureBlendMode SDL_SetTextureBlendMode a n -- n	( texture blendMode -- )
c-function SDL_GetTextureBlendMode SDL_GetTextureBlendMode a a -- n	( texture blendMode -- )
c-function SDL_SetTextureScaleMode SDL_SetTextureScaleMode a n -- n	( texture scaleMode -- )
c-function SDL_GetTextureScaleMode SDL_GetTextureScaleMode a a -- n	( texture scaleMode -- )
c-function SDL_SetTextureUserData SDL_SetTextureUserData a a -- n	( texture userdata -- )
c-function SDL_GetTextureUserData SDL_GetTextureUserData a -- a	( texture -- )
c-function SDL_UpdateTexture SDL_UpdateTexture a a a n -- n	( texture rect pixels pitch -- )
c-function SDL_UpdateYUVTexture SDL_UpdateYUVTexture a a a n a n a n -- n	( texture rect Yplane Ypitch Uplane Upitch Vplane Vpitch -- )
c-function SDL_UpdateNVTexture SDL_UpdateNVTexture a a a n a n -- n	( texture rect Yplane Ypitch UVplane UVpitch -- )
c-function SDL_LockTexture SDL_LockTexture a a a a -- n	( texture rect pixels pitch -- )
c-function SDL_LockTextureToSurface SDL_LockTextureToSurface a a a -- n	( texture rect surface -- )
c-function SDL_UnlockTexture SDL_UnlockTexture a -- void	( texture -- )
c-function SDL_RenderTargetSupported SDL_RenderTargetSupported a -- n	( renderer -- )
c-function SDL_SetRenderTarget SDL_SetRenderTarget a a -- n	( renderer texture -- )
c-function SDL_GetRenderTarget SDL_GetRenderTarget a -- a	( renderer -- )
c-function SDL_RenderSetLogicalSize SDL_RenderSetLogicalSize a n n -- n	( renderer w h -- )
c-function SDL_RenderGetLogicalSize SDL_RenderGetLogicalSize a a a -- void	( renderer w h -- )
c-function SDL_RenderSetIntegerScale SDL_RenderSetIntegerScale a n -- n	( renderer enable -- )
c-function SDL_RenderGetIntegerScale SDL_RenderGetIntegerScale a -- n	( renderer -- )
c-function SDL_RenderSetViewport SDL_RenderSetViewport a a -- n	( renderer rect -- )
c-function SDL_RenderGetViewport SDL_RenderGetViewport a a -- void	( renderer rect -- )
c-function SDL_RenderSetClipRect SDL_RenderSetClipRect a a -- n	( renderer rect -- )
c-function SDL_RenderGetClipRect SDL_RenderGetClipRect a a -- void	( renderer rect -- )
c-function SDL_RenderIsClipEnabled SDL_RenderIsClipEnabled a -- n	( renderer -- )
c-function SDL_RenderSetScale SDL_RenderSetScale a r r -- n	( renderer scaleX scaleY -- )
c-function SDL_RenderGetScale SDL_RenderGetScale a a a -- void	( renderer scaleX scaleY -- )
c-function SDL_RenderWindowToLogical SDL_RenderWindowToLogical a n n a a -- void	( renderer windowX windowY logicalX logicalY -- )
c-function SDL_RenderLogicalToWindow SDL_RenderLogicalToWindow a r r a a -- void	( renderer logicalX logicalY windowX windowY -- )
c-function SDL_SetRenderDrawColor SDL_SetRenderDrawColor a n n n n -- n	( renderer r g b a -- )
c-function SDL_GetRenderDrawColor SDL_GetRenderDrawColor a a a a a -- n	( renderer r g b a -- )
c-function SDL_SetRenderDrawBlendMode SDL_SetRenderDrawBlendMode a n -- n	( renderer blendMode -- )
c-function SDL_GetRenderDrawBlendMode SDL_GetRenderDrawBlendMode a a -- n	( renderer blendMode -- )
c-function SDL_RenderClear SDL_RenderClear a -- n	( renderer -- )
c-function SDL_RenderDrawPoint SDL_RenderDrawPoint a n n -- n	( renderer x y -- )
c-function SDL_RenderDrawPoints SDL_RenderDrawPoints a a n -- n	( renderer points count -- )
c-function SDL_RenderDrawLine SDL_RenderDrawLine a n n n n -- n	( renderer x1 y1 x2 y2 -- )
c-function SDL_RenderDrawLines SDL_RenderDrawLines a a n -- n	( renderer points count -- )
c-function SDL_RenderDrawRect SDL_RenderDrawRect a a -- n	( renderer rect -- )
c-function SDL_RenderDrawRects SDL_RenderDrawRects a a n -- n	( renderer rects count -- )
c-function SDL_RenderFillRect SDL_RenderFillRect a a -- n	( renderer rect -- )
c-function SDL_RenderFillRects SDL_RenderFillRects a a n -- n	( renderer rects count -- )
c-function SDL_RenderCopy SDL_RenderCopy a a a a -- n	( renderer texture srcrect dstrect -- )
c-function SDL_RenderCopyEx SDL_RenderCopyEx a a a a r a n -- n	( renderer texture srcrect dstrect angle center flip -- )
c-function SDL_RenderDrawPointF SDL_RenderDrawPointF a r r -- n	( renderer x y -- )
c-function SDL_RenderDrawPointsF SDL_RenderDrawPointsF a a n -- n	( renderer points count -- )
c-function SDL_RenderDrawLineF SDL_RenderDrawLineF a r r r r -- n	( renderer x1 y1 x2 y2 -- )
c-function SDL_RenderDrawLinesF SDL_RenderDrawLinesF a a n -- n	( renderer points count -- )
c-function SDL_RenderDrawRectF SDL_RenderDrawRectF a a -- n	( renderer rect -- )
c-function SDL_RenderDrawRectsF SDL_RenderDrawRectsF a a n -- n	( renderer rects count -- )
c-function SDL_RenderFillRectF SDL_RenderFillRectF a a -- n	( renderer rect -- )
c-function SDL_RenderFillRectsF SDL_RenderFillRectsF a a n -- n	( renderer rects count -- )
c-function SDL_RenderCopyF SDL_RenderCopyF a a a a -- n	( renderer texture srcrect dstrect -- )
c-function SDL_RenderCopyExF SDL_RenderCopyExF a a a a r a n -- n	( renderer texture srcrect dstrect angle center flip -- )
c-function SDL_RenderGeometry SDL_RenderGeometry a a a n a n -- n	( renderer texture vertices num_vertices indices num_indices -- )
c-function SDL_RenderGeometryRaw SDL_RenderGeometryRaw a a a n a n a n n a n n -- n	( renderer texture xy xy_stride color color_stride uv uv_stride num_vertices indices num_indices size_indices -- )
c-function SDL_RenderReadPixels SDL_RenderReadPixels a a n a n -- n	( renderer rect format pixels pitch -- )
c-function SDL_RenderPresent SDL_RenderPresent a -- void	( renderer -- )
c-function SDL_DestroyTexture SDL_DestroyTexture a -- void	( texture -- )
c-function SDL_DestroyRenderer SDL_DestroyRenderer a -- void	( renderer -- )
c-function SDL_RenderFlush SDL_RenderFlush a -- n	( renderer -- )
c-function SDL_GL_BindTexture SDL_GL_BindTexture a a a -- n	( texture texw texh -- )
c-function SDL_GL_UnbindTexture SDL_GL_UnbindTexture a -- n	( texture -- )
c-function SDL_RenderGetMetalLayer SDL_RenderGetMetalLayer a -- a	( renderer -- )
c-function SDL_RenderGetMetalCommandEncoder SDL_RenderGetMetalCommandEncoder a -- a	( renderer -- )
c-function SDL_RenderSetVSync SDL_RenderSetVSync a n -- n	( renderer vsync -- )

\ ----===< postfix >===-----
end-c-library
