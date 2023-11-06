VARIABLE window
VARIABLE renderer
VARIABLE keystate
CREATE event SDL_Event ALLOT

: sdl-cleanup ( -- )
    renderer @ SDL_DestroyRenderer
    window @ SDL_DestroyWindow
    TTF_Quit
    SDL_Quit
    BYE
;

: start-sdl ( -- )
    SDL_INIT_EVERYTHING SDL_Init IF
        ." Failed to initialize SDL: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    IMG_INIT_PNG IMG_Init DROP

    TTF_Init IF
        ." Error initializing SDL_ttf: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    0 SDL_GetKeyboardState keystate !

    \ 44100 MIX_DEFAULT_FORMAT 2 1024 Mix_OpenAudio .s CR
;

: create-window ( -- )
    WINDOW_TITLE SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED SCREEN_WIDTH SCREEN_HEIGHT 0
    SDL_CreateWindow window !
    window @ 0= IF 
        ." Failed to create window: " SDL_GetError c-str> TYPE CR
sdl-cleanup
    THEN
;

: create-renderer ( -- )
    window @ -1 0 SDL_CreateRenderer renderer !
    renderer @ 0= IF
        ." Failed to create renderer: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN
;

: sdl-init ( -- )
    start-sdl
    create-window
    create-renderer
;
