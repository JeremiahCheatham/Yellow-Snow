VARIABLE window
VARIABLE renderer
VARIABLE keystate
CREATE event SDL_Event ALLOT
IMG_INIT_PNG CONSTANT img-flags

: sdl-cleanup ( -- )
    renderer @ SDL_DestroyRenderer
    window @ SDL_DestroyWindow
    TTF_Quit
    Mix_Quit
    SDL_Quit
    BYE
;

: sdl-init ( -- )
    SDL_INIT_EVERYTHING SDL_Init IF
        ." Error initializing SDL: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    img-flags IMG_Init img-flags AND img-flags <> IF
        ." Error initializing SDL_image: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    MIX_DEFAULT_FREQUENCY MIX_DEFAULT_FORMAT MIX_DEFAULT_CHANNELS 1024 Mix_OpenAudio IF
        ." Error initializing SDL_mixer: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    TTF_Init IF
        ." Error initializing SDL_ttf: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    WINDOW_TITLE SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED SCREEN_WIDTH SCREEN_HEIGHT 0
    SDL_CreateWindow window !
    window @ 0= IF 
        ." Failed to create window: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    window @ -1 0 SDL_CreateRenderer renderer !
    renderer @ 0= IF
        ." Failed to create renderer: " SDL_GetError c-str> TYPE CR
        sdl-cleanup
    THEN

    0 SDL_GetKeyboardState keystate !
;
