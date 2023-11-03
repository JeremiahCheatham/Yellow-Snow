require SDL2/SDL.fs
require SDL2/SDL_image.fs
\ require SDL2/SDL_ttf.fs

s\" Don't Eat the Yellow Snow!\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT

VARIABLE window
VARIABLE renderer
VARIABLE keystate
VARIABLE player-image
CREATE player-rect SDL_Rect ALLOT
VARIABLE player-direction SDL_FLIP_NONE player-direction L!
VARIABLE background-image
CREATE background-rect SDL_Rect ALLOT
CREATE event SDL_Event ALLOT

: c-str> ( c-addr -- c-addr u ) 0 BEGIN 2dup + c@ WHILE 1+ REPEAT ;

require sdl_init.fs
require load_media.fs
require player.fs
require game.fs

sdl-init
background-init
player-init

main-loop

clean-and-exit
