require SDL2/SDL.fs
require SDL2/SDL_image.fs
\ require SDL2/SDL_ttf.fs

s\" Don't Eat the Yellow Snow!\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT

: c-str> ( c-addr -- c-addr u ) 0 BEGIN 2dup + c@ WHILE 1+ REPEAT ;

require game.fs

game-play
