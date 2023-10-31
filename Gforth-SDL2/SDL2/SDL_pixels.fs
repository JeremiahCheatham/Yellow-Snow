\ ----===< prefix >===-----
c-library sdl_pixels
s" SDL2" add-lib
\c #include <SDL2/SDL_pixels.h>

\ ----===< int constants >===-----
#255	constant SDL_ALPHA_OPAQUE
#0	constant SDL_ALPHA_TRANSPARENT

\ --------===< enums >===---------
#0	constant SDL_PIXELTYPE_UNKNOWN
#1	constant SDL_PIXELTYPE_INDEX1
#2	constant SDL_PIXELTYPE_INDEX4
#3	constant SDL_PIXELTYPE_INDEX8
#4	constant SDL_PIXELTYPE_PACKED8
#5	constant SDL_PIXELTYPE_PACKED16
#6	constant SDL_PIXELTYPE_PACKED32
#7	constant SDL_PIXELTYPE_ARRAYU8
#8	constant SDL_PIXELTYPE_ARRAYU16
#9	constant SDL_PIXELTYPE_ARRAYU32
#10	constant SDL_PIXELTYPE_ARRAYF16
#11	constant SDL_PIXELTYPE_ARRAYF32
#0	constant SDL_BITMAPORDER_NONE
#1	constant SDL_BITMAPORDER_4321
#2	constant SDL_BITMAPORDER_1234
#0	constant SDL_PACKEDORDER_NONE
#1	constant SDL_PACKEDORDER_XRGB
#2	constant SDL_PACKEDORDER_RGBX
#3	constant SDL_PACKEDORDER_ARGB
#4	constant SDL_PACKEDORDER_RGBA
#5	constant SDL_PACKEDORDER_XBGR
#6	constant SDL_PACKEDORDER_BGRX
#7	constant SDL_PACKEDORDER_ABGR
#8	constant SDL_PACKEDORDER_BGRA
#0	constant SDL_ARRAYORDER_NONE
#1	constant SDL_ARRAYORDER_RGB
#2	constant SDL_ARRAYORDER_RGBA
#3	constant SDL_ARRAYORDER_ARGB
#4	constant SDL_ARRAYORDER_BGR
#5	constant SDL_ARRAYORDER_BGRA
#6	constant SDL_ARRAYORDER_ABGR
#0	constant SDL_PACKEDLAYOUT_NONE
#1	constant SDL_PACKEDLAYOUT_332
#2	constant SDL_PACKEDLAYOUT_4444
#3	constant SDL_PACKEDLAYOUT_1555
#4	constant SDL_PACKEDLAYOUT_5551
#5	constant SDL_PACKEDLAYOUT_565
#6	constant SDL_PACKEDLAYOUT_8888
#7	constant SDL_PACKEDLAYOUT_2101010
#8	constant SDL_PACKEDLAYOUT_1010102
#0	constant SDL_PIXELFORMAT_UNKNOWN
#286261504	constant SDL_PIXELFORMAT_INDEX1LSB
#287310080	constant SDL_PIXELFORMAT_INDEX1MSB
#303039488	constant SDL_PIXELFORMAT_INDEX4LSB
#304088064	constant SDL_PIXELFORMAT_INDEX4MSB
#318769153	constant SDL_PIXELFORMAT_INDEX8
#336660481	constant SDL_PIXELFORMAT_RGB332
#353504258	constant SDL_PIXELFORMAT_XRGB4444
#353504258	constant SDL_PIXELFORMAT_RGB444
#357698562	constant SDL_PIXELFORMAT_XBGR4444
#357698562	constant SDL_PIXELFORMAT_BGR444
#353570562	constant SDL_PIXELFORMAT_XRGB1555
#353570562	constant SDL_PIXELFORMAT_RGB555
#357764866	constant SDL_PIXELFORMAT_XBGR1555
#357764866	constant SDL_PIXELFORMAT_BGR555
#355602434	constant SDL_PIXELFORMAT_ARGB4444
#356651010	constant SDL_PIXELFORMAT_RGBA4444
#359796738	constant SDL_PIXELFORMAT_ABGR4444
#360845314	constant SDL_PIXELFORMAT_BGRA4444
#355667970	constant SDL_PIXELFORMAT_ARGB1555
#356782082	constant SDL_PIXELFORMAT_RGBA5551
#359862274	constant SDL_PIXELFORMAT_ABGR1555
#360976386	constant SDL_PIXELFORMAT_BGRA5551
#353701890	constant SDL_PIXELFORMAT_RGB565
#357896194	constant SDL_PIXELFORMAT_BGR565
#386930691	constant SDL_PIXELFORMAT_RGB24
#390076419	constant SDL_PIXELFORMAT_BGR24
#370546692	constant SDL_PIXELFORMAT_XRGB8888
#370546692	constant SDL_PIXELFORMAT_RGB888
#371595268	constant SDL_PIXELFORMAT_RGBX8888
#374740996	constant SDL_PIXELFORMAT_XBGR8888
#374740996	constant SDL_PIXELFORMAT_BGR888
#375789572	constant SDL_PIXELFORMAT_BGRX8888
#372645892	constant SDL_PIXELFORMAT_ARGB8888
#373694468	constant SDL_PIXELFORMAT_RGBA8888
#376840196	constant SDL_PIXELFORMAT_ABGR8888
#377888772	constant SDL_PIXELFORMAT_BGRA8888
#372711428	constant SDL_PIXELFORMAT_ARGB2101010
#376840196	constant SDL_PIXELFORMAT_RGBA32
#377888772	constant SDL_PIXELFORMAT_ARGB32
#372645892	constant SDL_PIXELFORMAT_BGRA32
#373694468	constant SDL_PIXELFORMAT_ABGR32
#842094169	constant SDL_PIXELFORMAT_YV12
#1448433993	constant SDL_PIXELFORMAT_IYUV
#844715353	constant SDL_PIXELFORMAT_YUY2
#1498831189	constant SDL_PIXELFORMAT_UYVY
#1431918169	constant SDL_PIXELFORMAT_YVYU
#842094158	constant SDL_PIXELFORMAT_NV12
#825382478	constant SDL_PIXELFORMAT_NV21
#542328143	constant SDL_PIXELFORMAT_EXTERNAL_OES

