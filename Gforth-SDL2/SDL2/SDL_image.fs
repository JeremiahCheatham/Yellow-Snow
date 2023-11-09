\ ----===< prefix >===-----
c-library sdl_image
s" SDL2_image" add-lib
\c #include <SDL2/SDL_image.h>

\ ----===< int constants >===-----
#2	constant SDL_IMAGE_MAJOR_VERSION
#6	constant SDL_IMAGE_MINOR_VERSION
#3	constant SDL_IMAGE_PATCHLEVEL

\ --------===< enums >===---------
#1	constant IMG_INIT_JPG
#2	constant IMG_INIT_PNG
#4	constant IMG_INIT_TIF
#8	constant IMG_INIT_WEBP
#16	constant IMG_INIT_JXL
#32	constant IMG_INIT_AVIF

\ -------===< structs >===--------
\ IMG_Animation
begin-structure IMG_Animation
	drop 0 4 +field IMG_Animation-w
	drop 16 8 +field IMG_Animation-frames
	drop 8 4 +field IMG_Animation-count
	drop 24 8 +field IMG_Animation-delays
	drop 4 4 +field IMG_Animation-h
drop 32 end-structure

\ ------===< functions >===-------
c-function IMG_GetError SDL_GetError -- a ( -- string )
c-function IMG_ClearError SDL_ClearError -- void ( -- )
c-function IMG_Linked_Version IMG_Linked_Version  -- a	( -- )
c-function IMG_Init IMG_Init n -- n	( flags -- )
c-function IMG_Quit IMG_Quit  -- void	( -- )
c-function IMG_LoadTyped_RW IMG_LoadTyped_RW a n a -- a	( src freesrc type -- )
c-function IMG_Load IMG_Load a -- a	( file -- )
c-function IMG_Load_RW IMG_Load_RW a n -- a	( src freesrc -- )
c-function IMG_LoadTextureType_RW IMG_LoadTextureTyped_RW a a n a -- a ( renderer src freesrc type -- texture )
c-function IMG_LoadTexture IMG_LoadTexture a a -- a ( renderer file -- texture )
c-function IMG_LoadTexture_RW IMG_LoadTexture_RW a a n -- a ( renderer src freesrc -- texture )
c-function IMG_isAVIF IMG_isAVIF a -- n	( src -- )
c-function IMG_isICO IMG_isICO a -- n	( src -- )
c-function IMG_isCUR IMG_isCUR a -- n	( src -- )
c-function IMG_isBMP IMG_isBMP a -- n	( src -- )
c-function IMG_isGIF IMG_isGIF a -- n	( src -- )
c-function IMG_isJPG IMG_isJPG a -- n	( src -- )
c-function IMG_isJXL IMG_isJXL a -- n	( src -- )
c-function IMG_isLBM IMG_isLBM a -- n	( src -- )
c-function IMG_isPCX IMG_isPCX a -- n	( src -- )
c-function IMG_isPNG IMG_isPNG a -- n	( src -- )
c-function IMG_isPNM IMG_isPNM a -- n	( src -- )
c-function IMG_isSVG IMG_isSVG a -- n	( src -- )
c-function IMG_isQOI IMG_isQOI a -- n	( src -- )
c-function IMG_isTIF IMG_isTIF a -- n	( src -- )
c-function IMG_isXCF IMG_isXCF a -- n	( src -- )
c-function IMG_isXPM IMG_isXPM a -- n	( src -- )
c-function IMG_isXV IMG_isXV a -- n	( src -- )
c-function IMG_isWEBP IMG_isWEBP a -- n	( src -- )
c-function IMG_LoadAVIF_RW IMG_LoadAVIF_RW a -- a	( src -- )
c-function IMG_LoadICO_RW IMG_LoadICO_RW a -- a	( src -- )
c-function IMG_LoadCUR_RW IMG_LoadCUR_RW a -- a	( src -- )
c-function IMG_LoadBMP_RW IMG_LoadBMP_RW a -- a	( src -- )
c-function IMG_LoadGIF_RW IMG_LoadGIF_RW a -- a	( src -- )
c-function IMG_LoadJPG_RW IMG_LoadJPG_RW a -- a	( src -- )
c-function IMG_LoadJXL_RW IMG_LoadJXL_RW a -- a	( src -- )
c-function IMG_LoadLBM_RW IMG_LoadLBM_RW a -- a	( src -- )
c-function IMG_LoadPCX_RW IMG_LoadPCX_RW a -- a	( src -- )
c-function IMG_LoadPNG_RW IMG_LoadPNG_RW a -- a	( src -- )
c-function IMG_LoadPNM_RW IMG_LoadPNM_RW a -- a	( src -- )
c-function IMG_LoadSVG_RW IMG_LoadSVG_RW a -- a	( src -- )
c-function IMG_LoadQOI_RW IMG_LoadQOI_RW a -- a	( src -- )
c-function IMG_LoadTGA_RW IMG_LoadTGA_RW a -- a	( src -- )
c-function IMG_LoadTIF_RW IMG_LoadTIF_RW a -- a	( src -- )
c-function IMG_LoadXCF_RW IMG_LoadXCF_RW a -- a	( src -- )
c-function IMG_LoadXPM_RW IMG_LoadXPM_RW a -- a	( src -- )
c-function IMG_LoadXV_RW IMG_LoadXV_RW a -- a	( src -- )
c-function IMG_LoadWEBP_RW IMG_LoadWEBP_RW a -- a	( src -- )
c-function IMG_LoadSizedSVG_RW IMG_LoadSizedSVG_RW a n n -- a	( src width height -- )
c-function IMG_ReadXPMFromArray IMG_ReadXPMFromArray a -- a	( xpm -- )
c-function IMG_ReadXPMFromArrayToRGB888 IMG_ReadXPMFromArrayToRGB888 a -- a	( xpm -- )
c-function IMG_SavePNG IMG_SavePNG a a -- n	( surface file -- )
c-function IMG_SavePNG_RW IMG_SavePNG_RW a a n -- n	( surface dst freedst -- )
c-function IMG_SaveJPG IMG_SaveJPG a a n -- n	( surface file quality -- )
c-function IMG_SaveJPG_RW IMG_SaveJPG_RW a a n n -- n	( surface dst freedst quality -- )
c-function IMG_LoadAnimation IMG_LoadAnimation a -- a	( file -- )
c-function IMG_LoadAnimation_RW IMG_LoadAnimation_RW a n -- a	( src freesrc -- )
c-function IMG_LoadAnimationTyped_RW IMG_LoadAnimationTyped_RW a n a -- a	( src freesrc type -- )
c-function IMG_FreeAnimation IMG_FreeAnimation a -- void	( anim -- )
c-function IMG_LoadGIFAnimation_RW IMG_LoadGIFAnimation_RW a -- a	( src -- )

\ ----===< postfix >===-----
end-c-library
