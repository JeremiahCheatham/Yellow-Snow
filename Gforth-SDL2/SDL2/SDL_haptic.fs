\ ----===< prefix >===-----
c-library sdl_haptic
s" SDL2" add-lib
\c #include <SDL2/SDL_haptic.h>

\ ----===< int constants >===-----
#1	constant SDL_HAPTIC_CONSTANT
#2	constant SDL_HAPTIC_SINE
#4	constant SDL_HAPTIC_LEFTRIGHT
#8	constant SDL_HAPTIC_TRIANGLE
#16	constant SDL_HAPTIC_SAWTOOTHUP
#32	constant SDL_HAPTIC_SAWTOOTHDOWN
#64	constant SDL_HAPTIC_RAMP
#128	constant SDL_HAPTIC_SPRING
#256	constant SDL_HAPTIC_DAMPER
#512	constant SDL_HAPTIC_INERTIA
#1024	constant SDL_HAPTIC_FRICTION
#2048	constant SDL_HAPTIC_CUSTOM
#4096	constant SDL_HAPTIC_GAIN
#8192	constant SDL_HAPTIC_AUTOCENTER
#16384	constant SDL_HAPTIC_STATUS
#32768	constant SDL_HAPTIC_PAUSE
#0	constant SDL_HAPTIC_POLAR
#1	constant SDL_HAPTIC_CARTESIAN
#2	constant SDL_HAPTIC_SPHERICAL
#3	constant SDL_HAPTIC_STEERING_AXIS
#4294967295	constant SDL_HAPTIC_INFINITY

\ -------===< structs >===--------
\ struct SDL_HapticDirection
begin-structure SDL_HapticDirection
	drop 0 1 +field SDL_HapticDirection-type
	drop 4 12 +field SDL_HapticDirection-dir
drop 16 end-structure
\ struct SDL_HapticConstant
begin-structure SDL_HapticConstant
	drop 30 2 +field SDL_HapticConstant-level
	drop 24 2 +field SDL_HapticConstant-delay
	drop 26 2 +field SDL_HapticConstant-button
	drop 28 2 +field SDL_HapticConstant-interval
	drop 32 2 +field SDL_HapticConstant-attack_length
	drop 36 2 +field SDL_HapticConstant-fade_length
	drop 0 2 +field SDL_HapticConstant-type
	drop 20 4 +field SDL_HapticConstant-length
	drop 34 2 +field SDL_HapticConstant-attack_level
	drop 38 2 +field SDL_HapticConstant-fade_level
	drop 4 16 +field SDL_HapticConstant-direction
drop 40 end-structure
\ struct SDL_HapticPeriodic
begin-structure SDL_HapticPeriodic
	drop 4 16 +field SDL_HapticPeriodic-direction
	drop 20 4 +field SDL_HapticPeriodic-length
	drop 44 2 +field SDL_HapticPeriodic-fade_level
	drop 40 2 +field SDL_HapticPeriodic-attack_level
	drop 28 2 +field SDL_HapticPeriodic-interval
	drop 26 2 +field SDL_HapticPeriodic-button
	drop 42 2 +field SDL_HapticPeriodic-fade_length
	drop 38 2 +field SDL_HapticPeriodic-attack_length
	drop 34 2 +field SDL_HapticPeriodic-offset
	drop 32 2 +field SDL_HapticPeriodic-magnitude
	drop 30 2 +field SDL_HapticPeriodic-period
	drop 0 2 +field SDL_HapticPeriodic-type
	drop 36 2 +field SDL_HapticPeriodic-phase
	drop 24 2 +field SDL_HapticPeriodic-delay
drop 48 end-structure
\ struct SDL_HapticCondition
begin-structure SDL_HapticCondition
	drop 30 6 +field SDL_HapticCondition-right_sat
	drop 42 6 +field SDL_HapticCondition-right_coeff
	drop 48 6 +field SDL_HapticCondition-left_coeff
	drop 24 2 +field SDL_HapticCondition-delay
	drop 54 6 +field SDL_HapticCondition-deadband
	drop 26 2 +field SDL_HapticCondition-button
	drop 28 2 +field SDL_HapticCondition-interval
	drop 36 6 +field SDL_HapticCondition-left_sat
	drop 0 2 +field SDL_HapticCondition-type
	drop 20 4 +field SDL_HapticCondition-length
	drop 60 6 +field SDL_HapticCondition-center
	drop 4 16 +field SDL_HapticCondition-direction
drop 68 end-structure
\ struct SDL_HapticRamp
begin-structure SDL_HapticRamp
	drop 32 2 +field SDL_HapticRamp-end
	drop 24 2 +field SDL_HapticRamp-delay
	drop 26 2 +field SDL_HapticRamp-button
	drop 28 2 +field SDL_HapticRamp-interval
	drop 34 2 +field SDL_HapticRamp-attack_length
	drop 38 2 +field SDL_HapticRamp-fade_length
	drop 0 2 +field SDL_HapticRamp-type
	drop 20 4 +field SDL_HapticRamp-length
	drop 30 2 +field SDL_HapticRamp-start
	drop 36 2 +field SDL_HapticRamp-attack_level
	drop 40 2 +field SDL_HapticRamp-fade_level
	drop 4 16 +field SDL_HapticRamp-direction
