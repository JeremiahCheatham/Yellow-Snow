\ ----===< prefix >===-----
c-library sdl_gamecontroller
s" SDL2" add-lib
\c #include <SDL2/SDL_gamecontroller.h>

\ --------===< enums >===---------
#0	constant SDL_CONTROLLER_TYPE_UNKNOWN
#1	constant SDL_CONTROLLER_TYPE_XBOX360
#2	constant SDL_CONTROLLER_TYPE_XBOXONE
#3	constant SDL_CONTROLLER_TYPE_PS3
#4	constant SDL_CONTROLLER_TYPE_PS4
#5	constant SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO
#6	constant SDL_CONTROLLER_TYPE_VIRTUAL
#7	constant SDL_CONTROLLER_TYPE_PS5
#8	constant SDL_CONTROLLER_TYPE_AMAZON_LUNA
#9	constant SDL_CONTROLLER_TYPE_GOOGLE_STADIA
#10	constant SDL_CONTROLLER_TYPE_NVIDIA_SHIELD
#11	constant SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_LEFT
#12	constant SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT
#13	constant SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_PAIR
#0	constant SDL_CONTROLLER_BINDTYPE_NONE
#1	constant SDL_CONTROLLER_BINDTYPE_BUTTON
#2	constant SDL_CONTROLLER_BINDTYPE_AXIS
#3	constant SDL_CONTROLLER_BINDTYPE_HAT
#-1	constant SDL_CONTROLLER_AXIS_INVALID
#0	constant SDL_CONTROLLER_AXIS_LEFTX
#1	constant SDL_CONTROLLER_AXIS_LEFTY
#2	constant SDL_CONTROLLER_AXIS_RIGHTX
#3	constant SDL_CONTROLLER_AXIS_RIGHTY
#4	constant SDL_CONTROLLER_AXIS_TRIGGERLEFT
#5	constant SDL_CONTROLLER_AXIS_TRIGGERRIGHT
#6	constant SDL_CONTROLLER_AXIS_MAX
#-1	constant SDL_CONTROLLER_BUTTON_INVALID
#0	constant SDL_CONTROLLER_BUTTON_A
#1	constant SDL_CONTROLLER_BUTTON_B
#2	constant SDL_CONTROLLER_BUTTON_X
#3	constant SDL_CONTROLLER_BUTTON_Y
#4	constant SDL_CONTROLLER_BUTTON_BACK
#5	constant SDL_CONTROLLER_BUTTON_GUIDE
#6	constant SDL_CONTROLLER_BUTTON_START
#7	constant SDL_CONTROLLER_BUTTON_LEFTSTICK
#8	constant SDL_CONTROLLER_BUTTON_RIGHTSTICK
#9	constant SDL_CONTROLLER_BUTTON_LEFTSHOULDER
#10	constant SDL_CONTROLLER_BUTTON_RIGHTSHOULDER
#11	constant SDL_CONTROLLER_BUTTON_DPAD_UP
#12	constant SDL_CONTROLLER_BUTTON_DPAD_DOWN
#13	constant SDL_CONTROLLER_BUTTON_DPAD_LEFT
#14	constant SDL_CONTROLLER_BUTTON_DPAD_RIGHT
#15	constant SDL_CONTROLLER_BUTTON_MISC1
#16	constant SDL_CONTROLLER_BUTTON_PADDLE1
#17	constant SDL_CONTROLLER_BUTTON_PADDLE2
#18	constant SDL_CONTROLLER_BUTTON_PADDLE3
#19	constant SDL_CONTROLLER_BUTTON_PADDLE4
#20	constant SDL_CONTROLLER_BUTTON_TOUCHPAD
#21	constant SDL_CONTROLLER_BUTTON_MAX

\ -------===< structs >===--------
\ struct SDL_GameControllerButtonBind
begin-structure SDL_GameControllerButtonBind
	drop 0 4 +field SDL_GameControllerButtonBind-bindType
	drop 4 8 +field SDL_GameControllerButtonBind-value
