require SDL2/SDL.fs
require SDL2/SDL_image.fs
\ require SDL2/SDL_ttf.fs

s\" Don't Eat the Yellow Snow!\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT

VARIABLE window
VARIABLE renderer
VARIABLE keystate
VARIABLE background-image
CREATE background-rect SDL_Rect ALLOT
VARIABLE player-image
CREATE player-rect SDL_Rect ALLOT
VARIABLE player-direction SDL_FLIP_NONE player-direction L!
CREATE event SDL_Event ALLOT

: c-str> ( c-addr -- c-addr u ) 0 BEGIN 2dup + c@ WHILE 1+ REPEAT ;

: clean-and-exit ( -- )
    renderer @ SDL_DestroyRenderer
    window @ SDL_DestroyWindow
    SDL_Quit
    BYE ;

: start-sdl ( -- )
    SDL_INIT_EVERYTHING SDL_Init IF
        ." Failed to initialize SDL: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN
    IMG_INIT_PNG IMG_Init DROP ;

: create-window ( -- )
    WINDOW_TITLE SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED SCREEN_WIDTH SCREEN_HEIGHT 0
    SDL_CreateWindow window !
    window @ 0= IF 
        ." Failed to create window: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN ;

: create-renderer ( -- )
    window @ -1 0 SDL_CreateRenderer renderer !
    renderer @ 0= IF
        ." Failed to create renderer: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN ;

: create-texture-and-rect ( -- )
    ROT
    IMG_Load DUP 0= IF
        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
        DROP clean-and-exit
    THEN
    SWAP 0 OVER SDL_Rect-x l!
    0 OVER SDL_Rect-y l!
    OVER SDL_Surface-w l@ OVER SDL_Rect-w l!
    OVER SDL_Surface-h l@ SWAP SDL_Rect-h l!
    renderer @ OVER SDL_CreateTextureFromSurface DUP 0= IF
        ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
        DROP SDL_FreeSurface clean-and-exit
    THEN SWAP SDL_FreeSurface SWAP ! ;

: player-init ( -- )
    s\" images/player.png\0" DROP player-image player-rect create-texture-and-rect
    377 player-rect SDL_Rect-y l!
    SCREEN_WIDTH player-rect SDL_Rect-w l@ - 2 / player-rect SDL_Rect-x l! ;

: player-update ( -- )
    keystate SDL_Keysym-scancode @ SDL_SCANCODE_LEFT + C@ 1 = IF
        player-rect SDL_Rect-x L@ 5 - DUP 0 < IF DROP 0 THEN
        player-rect SDL_Rect-x L!
        SDL_FLIP_HORIZONTAL player-direction !
    THEN

    keystate SDL_Keysym-scancode @ SDL_SCANCODE_RIGHT + c@ 1 = IF
        player-rect SDL_Rect-x L@ 5 +
        DUP
        SCREEN_WIDTH player-rect SDL_Rect-w L@ -
        DUP
        ROT < IF SWAP THEN
        DROP player-rect SDL_Rect-x L!
        SDL_FLIP_NONE player-direction !
    THEN ;

\ : load-background ( -- )
\    s\" images/background.png\0" DROP IMG_Load DUP 0= IF
\        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
\        DROP clean-and-exit
\    THEN
\    DUP SDL_Surface-w @ background-rect SDL_Rect-w !
\    DUP SDL_Surface-h @ background-rect SDL_Rect-h !
\    renderer @ OVER SDL_CreateTextureFromSurface DUP 0= IF
\        ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
\        DROP SDL_FreeSurface clean-and-exit
\    THEN background-image ! SDL_FreeSurface ;

: main-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF clean-and-exit THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                DUP SDL_SCANCODE_ESCAPE = IF clean-and-exit THEN
                SDL_SCANCODE_SPACE = IF .s CR THEN
            THEN
        REPEAT

        player-update
        
        renderer @ SDL_RenderClear DROP

        renderer @ background-image @ 0 background-rect SDL_RenderCopy DROP
        renderer @ player-image @ 0 player-rect 0e 0 player-direction @ SDL_RenderCopyEX DROP

        renderer @ SDL_RenderPresent

        16 SDL_Delay
    FALSE UNTIL ;

start-sdl
create-window
create-renderer

0 SDL_GetKeyboardState keystate ! 

s\" images/background.png\0" DROP background-image background-rect create-texture-and-rect

player-init

main-loop

clean-and-exit