drop 44 end-structure
\ struct SDL_HapticLeftRight
begin-structure SDL_HapticLeftRight
	drop 0 2 +field SDL_HapticLeftRight-type
	drop 4 4 +field SDL_HapticLeftRight-length
	drop 8 2 +field SDL_HapticLeftRight-large_magnitude
	drop 10 2 +field SDL_HapticLeftRight-small_magnitude
drop 12 end-structure
\ struct SDL_HapticCustom
begin-structure SDL_HapticCustom
	drop 4 16 +field SDL_HapticCustom-direction
	drop 20 4 +field SDL_HapticCustom-length
	drop 54 2 +field SDL_HapticCustom-fade_level
	drop 50 2 +field SDL_HapticCustom-attack_level
	drop 28 2 +field SDL_HapticCustom-interval
	drop 26 2 +field SDL_HapticCustom-button
	drop 34 2 +field SDL_HapticCustom-samples
	drop 52 2 +field SDL_HapticCustom-fade_length
	drop 48 2 +field SDL_HapticCustom-attack_length
	drop 30 1 +field SDL_HapticCustom-channels
	drop 32 2 +field SDL_HapticCustom-period
	drop 0 2 +field SDL_HapticCustom-type
	drop 24 2 +field SDL_HapticCustom-delay
	drop 40 8 +field SDL_HapticCustom-data
drop 56 end-structure
\ union SDL_HapticEffect
begin-structure SDL_HapticEffect
	drop 0 68 +field SDL_HapticEffect-condition
	drop 0 44 +field SDL_HapticEffect-ramp
	drop 0 40 +field SDL_HapticEffect-constant
	drop 0 12 +field SDL_HapticEffect-leftright
	drop 0 56 +field SDL_HapticEffect-custom
	drop 0 2 +field SDL_HapticEffect-type
	drop 0 48 +field SDL_HapticEffect-periodic
drop 72 end-structure

\ ------===< functions >===-------
c-function SDL_NumHaptics SDL_NumHaptics  -- n	( -- )
c-function SDL_HapticName SDL_HapticName n -- a	( device_index -- )
c-function SDL_HapticOpen SDL_HapticOpen n -- a	( device_index -- )
c-function SDL_HapticOpened SDL_HapticOpened n -- n	( device_index -- )
c-function SDL_HapticIndex SDL_HapticIndex a -- n	( haptic -- )
c-function SDL_MouseIsHaptic SDL_MouseIsHaptic  -- n	( -- )
c-function SDL_HapticOpenFromMouse SDL_HapticOpenFromMouse  -- a	( -- )
c-function SDL_JoystickIsHaptic SDL_JoystickIsHaptic a -- n	( joystick -- )
c-function SDL_HapticOpenFromJoystick SDL_HapticOpenFromJoystick a -- a	( joystick -- )
c-function SDL_HapticClose SDL_HapticClose a -- void	( haptic -- )
c-function SDL_HapticNumEffects SDL_HapticNumEffects a -- n	( haptic -- )
c-function SDL_HapticNumEffectsPlaying SDL_HapticNumEffectsPlaying a -- n	( haptic -- )
c-function SDL_HapticQuery SDL_HapticQuery a -- n	( haptic -- )
c-function SDL_HapticNumAxes SDL_HapticNumAxes a -- n	( haptic -- )
c-function SDL_HapticEffectSupported SDL_HapticEffectSupported a a -- n	( haptic effect -- )
c-function SDL_HapticNewEffect SDL_HapticNewEffect a a -- n	( haptic effect -- )
c-function SDL_HapticUpdateEffect SDL_HapticUpdateEffect a n a -- n	( haptic effect data -- )
c-function SDL_HapticRunEffect SDL_HapticRunEffect a n n -- n	( haptic effect iterations -- )
c-function SDL_HapticStopEffect SDL_HapticStopEffect a n -- n	( haptic effect -- )
c-function SDL_HapticDestroyEffect SDL_HapticDestroyEffect a n -- void	( haptic effect -- )
c-function SDL_HapticGetEffectStatus SDL_HapticGetEffectStatus a n -- n	( haptic effect -- )
c-function SDL_HapticSetGain SDL_HapticSetGain a n -- n	( haptic gain -- )
c-function SDL_HapticSetAutocenter SDL_HapticSetAutocenter a n -- n	( haptic autocenter -- )
c-function SDL_HapticPause SDL_HapticPause a -- n	( haptic -- )
c-function SDL_HapticUnpause SDL_HapticUnpause a -- n	( haptic -- )
c-function SDL_HapticStopAll SDL_HapticStopAll a -- n	( haptic -- )
c-function SDL_HapticRumbleSupported SDL_HapticRumbleSupported a -- n	( haptic -- )
c-function SDL_HapticRumbleInit SDL_HapticRumbleInit a -- n	( haptic -- )
c-function SDL_HapticRumblePlay SDL_HapticRumblePlay a r n -- n	( haptic strength length -- )
c-function SDL_HapticRumbleStop SDL_HapticRumbleStop a -- n	( haptic -- )

\ ----===< postfix >===-----
end-c-library
