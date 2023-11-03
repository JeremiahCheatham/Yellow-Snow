: clean-and-exit ( -- )
    player-image @ SDL_DestroyTexture
    background-image @ SDL_DestroyTexture
    renderer @ SDL_DestroyRenderer
    window @ SDL_DestroyWindow
    SDL_Quit
    BYE ;

: start-sdl ( -- )
    SDL_INIT_EVERYTHING SDL_Init IF
        ." Failed to initialize SDL: " SDL_GetError c-str> TYPE CR
        clean-and-exit
    THEN
    IMG_INIT_PNG IMG_Init DROP
    0 SDL_GetKeyboardState keystate ! ;

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

: sdl-init ( -- )
    start-sdl
    create-window
    create-renderer ;

