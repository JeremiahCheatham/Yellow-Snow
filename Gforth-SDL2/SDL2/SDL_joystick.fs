\ ----===< prefix >===-----
c-library sdl_joystick
s" SDL2" add-lib
\c #include <SDL2/SDL_joystick.h>

\ ----===< int constants >===-----
#1	constant SDL_VIRTUAL_JOYSTICK_DESC_VERSION
#32767	constant SDL_JOYSTICK_AXIS_MAX
#-32768	constant SDL_JOYSTICK_AXIS_MIN
#0	constant SDL_HAT_CENTERED
#1	constant SDL_HAT_UP
#2	constant SDL_HAT_RIGHT
#4	constant SDL_HAT_DOWN
#8	constant SDL_HAT_LEFT
#3	constant SDL_HAT_RIGHTUP
#6	constant SDL_HAT_RIGHTDOWN
#9	constant SDL_HAT_LEFTUP
#12	constant SDL_HAT_LEFTDOWN

\ ---===< float constants >===----
5.000000e0	fconstant SDL_IPHONE_MAX_GFORCE

\ --------===< enums >===---------
#0	constant SDL_JOYSTICK_TYPE_UNKNOWN
#1	constant SDL_JOYSTICK_TYPE_GAMECONTROLLER
#2	constant SDL_JOYSTICK_TYPE_WHEEL
#3	constant SDL_JOYSTICK_TYPE_ARCADE_STICK
#4	constant SDL_JOYSTICK_TYPE_FLIGHT_STICK
#5	constant SDL_JOYSTICK_TYPE_DANCE_PAD
#6	constant SDL_JOYSTICK_TYPE_GUITAR
#7	constant SDL_JOYSTICK_TYPE_DRUM_KIT
#8	constant SDL_JOYSTICK_TYPE_ARCADE_PAD
#9	constant SDL_JOYSTICK_TYPE_THROTTLE
#-1	constant SDL_JOYSTICK_POWER_UNKNOWN
#0	constant SDL_JOYSTICK_POWER_EMPTY
#1	constant SDL_JOYSTICK_POWER_LOW
#2	constant SDL_JOYSTICK_POWER_MEDIUM
#3	constant SDL_JOYSTICK_POWER_FULL
#4	constant SDL_JOYSTICK_POWER_WIRED
#5	constant SDL_JOYSTICK_POWER_MAX

\ -------===< structs >===--------
\ struct SDL_VirtualJoystickDesc
begin-structure SDL_VirtualJoystickDesc
	drop 4 2 +field SDL_VirtualJoystickDesc-naxes
	drop 24 8 +field SDL_VirtualJoystickDesc-name
	drop 56 8 +field SDL_VirtualJoystickDesc-Rumble
	drop 16 4 +field SDL_VirtualJoystickDesc-button_mask
	drop 64 8 +field SDL_VirtualJoystickDesc-RumbleTriggers
	drop 72 8 +field SDL_VirtualJoystickDesc-SetLED
	drop 8 2 +field SDL_VirtualJoystickDesc-nhats
	drop 80 8 +field SDL_VirtualJoystickDesc-SendEffect
	drop 2 2 +field SDL_VirtualJoystickDesc-type
	drop 0 2 +field SDL_VirtualJoystickDesc-version
	drop 32 8 +field SDL_VirtualJoystickDesc-userdata
	drop 12 2 +field SDL_VirtualJoystickDesc-product_id
	drop 14 2 +field SDL_VirtualJoystickDesc-padding
	drop 48 8 +field SDL_VirtualJoystickDesc-SetPlayerIndex
	drop 6 2 +field SDL_VirtualJoystickDesc-nbuttons
	drop 40 8 +field SDL_VirtualJoystickDesc-Update
	drop 10 2 +field SDL_VirtualJoystickDesc-vendor_id
	drop 20 4 +field SDL_VirtualJoystickDesc-axis_mask
drop 88 end-structure

