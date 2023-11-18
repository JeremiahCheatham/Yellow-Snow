require random.fs
require SDL2/SDL.fs
require SDL2/SDL_image.fs
require SDL2/SDL_ttf.fs
require SDL2/SDL_mixer.fs

\ Helpers for C
0 CONSTANT NULL
: c-str> ( c-str -- string u ) 0 BEGIN 2DUP + C@ WHILE 1+ REPEAT ;
: >c-str ( string u -- c-str )
    1+ DUP ALLOCATE
    DROP ROT OVER 3 PICK 1- MOVE
    DUP ROT 1- + 0 SWAP C!
;
: int32>! ( 64bit signed -- 32bit signed ) DUP 0< IF 0x100000000 + THEN L! ;
: int32<@ ( 32bit signed -- 64bit signed ) L@ DUP 0x7FFFFFFF > IF 0x100000000 - THEN ;

s" Don't Eat the Yellow Snow!" >c-str CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT

require game.fs

game-play
