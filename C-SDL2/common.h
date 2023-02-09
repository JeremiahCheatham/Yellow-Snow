#ifndef COMMON_H
#define COMMON_H

// Included header files.
#include <stdio.h>
#include <math.h>
#include <string.h>
#include <stdbool.h>
#include <stdint.h>
#include <time.h>
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <SDL2/SDL_image.h>
#include <SDL2/SDL_mixer.h>

// Define directives for constants.
#define MY_SDL_FLAGS (SDL_INIT_VIDEO|SDL_INIT_TIMER|SDL_INIT_AUDIO)
#define TITLE "ASTEROIDS! - SDL"
#define ICON "images/yellow.png"
#define WIDTH 800
#define HEIGHT 600
#define FPS 60

#define GROUND 550

#define PLAYER_TOP 374
#define PLAYER_TOP_OFFSET 16
#define PLAYER_LEFT_OFFSET 48
#define PLAYER_RIGHT_OFFSET 44
#define PLAYER_SPEED 300

#define FONT_NAME "fonts/freesansbold.ttf"
#define FONT_COLOR {255, 255, 255, 255}
#define FONT_SIZE 24

#define FLAKE_SPEED 300

// Length of array macro.
#define LEN(x) (sizeof(x)/sizeof(x[0]))

enum Errors {QUIT=1, ERROR_SDL, ERROR_WIN, ERROR_REND, ERROR_TTF, ERROR_IMG, \
            ERROR_NIMG, ERROR_ICON, ERROR_BOND, ERROR_FONT, ERROR_SURF, \
            ERROR_TEXT, ERROR_ARRY, ERROR_MIX, ERROR_MUSC, ERROR_SND, \
            ERROR_MALC, ERROR_TARG, ERROR_COPY, ERROR_XCPY, ERROR_CLR, \
            ERROR_QTEX, ERROR_BLND, ERROR_PRES};

struct Game{
    SDL_Event event;
    SDL_Window *win;
    SDL_Renderer *rend;
    SDL_Texture *background;
    SDL_Texture *player;
    SDL_Texture *white;
    SDL_Texture *yellow;
    SDL_Texture *score_text;
    Mix_Music *music;
    Mix_Chunk *collect;
    Mix_Chunk *hit;
    float frame_delay;
    float delta_time;
    bool show_fps;
    enum Errors exit_status;
    bool playing;
};

#endif