drop 12 end-structure
\ SDL_GameControllerButtonBind_value
begin-structure SDL_GameControllerButtonBind_value
	drop 0 4 +field SDL_GameControllerButtonBind_value-button
	drop 0 4 +field SDL_GameControllerButtonBind_value-axis
	drop 0 8 +field SDL_GameControllerButtonBind_value-hat
drop 8 end-structure
\ SDL_GameControllerButtonBind_value_hat
begin-structure SDL_GameControllerButtonBind_value_hat
	drop 4 4 +field SDL_GameControllerButtonBind_value_hat-hat_mask
	drop 0 4 +field SDL_GameControllerButtonBind_value_hat-hat
drop 8 end-structure

\ ------===< functions >===-------
c-function SDL_GameControllerAddMappingsFromRW SDL_GameControllerAddMappingsFromRW a n -- n	( rw freerw -- )
c-function SDL_GameControllerAddMapping SDL_GameControllerAddMapping a -- n	( mappingString -- )
c-function SDL_GameControllerNumMappings SDL_GameControllerNumMappings  -- n	( -- )
c-function SDL_GameControllerMappingForIndex SDL_GameControllerMappingForIndex n -- a	( mapping_index -- )
\ c-function SDL_GameControllerMappingForGUID SDL_GameControllerMappingForGUID n -- a	( guid -- )
c-function SDL_GameControllerMapping SDL_GameControllerMapping a -- a	( gamecontroller -- )
c-function SDL_IsGameController SDL_IsGameController n -- n	( joystick_index -- )
c-function SDL_GameControllerNameForIndex SDL_GameControllerNameForIndex n -- a	( joystick_index -- )
c-function SDL_GameControllerPathForIndex SDL_GameControllerPathForIndex n -- a	( joystick_index -- )
c-function SDL_GameControllerTypeForIndex SDL_GameControllerTypeForIndex n -- n	( joystick_index -- )
c-function SDL_GameControllerMappingForDeviceIndex SDL_GameControllerMappingForDeviceIndex n -- a	( joystick_index -- )
c-function SDL_GameControllerOpen SDL_GameControllerOpen n -- a	( joystick_index -- )
c-function SDL_GameControllerFromInstanceID SDL_GameControllerFromInstanceID n -- a	( joyid -- )
c-function SDL_GameControllerFromPlayerIndex SDL_GameControllerFromPlayerIndex n -- a	( player_index -- )
c-function SDL_GameControllerName SDL_GameControllerName a -- a	( gamecontroller -- )
c-function SDL_GameControllerPath SDL_GameControllerPath a -- a	( gamecontroller -- )
c-function SDL_GameControllerGetType SDL_GameControllerGetType a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetPlayerIndex SDL_GameControllerGetPlayerIndex a -- n	( gamecontroller -- )
c-function SDL_GameControllerSetPlayerIndex SDL_GameControllerSetPlayerIndex a n -- void	( gamecontroller player_index -- )
c-function SDL_GameControllerGetVendor SDL_GameControllerGetVendor a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetProduct SDL_GameControllerGetProduct a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetProductVersion SDL_GameControllerGetProductVersion a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetFirmwareVersion SDL_GameControllerGetFirmwareVersion a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetSerial SDL_GameControllerGetSerial a -- a	( gamecontroller -- )
c-function SDL_GameControllerGetAttached SDL_GameControllerGetAttached a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetJoystick SDL_GameControllerGetJoystick a -- a	( gamecontroller -- )
c-function SDL_GameControllerEventState SDL_GameControllerEventState n -- n	( state -- )
c-function SDL_GameControllerUpdate SDL_GameControllerUpdate  -- void	( -- )
c-function SDL_GameControllerGetAxisFromString SDL_GameControllerGetAxisFromString a -- n	( str -- )
c-function SDL_GameControllerGetStringForAxis SDL_GameControllerGetStringForAxis n -- a	( axis -- )
\ c-function SDL_GameControllerGetBindForAxis SDL_GameControllerGetBindForAxis a n -- struct	( gamecontroller axis -- )
c-function SDL_GameControllerHasAxis SDL_GameControllerHasAxis a n -- n	( gamecontroller axis -- )
c-function SDL_GameControllerGetAxis SDL_GameControllerGetAxis a n -- n	( gamecontroller axis -- )
c-function SDL_GameControllerGetButtonFromString SDL_GameControllerGetButtonFromString a -- n	( str -- )
c-function SDL_GameControllerGetStringForButton SDL_GameControllerGetStringForButton n -- a	( button -- )
\ c-function SDL_GameControllerGetBindForButton SDL_GameControllerGetBindForButton a n -- struct	( gamecontroller button -- )
c-function SDL_GameControllerHasButton SDL_GameControllerHasButton a n -- n	( gamecontroller button -- )
c-function SDL_GameControllerGetButton SDL_GameControllerGetButton a n -- n	( gamecontroller button -- )
c-function SDL_GameControllerGetNumTouchpads SDL_GameControllerGetNumTouchpads a -- n	( gamecontroller -- )
c-function SDL_GameControllerGetNumTouchpadFingers SDL_GameControllerGetNumTouchpadFingers a n -- n	( gamecontroller touchpad -- )
c-function SDL_GameControllerGetTouchpadFinger SDL_GameControllerGetTouchpadFinger a n n a a a a -- n	( gamecontroller touchpad finger state x y pressure -- )
c-function SDL_GameControllerHasSensor SDL_GameControllerHasSensor a n -- n	( gamecontroller type -- )
c-function SDL_GameControllerSetSensorEnabled SDL_GameControllerSetSensorEnabled a n n -- n	( gamecontroller type enabled -- )
c-function SDL_GameControllerIsSensorEnabled SDL_GameControllerIsSensorEnabled a n -- n	( gamecontroller type -- )
c-function SDL_GameControllerGetSensorDataRate SDL_GameControllerGetSensorDataRate a n -- r	( gamecontroller type -- )
c-function SDL_GameControllerGetSensorData SDL_GameControllerGetSensorData a n a n -- n	( gamecontroller type data num_values -- )
c-function SDL_GameControllerGetSensorDataWithTimestamp SDL_GameControllerGetSensorDataWithTimestamp a n a a n -- n	( gamecontroller type timestamp data num_values -- )
c-function SDL_GameControllerRumble SDL_GameControllerRumble a n n n -- n	( gamecontroller low_frequency_rumble high_frequency_rumble duration_ms -- )
c-function SDL_GameControllerRumbleTriggers SDL_GameControllerRumbleTriggers a n n n -- n	( gamecontroller left_rumble right_rumble duration_ms -- )
c-function SDL_GameControllerHasLED SDL_GameControllerHasLED a -- n	( gamecontroller -- )
c-function SDL_GameControllerHasRumble SDL_GameControllerHasRumble a -- n	( gamecontroller -- )
c-function SDL_GameControllerHasRumbleTriggers SDL_GameControllerHasRumbleTriggers a -- n	( gamecontroller -- )
c-function SDL_GameControllerSetLED SDL_GameControllerSetLED a n n n -- n	( gamecontroller red green blue -- )
c-function SDL_GameControllerSendEffect SDL_GameControllerSendEffect a a n -- n	( gamecontroller data size -- )
c-function SDL_GameControllerClose SDL_GameControllerClose a -- void	( gamecontroller -- )
c-function SDL_GameControllerGetAppleSFSymbolsNameForButton SDL_GameControllerGetAppleSFSymbolsNameForButton a n -- a	( gamecontroller button -- )
c-function SDL_GameControllerGetAppleSFSymbolsNameForAxis SDL_GameControllerGetAppleSFSymbolsNameForAxis a n -- a	( gamecontroller axis -- )

\ ----===< postfix >===-----
end-c-library