\ -------===< structs >===--------
\ struct SDL_Color
begin-structure SDL_Color
	drop 2 1 +field SDL_Color-b
	drop 0 1 +field SDL_Color-r
	drop 1 1 +field SDL_Color-g
	drop 3 1 +field SDL_Color-a
drop 4 end-structure
\ struct SDL_Palette
begin-structure SDL_Palette
	drop 20 4 +field SDL_Palette-refcount
	drop 0 4 +field SDL_Palette-ncolors
	drop 8 8 +field SDL_Palette-colors
	drop 16 4 +field SDL_Palette-version
drop 24 end-structure
\ struct SDL_PixelFormat
begin-structure SDL_PixelFormat
	drop 42 1 +field SDL_PixelFormat-Bshift
	drop 44 4 +field SDL_PixelFormat-refcount
	drop 24 4 +field SDL_PixelFormat-Gmask
	drop 37 1 +field SDL_PixelFormat-Gloss
	drop 0 4 +field SDL_PixelFormat-format
	drop 28 4 +field SDL_PixelFormat-Bmask
	drop 32 4 +field SDL_PixelFormat-Amask
	drop 20 4 +field SDL_PixelFormat-Rmask
	drop 8 8 +field SDL_PixelFormat-palette
	drop 38 1 +field SDL_PixelFormat-Bloss
	drop 41 1 +field SDL_PixelFormat-Gshift
	drop 39 1 +field SDL_PixelFormat-Aloss
	drop 17 1 +field SDL_PixelFormat-BytesPerPixel
	drop 16 1 +field SDL_PixelFormat-BitsPerPixel
	drop 36 1 +field SDL_PixelFormat-Rloss
	drop 48 8 +field SDL_PixelFormat-next
	drop 18 2 +field SDL_PixelFormat-padding
	drop 40 1 +field SDL_PixelFormat-Rshift
	drop 43 1 +field SDL_PixelFormat-Ashift
drop 56 end-structure

\ ------===< functions >===-------
c-function SDL_GetPixelFormatName SDL_GetPixelFormatName n -- a	( format -- )
c-function SDL_PixelFormatEnumToMasks SDL_PixelFormatEnumToMasks n a a a a a -- n	( format bpp Rmask Gmask Bmask Amask -- )
c-function SDL_MasksToPixelFormatEnum SDL_MasksToPixelFormatEnum n n n n n -- n	( bpp Rmask Gmask Bmask Amask -- )
c-function SDL_AllocFormat SDL_AllocFormat n -- a	( pixel_format -- )
c-function SDL_FreeFormat SDL_FreeFormat a -- void	( format -- )
c-function SDL_AllocPalette SDL_AllocPalette n -- a	( ncolors -- )
c-function SDL_SetPixelFormatPalette SDL_SetPixelFormatPalette a a -- n	( format palette -- )
c-function SDL_SetPaletteColors SDL_SetPaletteColors a a n n -- n	( palette colors firstcolor ncolors -- )
c-function SDL_FreePalette SDL_FreePalette a -- void	( palette -- )
c-function SDL_MapRGB SDL_MapRGB a n n n -- n	( format r g b -- )
c-function SDL_MapRGBA SDL_MapRGBA a n n n n -- n	( format r g b a -- )
c-function SDL_GetRGB SDL_GetRGB n a a a a -- void	( pixel format r g b -- )
c-function SDL_GetRGBA SDL_GetRGBA n a a a a a -- void	( pixel format r g b a -- )
c-function SDL_CalculateGammaRamp SDL_CalculateGammaRamp r a -- void	( gamma ramp -- )

\ ----===< postfix >===-----
end-c-library
