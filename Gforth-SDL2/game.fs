require SDL2/SDL.fs
require SDL2/SDL_image.fs
\ require SDL2/SDL_ttf.fs

s\" Don't Eat the Yellow Snow!\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT

VARIABLE window
VARIABLE renderer
VARIABLE background-image
VARIABLE surface
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

: load-background ( -- )
    s\" images/background.png\0" DROP IMG_Load surface !
    surface @ 0= IF
        ." Failed to load image to surface: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN
    renderer @ surface @ SDL_CreateTextureFromSurface background-image !
    background-image @ 0= IF
        ." Failed to create texuture from surface: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN
    surface @ SDL_FreeSurface ;

: main-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type @ 0xFFFFFFFF AND 
            DUP SDL_QUIT_ENUM = IF clean-and-exit THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym @ 0xFFFFFFFF AND
                DUP SDL_SCANCODE_ESCAPE = IF clean-and-exit THEN
                SDL_SCANCODE_SPACE = IF ." Space" CR THEN
            THEN
        REPEAT
        
        renderer @ SDL_RenderClear DROP

        renderer @ background-image @ 0 0 SDL_RenderCopy DROP

        renderer @ SDL_RenderPresent

        16 SDL_Delay
    FALSE UNTIL ;

start-sdl
create-window
create-renderer
load-background
main-loop

clean-and-exit
