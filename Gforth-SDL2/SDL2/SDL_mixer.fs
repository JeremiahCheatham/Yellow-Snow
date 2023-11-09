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
#6 constant MUS_MP3j
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

\ ------===< functions >===-------
c-function Mix_GetError SDL_GetError  -- a	( -- string )
c-function Mix_ClearError SDL_ClearError  -- void	( -- )
c-function Mix_Linked_Version Mix_Linked_Version -- a ( -- version)
c-function Mix_Init Mix_Init n -- n ( flags -- flakes)
c-function Mix_Quit Mix_Quit -- void ( -- )
c-function Mix_OpenAudio Mix_OpenAudio n n n n -- n	( frequency format channels chunksize -- error )
c-function Mix_OpenAudioDevice Mix_OpenAudioDevice n n n n a n -- n ( frequency format channels chunksize device allowed_changes -- error)
c-function Mix_QuerySpec Mix_QuerySpec a a a -- n ( frequency format channels -- success )
c-function Mix_AllocateChannels Mix_AllocateChannels n -- n ( numchans -- numchans )
c-function Mix_LoadWAV_RW Mix_LoadWAV_RW a n -- a ( src freesrc -- chunk )
c-function Mix_LoadWAV Mix_LoadWAV a -- a ( file -- chunk )
c-function Mix_LoadMUS Mix_LoadMUS a -- a ( file -- music )
c-function Mix_LoadMUS_RW Mix_LoadMUS_RW a n -- a ( src freesrc -- music )
c-function Mix_LoadMUSType_RW Mix_LoadMUSType_RW a n n -- a ( src type freesrc -- music )
c-function Mix_QuickLoad_WAV Mix_QuickLoad_WAV a -- a ( mem -- chunk )
c-function Mix_QuickLoad_RAW Mix_QuickLoad_RAW a n -- a ( mem len -- chunk )
c-function Mix_FreeChunk Mix_FreeChunk a -- void ( chunk -- )
c-function Mix_FreeMusic Mix_FreeMusic a -- void ( music -- )