\ --===< function pointers >===---
\ c-funptr SDL_VirtualJoystickDesc-Update() {((struct SDL_VirtualJoystickDesc*)ptr)->Update} a -- void	( userdata -- )
\ c-funptr SDL_VirtualJoystickDesc-SetPlayerIndex() {((struct SDL_VirtualJoystickDesc*)ptr)->SetPlayerIndex} a n -- void	( userdata player_index -- )
\ c-funptr SDL_VirtualJoystickDesc-Rumble() {((struct SDL_VirtualJoystickDesc*)ptr)->Rumble} a n n -- n	( userdata low_frequency_rumble high_frequency_rumble -- )
\ c-funptr SDL_VirtualJoystickDesc-RumbleTriggers() {((struct SDL_VirtualJoystickDesc*)ptr)->RumbleTriggers} a n n -- n	( userdata left_rumble right_rumble -- )
\ c-funptr SDL_VirtualJoystickDesc-SetLED() {((struct SDL_VirtualJoystickDesc*)ptr)->SetLED} a n n n -- n	( userdata red green blue -- )
\ c-funptr SDL_VirtualJoystickDesc-SendEffect() {((struct SDL_VirtualJoystickDesc*)ptr)->SendEffect} a a n -- n	( userdata data size -- )

\ ------===< functions >===-------
c-function SDL_LockJoysticks SDL_LockJoysticks  -- void	( -- )
c-function SDL_UnlockJoysticks SDL_UnlockJoysticks  -- void	( -- )
c-function SDL_NumJoysticks SDL_NumJoysticks  -- n	( -- )
c-function SDL_JoystickNameForIndex SDL_JoystickNameForIndex n -- a	( device_index -- )
c-function SDL_JoystickPathForIndex SDL_JoystickPathForIndex n -- a	( device_index -- )
c-function SDL_JoystickGetDevicePlayerIndex SDL_JoystickGetDevicePlayerIndex n -- n	( device_index -- )
\ c-function SDL_JoystickGetDeviceGUID SDL_JoystickGetDeviceGUID n -- n	( device_index -- )
c-function SDL_JoystickGetDeviceVendor SDL_JoystickGetDeviceVendor n -- n	( device_index -- )
c-function SDL_JoystickGetDeviceProduct SDL_JoystickGetDeviceProduct n -- n	( device_index -- )
c-function SDL_JoystickGetDeviceProductVersion SDL_JoystickGetDeviceProductVersion n -- n	( device_index -- )
c-function SDL_JoystickGetDeviceType SDL_JoystickGetDeviceType n -- n	( device_index -- )
c-function SDL_JoystickGetDeviceInstanceID SDL_JoystickGetDeviceInstanceID n -- n	( device_index -- )
c-function SDL_JoystickOpen SDL_JoystickOpen n -- a	( device_index -- )
c-function SDL_JoystickFromInstanceID SDL_JoystickFromInstanceID n -- a	( instance_id -- )
c-function SDL_JoystickFromPlayerIndex SDL_JoystickFromPlayerIndex n -- a	( player_index -- )
c-function SDL_JoystickAttachVirtual SDL_JoystickAttachVirtual n n n n -- n	( type naxes nbuttons nhats -- )
c-function SDL_JoystickAttachVirtualEx SDL_JoystickAttachVirtualEx a -- n	( desc -- )
c-function SDL_JoystickDetachVirtual SDL_JoystickDetachVirtual n -- n	( device_index -- )
c-function SDL_JoystickIsVirtual SDL_JoystickIsVirtual n -- n	( device_index -- )
c-function SDL_JoystickSetVirtualAxis SDL_JoystickSetVirtualAxis a n n -- n	( joystick axis value -- )
c-function SDL_JoystickSetVirtualButton SDL_JoystickSetVirtualButton a n n -- n	( joystick button value -- )
c-function SDL_JoystickSetVirtualHat SDL_JoystickSetVirtualHat a n n -- n	( joystick hat value -- )
c-function SDL_JoystickName SDL_JoystickName a -- a	( joystick -- )
c-function SDL_JoystickPath SDL_JoystickPath a -- a	( joystick -- )
c-function SDL_JoystickGetPlayerIndex SDL_JoystickGetPlayerIndex a -- n	( joystick -- )
c-function SDL_JoystickSetPlayerIndex SDL_JoystickSetPlayerIndex a n -- void	( joystick player_index -- )
\ c-function SDL_JoystickGetGUID SDL_JoystickGetGUID a -- n	( joystick -- )
c-function SDL_JoystickGetVendor SDL_JoystickGetVendor a -- n	( joystick -- )
c-function SDL_JoystickGetProduct SDL_JoystickGetProduct a -- n	( joystick -- )
c-function SDL_JoystickGetProductVersion SDL_JoystickGetProductVersion a -- n	( joystick -- )
c-function SDL_JoystickGetFirmwareVersion SDL_JoystickGetFirmwareVersion a -- n	( joystick -- )
c-function SDL_JoystickGetSerial SDL_JoystickGetSerial a -- a	( joystick -- )
c-function SDL_JoystickGetType SDL_JoystickGetType a -- n	( joystick -- )
\ c-function SDL_JoystickGetGUIDString SDL_JoystickGetGUIDString n a n -- void	( guid pszGUID cbGUID -- )
\ c-function SDL_JoystickGetGUIDFromString SDL_JoystickGetGUIDFromString a -- n	( pchGUID -- )
\ c-function SDL_GetJoystickGUIDInfo SDL_GetJoystickGUIDInfo n a a a a -- void	( guid vendor product version crc16 -- )
c-function SDL_JoystickGetAttached SDL_JoystickGetAttached a -- n	( joystick -- )
c-function SDL_JoystickInstanceID SDL_JoystickInstanceID a -- n	( joystick -- )
c-function SDL_JoystickNumAxes SDL_JoystickNumAxes a -- n	( joystick -- )
c-function SDL_JoystickNumBalls SDL_JoystickNumBalls a -- n	( joystick -- )
c-function SDL_JoystickNumHats SDL_JoystickNumHats a -- n	( joystick -- )
c-function SDL_JoystickNumButtons SDL_JoystickNumButtons a -- n	( joystick -- )
c-function SDL_JoystickUpdate SDL_JoystickUpdate  -- void	( -- )
c-function SDL_JoystickEventState SDL_JoystickEventState n -- n	( state -- )
c-function SDL_JoystickGetAxis SDL_JoystickGetAxis a n -- n	( joystick axis -- )
c-function SDL_JoystickGetAxisInitialState SDL_JoystickGetAxisInitialState a n a -- n	( joystick axis state -- )
c-function SDL_JoystickGetHat SDL_JoystickGetHat a n -- n	( joystick hat -- )
c-function SDL_JoystickGetBall SDL_JoystickGetBall a n a a -- n	( joystick ball dx dy -- )
c-function SDL_JoystickGetButton SDL_JoystickGetButton a n -- n	( joystick button -- )
c-function SDL_JoystickRumble SDL_JoystickRumble a n n n -- n	( joystick low_frequency_rumble high_frequency_rumble duration_ms -- )
c-function SDL_JoystickRumbleTriggers SDL_JoystickRumbleTriggers a n n n -- n	( joystick left_rumble right_rumble duration_ms -- )
c-function SDL_JoystickHasLED SDL_JoystickHasLED a -- n	( joystick -- )
c-function SDL_JoystickHasRumble SDL_JoystickHasRumble a -- n	( joystick -- )
c-function SDL_JoystickHasRumbleTriggers SDL_JoystickHasRumbleTriggers a -- n	( joystick -- )
c-function SDL_JoystickSetLED SDL_JoystickSetLED a n n n -- n	( joystick red green blue -- )
c-function SDL_JoystickSendEffect SDL_JoystickSendEffect a a n -- n	( joystick data size -- )
c-function SDL_JoystickClose SDL_JoystickClose a -- void	( joystick -- )
c-function SDL_JoystickCurrentPowerLevel SDL_JoystickCurrentPowerLevel a -- n	( joystick -- )

\ ----===< postfix >===-----
end-c-library
