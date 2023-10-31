\ table >order definitions

require SDL_platform.fs
require SDL_config.fs
require SDL_stdinc.fs
require SDL_main.fs
require SDL_assert.fs
require SDL_atomic.fs
require SDL_error.fs
require SDL_endian.fs
require SDL_mutex.fs
require SDL_thread.fs
require SDL_rwops.fs
require SDL_audio.fs
require SDL_clipboard.fs
require SDL_cpuinfo.fs
require SDL_pixels.fs
require SDL_rect.fs
require SDL_blendmode.fs
require SDL_surface.fs
require SDL_video.fs
require SDL_scancode.fs
require SDL_keycode.fs
require SDL_keyboard.fs
require SDL_mouse.fs
require SDL_guid.fs
require SDL_joystick.fs
require SDL_sensor.fs
require SDL_gamecontroller.fs
require SDL_quit.fs
require SDL_touch.fs
require SDL_gesture.fs
require SDL_events.fs
require SDL_filesystem.fs
require SDL_haptic.fs
require SDL_hidapi.fs
require SDL_hints.fs
require SDL_loadso.fs
require SDL_log.fs
require SDL_messagebox.fs
require SDL_metal.fs
require SDL_power.fs
require SDL_render.fs
require SDL_shape.fs
require SDL_system.fs
require SDL_timer.fs
require SDL_version.fs
require SDL_locale.fs
require SDL_misc.fs

\ wordlist >order definitions

\ ----===< prefix >===-----
c-library sdl
s" SDL2" add-lib
\c #include <SDL2/SDL.h>

\ ----===< int constants >===-----
#1	constant SDL_INIT_TIMER
#16	constant SDL_INIT_AUDIO
#32	constant SDL_INIT_VIDEO
#512	constant SDL_INIT_JOYSTICK
#4096	constant SDL_INIT_HAPTIC
#8192	constant SDL_INIT_GAMECONTROLLER
#16384	constant SDL_INIT_EVENTS
#32768	constant SDL_INIT_SENSOR
#1048576	constant SDL_INIT_NOPARACHUTE
#62001	constant SDL_INIT_EVERYTHING

\ ------===< functions >===-------
c-function SDL_Init SDL_Init n -- n	( flags -- )
c-function SDL_InitSubSystem SDL_InitSubSystem n -- n	( flags -- )
c-function SDL_QuitSubSystem SDL_QuitSubSystem n -- void	( flags -- )
c-function SDL_WasInit SDL_WasInit n -- n	( flags -- )
c-function SDL_Quit SDL_Quit  -- void	( -- )

\ ----===< postfix >===-----
end-c-library