c-function Mix_GetNumChunkDecoders Mix_GetNumChunkDecoders -- n ( -- decoders )
c-function Mix_GetChunkDecoder Mix_GetChunkDecoder n -- a ( index -- decoder )
c-function Mix_HasChunkDecoder Mix_HasChunkDecoder a -- n ( name -- bool )
c-function Mix_GetNumMusicDecoders Mix_GetNumMusicDecoders -- n ( -- decoders )
c-function Mix_GetMusicDecoder Mix_GetMusicDecoder n -- a ( index -- decoder )
c-function Mix_HasMusicDecoder Mix_HasMusicDecoder a -- n ( name -- bool )
c-function Mix_GetMusicType Mix_GetMusicType a -- a ( music -- type )
c-function Mix_GetMusicTitle Mix_GetMusicTitle a -- a ( music -- title )
c-function Mix_GetMusicTitleTag Mix_GetMusicTitleTag a -- a ( music -- tag )
c-function Mix_GetMusicArtistTag Mix_GetMusicArtistTag a -- a ( music -- artist )
c-function Mix_GetMusicAlbumTag Mix_GetMusicAlbumTag a -- a ( music -- album )
c-function Mix_GetMusicCopyrightTag Mix_GetMusicCopyrightTag a -- a ( music -- copyright)
\ c-function Mix_SetPostMix(void (SDLCALL *mix_func)(void *udata, Uint8 *stream, int len), void *arg);
\ c-function Mix_HookMusic(void (SDLCALL *mix_func)(void *udata, Uint8 *stream, int len), void *arg);
\ c-function Mix_HookMusicFinished(void (SDLCALL *music_finished)(void));
c-function Mix_GetMusicHookData Mix_GetMusicHookData -- void ( -- )
\ c-function Mix_ChannelFinished(void (SDLCALL *channel_finished)(int channel));
\ c-function Mix_RegisterEffect Mix_RegisterEffect n n n a -- n ( chan f d arg -- success )
\ c-function Mix_UnregisterEffect Mix_UnregisterEffect n n -- n ( channel f -- success )
\ c-function Mix_UnregisterAllEffects Mix_UnregisterAllEffects -- n ( channel -- success )
c-function Mix_SetPanning Mix_SetPanning n n n -- n ( channel left right -- bool )
c-function Mix_SetPosition Mix_SetPosition n n n -- n ( channel angle distance -- bool )
c-function Mix_SetDistance Mix_SetDistance n n -- n ( channel distance -- bool )
c-function Mix_SetReverseStereo Mix_SetReverseStereo n n -- n ( channel flip -- bool )
c-function MMix_ReserveChannels Mix_ReserveChannels n -- n ( num -- bool )
c-function Mix_GroupChannel Mix_GroupChannel n n -- n ( which tag -- bool )
c-function Mix_GroupChannels Mix_GroupChannels n n n -- n ( from to tag -- bool )
c-function Mix_GroupAvailable Mix_GroupAvailable n -- n ( tag -- channel )
c-function Mix_GroupCount Mix_GroupCount n -- n ( tag -- count )
c-function Mix_GroupOldest Mix_GroupOldest n -- n ( tag -- oldest )
c-function Mix_GroupNewer Mix_GroupNewer n -- n ( tag -- newest )
c-function Mix_PlayChannel Mix_PlayChannel n a n -- n ( channel chunk loops -- channel )
c-function Mix_PlayChannelTimed Mix_PlayChannelTimed n a n n -- n ( channel chunk loops ticks -- bool )
c-function Mix_PlayMusic Mix_PlayMusic a n -- n ( music loops -- error )
c-function Mix_FadeInMusic Mix_FadeInMusic a n n -- n ( music loops ms -- bool )
c-function Mix_FadeInMusicPos Mix_FadeInMusicPos a n n n -- n ( music loops ms position -- bool )
c-function Mix_FadeInChannel Mix_FadeInChannel n a n n -- n ( channel chunk loops ms -- channel )
c-function Mix_FadeInChannelTimed Mix_FadeInChannelTimed n a n n n -- n ( channel chunk loops ms ticks -- channel )
c-function Mix_Volume Mix_Volume n n -- n ( channel volume -- volume )
c-function Mix_VolumeChunk Mix_VolumeChunk a n -- n ( chunk volume -- volume )
c-function Mix_VolumeMusic Mix_VolumeMusic n -- n ( volume -- volume )
c-function Mix_GetMusicVolume Mix_GetMusicVolume a -- n ( music -- volume )
c-function Mix_MasterVolume Mix_MasterVolume n -- n ( volume -- volume )
c-function Mix_HaltChannel Mix_HaltChannel n -- n ( channel -- bool )
c-function Mix_HaltGroup Mix_HaltGroup n -- n ( tag -- 0 )
c-function Mix_HaltMusic Mix_HaltMusic -- n ( -- 0 )
c-function Mix_ExpireChannel Mix_ExpireChannel n n -- n ( channel ticks -- channels )
c-function Mix_FadeOutChannel Mix_FadeOutChannel n n -- n ( which ms -- channels )
c-function Mix_FadeOutGroup Mix_FadeOutGroup n n -- n ( tag ms -- channels )
c-function Mix_FadeOutMusic Mix_FadeOutMusic n -- n ( ms -- bool )
c-function Mix_FadingMusic Mix_FadingMusic -- n ( -- status )
c-function Mix_FadingChannel Mix_FadingChannel n -- n ( which -- status )
c-function Mix_Pause Mix_Pause n -- void ( channel -- )
c-function Mix_Resume Mix_Resume n -- void ( channel -- )
c-function Mix_Paused Mix_Paused n -- n ( channel -- bool )
c-function Mix_PauseMusic Mix_PauseMusic -- void ( -- void )
c-function Mix_ResumeMusic Mix_ResumeMusic -- void ( -- void )
c-function Mix_RewindMusic Mix_RewindMusic -- void ( -- void )
c-function Mix_PausedMusic Mix_PausedMusic -- n ( -- bool )
c-function Mix_ModMusicJumpToOrder Mix_ModMusicJumpToOrder n -- n ( order -- bool )
c-function Mix_SetMusicPosition Mix_SetMusicPosition n -- n ( position -- bool )
c-function Mix_GetMusicPosition Mix_GetMusicPosition a -- n ( music -- position )
c-function Mix_MusicDuration Mix_MusicDuration a -- n ( music -- duration )
c-function Mix_GetMusicLoopStartTime Mix_GetMusicLoopStartTime a -- n ( music -- time )
c-function Mix_GetMusicLoopEndTime Mix_GetMusicLoopEndTime a -- n ( music -- time )
c-function Mix_GetMusicLoopLengthTime Mix_GetMusicLoopLengthTime a -- n ( music -- time )
c-function Mix_Playing Mix_Playing n -- n ( channel -- bool )
c-function Mix_PlayingMusic Mix_PlayingMusic -- n ( -- bool )
c-function Mix_SetMusicCMD Mix_SetMusicCMD a -- n ( command -- bool )
c-function Mix_SetSoundFonts Mix_SetSoundFonts a -- n ( paths -- bool )
c-function Mix_GetSoundFonts Mix_GetSoundFonts -- a ( -- fonts-list )
\ extern DECLSPEC int SDLCALL Mix_EachSoundFont(int (SDLCALL *function)(const char*, void*), void *data);
c-function Mix_SetTimidityCfg Mix_SetTimidityCfg a -- n ( path -- bool )
c-function Mix_GetTimidityCfg Mix_GetTimidityCfg -- a ( -- path )
c-function Mix_GetChunk Mix_GetChunk n -- a ( channel -- chunk )
c-function Mix_CloseAudio Mix_CloseAudio -- void ( -- void )

\ ----===< postfix >===-----
end-c-library
