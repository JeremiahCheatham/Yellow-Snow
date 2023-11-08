\ ----===< prefix >===-----
c-library sdl_mixer
s" SDL2_mixer" add-lib
\c #include <SDL2/SDL_mixer.h>

\ ----===< int constants >===-----
#2	constant SDL_MIXER_MAJOR_VERSION
#6	constant SDL_MIXER_MINOR_VERSION
#3	constant SDL_MIXER_PATCHLEVEL
#2	constant MIXER_MAJOR_VERSION
#6	constant MIXER_MINOR_VERSION
#3	constant MIXER_PATCHLEVEL

8 constant MIX_CHANNELS
44100 constant MIX_DEFAULT_FREQUENCY
0x8010 constant MIX_DEFAULT_FORMAT \ AUDIO_S16LSB 0x8010    AUDIO_S16MSB 0x9010
2 constant MIX_DEFAULT_CHANNELS
128 constant MIX_MAX_VOLUME

\ --------===< enums >===---------
0x00000001 constant MIX_INIT_FLAC
0x00000002 constant MIX_INIT_MOD
0x00000008 constant MIX_INIT_MP3
0x00000010 constant MIX_INIT_OGG
0x00000020 constant MIX_INIT_MID
0x00000040 constant MIX_INIT_OPUS

#0 constant MIX_NO_FADING
#1 constant MIX_FADING_OUT
#2 constant MIX_FADING_IN

#0 constant MUS_NONE
#1 constant MUS_CMD
#2 constant MUS_WAV
#3 constant MUS_MOD
#4 constant MUS_MID
#5 constant MUS_OGG
#6 constant MUS_MP3
#7 constant MUS_MP3_MAD_UNUSED
#8 constant MUS_FLAC
#9 constant MUS_MODPLUG_UNUSED
#10 constant MUS_OPUS


\ -------===< structs >===--------
\ struct Mix_Chunk
begin-structure Mix_Chunk
    drop 0 4 +field Mix_Chunk-allocated
    drop 4 1 +field Mix_Chunk-abuf
    drop 5 4 +field Mix_Chuck-alen
    drop 9 1 +field Mix_Chuck-volume
drop 10 end-structure

c-function Mix_OpenAudio Mix_OpenAudio n n n n -- n	( frequency format channels chunksize -- error )
c-function Mix_LoadMUS Mix_LoadMUS a -- a ( file -- music )
c-function Mix_PlayMusic Mix_PlayMusic a n -- n ( music loops -- error )
c-function Mix_LoadWAV Mix_LoadWAV a -- a ( file -- chunk )
c-function Mix_HaltMusic Mix_HaltMusic -- n ( -- 0 )
c-function Mix_PlayChannel Mix_PlayChannel n a n -- n ( channel chunk loops -- channel )
c-function Mix_FreeMusic Mix_FreeMusic a -- void ( music -- )
c-function Mix_FreeChunk Mix_FreeChunk a -- void ( chunk -- )
c-function Mix_Quit Mix_Quit -- void ( -- )

\ ----===< postfix >===-----
end-c-library
