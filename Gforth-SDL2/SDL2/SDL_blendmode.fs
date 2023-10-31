\ ----===< prefix >===-----
c-library sdl_blendmode
s" SDL2" add-lib
\c #include <SDL2/SDL_blendmode.h>

\ --------===< enums >===---------
#0	constant SDL_BLENDMODE_NONE
#1	constant SDL_BLENDMODE_BLEND
#2	constant SDL_BLENDMODE_ADD
#4	constant SDL_BLENDMODE_MOD
#8	constant SDL_BLENDMODE_MUL
#2147483647	constant SDL_BLENDMODE_INVALID
#1	constant SDL_BLENDOPERATION_ADD
#2	constant SDL_BLENDOPERATION_SUBTRACT
#3	constant SDL_BLENDOPERATION_REV_SUBTRACT
#4	constant SDL_BLENDOPERATION_MINIMUM
#5	constant SDL_BLENDOPERATION_MAXIMUM
#1	constant SDL_BLENDFACTOR_ZERO
#2	constant SDL_BLENDFACTOR_ONE
#3	constant SDL_BLENDFACTOR_SRC_COLOR
#4	constant SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR
#5	constant SDL_BLENDFACTOR_SRC_ALPHA
#6	constant SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA
#7	constant SDL_BLENDFACTOR_DST_COLOR
#8	constant SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR
#9	constant SDL_BLENDFACTOR_DST_ALPHA
#10	constant SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA

\ ------===< functions >===-------
c-function SDL_ComposeCustomBlendMode SDL_ComposeCustomBlendMode n n n n n n -- n	( srcColorFactor dstColorFactor colorOperation srcAlphaFactor dstAlphaFactor alphaOperation -- )

\ ----===< postfix >===-----
end-c-library
