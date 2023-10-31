\ ----===< prefix >===-----
c-library sdl_events
s" SDL2" add-lib
\c #include <SDL2/SDL_events.h>

\ ----===< int constants >===-----
#0	constant SDL_RELEASED
#1	constant SDL_PRESSED
#32	constant SDL_TEXTEDITINGEVENT_TEXT_SIZE
#32	constant SDL_TEXTINPUTEVENT_TEXT_SIZE
#-1	constant SDL_QUERY
#0	constant SDL_IGNORE
#0	constant SDL_DISABLE
#1	constant SDL_ENABLE

\ --------===< enums >===---------
#0	constant SDL_FIRSTEVENT
#256	constant SDL_QUIT_ENUM
#257	constant SDL_APP_TERMINATING
#258	constant SDL_APP_LOWMEMORY
#259	constant SDL_APP_WILLENTERBACKGROUND
#260	constant SDL_APP_DIDENTERBACKGROUND
#261	constant SDL_APP_WILLENTERFOREGROUND
#262	constant SDL_APP_DIDENTERFOREGROUND
#263	constant SDL_LOCALECHANGED
#336	constant SDL_DISPLAYEVENT_ENUM
#512	constant SDL_WINDOWEVENT_ENUM
#513	constant SDL_SYSWMEVENT_ENUM
#768	constant SDL_KEYDOWN
#769	constant SDL_KEYUP
#770	constant SDL_TEXTEDITING
#771	constant SDL_TEXTINPUT
#772	constant SDL_KEYMAPCHANGED
#773	constant SDL_TEXTEDITING_EXT
#1024	constant SDL_MOUSEMOTION
#1025	constant SDL_MOUSEBUTTONDOWN
#1026	constant SDL_MOUSEBUTTONUP
#1027	constant SDL_MOUSEWHEEL
#1536	constant SDL_JOYAXISMOTION
#1537	constant SDL_JOYBALLMOTION
#1538	constant SDL_JOYHATMOTION
#1539	constant SDL_JOYBUTTONDOWN
#1540	constant SDL_JOYBUTTONUP
#1541	constant SDL_JOYDEVICEADDED
#1542	constant SDL_JOYDEVICEREMOVED
#1543	constant SDL_JOYBATTERYUPDATED
#1616	constant SDL_CONTROLLERAXISMOTION
#1617	constant SDL_CONTROLLERBUTTONDOWN
#1618	constant SDL_CONTROLLERBUTTONUP
#1619	constant SDL_CONTROLLERDEVICEADDED
#1620	constant SDL_CONTROLLERDEVICEREMOVED
#1621	constant SDL_CONTROLLERDEVICEREMAPPED
#1622	constant SDL_CONTROLLERTOUCHPADDOWN
#1623	constant SDL_CONTROLLERTOUCHPADMOTION
#1624	constant SDL_CONTROLLERTOUCHPADUP
#1625	constant SDL_CONTROLLERSENSORUPDATE
#1792	constant SDL_FINGERDOWN
#1793	constant SDL_FINGERUP
#1794	constant SDL_FINGERMOTION
#2048	constant SDL_DOLLARGESTURE
#2049	constant SDL_DOLLARRECORD
#2050	constant SDL_MULTIGESTURE
#2304	constant SDL_CLIPBOARDUPDATE
#4096	constant SDL_DROPFILE
#4097	constant SDL_DROPTEXT
#4098	constant SDL_DROPBEGIN
#4099	constant SDL_DROPCOMPLETE
#4352	constant SDL_AUDIODEVICEADDED
#4353	constant SDL_AUDIODEVICEREMOVED
#4608	constant SDL_SENSORUPDATE_ENUM
#8192	constant SDL_RENDER_TARGETS_RESET
#8193	constant SDL_RENDER_DEVICE_RESET
#32512	constant SDL_POLLSENTINEL
#32768	constant SDL_USEREVENT_ENUM
#65535	constant SDL_LASTEVENT
#0	constant SDL_ADDEVENT
#1	constant SDL_PEEKEVENT
#2	constant SDL_GETEVENT

\ -------===< structs >===--------
\ struct SDL_CommonEvent
begin-structure SDL_CommonEvent
	drop 0 4 +field SDL_CommonEvent-type
	drop 4 4 +field SDL_CommonEvent-timestamp
drop 8 end-structure
\ struct SDL_DisplayEvent
begin-structure SDL_DisplayEvent
	drop 8 4 +field SDL_DisplayEvent-display
	drop 0 4 +field SDL_DisplayEvent-type
	drop 13 1 +field SDL_DisplayEvent-padding1
	drop 16 4 +field SDL_DisplayEvent-data1
	drop 4 4 +field SDL_DisplayEvent-timestamp
	drop 14 1 +field SDL_DisplayEvent-padding2
	drop 12 1 +field SDL_DisplayEvent-event
	drop 15 1 +field SDL_DisplayEvent-padding3
drop 20 end-structure
\ struct SDL_WindowEvent
begin-structure SDL_WindowEvent
	drop 8 4 +field SDL_WindowEvent-windowID
	drop 0 4 +field SDL_WindowEvent-type
	drop 13 1 +field SDL_WindowEvent-padding1
	drop 16 4 +field SDL_WindowEvent-data1
	drop 4 4 +field SDL_WindowEvent-timestamp
	drop 14 1 +field SDL_WindowEvent-padding2
	drop 20 4 +field SDL_WindowEvent-data2
	drop 12 1 +field SDL_WindowEvent-event
	drop 15 1 +field SDL_WindowEvent-padding3
drop 24 end-structure
\ struct SDL_KeyboardEvent
begin-structure SDL_KeyboardEvent
	drop 8 4 +field SDL_KeyboardEvent-windowID
	drop 0 4 +field SDL_KeyboardEvent-type
	drop 4 4 +field SDL_KeyboardEvent-timestamp
	drop 12 1 +field SDL_KeyboardEvent-state
	drop 14 1 +field SDL_KeyboardEvent-padding2
	drop 13 1 +field SDL_KeyboardEvent-repeat
	drop 15 1 +field SDL_KeyboardEvent-padding3
	drop 16 16 +field SDL_KeyboardEvent-keysym
drop 32 end-structure
\ struct SDL_TextEditingEvent
begin-structure SDL_TextEditingEvent
	drop 8 4 +field SDL_TextEditingEvent-windowID
	drop 0 4 +field SDL_TextEditingEvent-type
	drop 12 32 +field SDL_TextEditingEvent-text
	drop 48 4 +field SDL_TextEditingEvent-length
	drop 4 4 +field SDL_TextEditingEvent-timestamp
	drop 44 4 +field SDL_TextEditingEvent-start
drop 52 end-structure
\ struct SDL_TextEditingExtEvent
begin-structure SDL_TextEditingExtEvent
	drop 8 4 +field SDL_TextEditingExtEvent-windowID
	drop 0 4 +field SDL_TextEditingExtEvent-type
	drop 16 8 +field SDL_TextEditingExtEvent-text
	drop 28 4 +field SDL_TextEditingExtEvent-length
	drop 4 4 +field SDL_TextEditingExtEvent-timestamp
	drop 24 4 +field SDL_TextEditingExtEvent-start
drop 32 end-structure
\ struct SDL_TextInputEvent
begin-structure SDL_TextInputEvent
	drop 8 4 +field SDL_TextInputEvent-windowID
	drop 0 4 +field SDL_TextInputEvent-type
	drop 12 32 +field SDL_TextInputEvent-text
	drop 4 4 +field SDL_TextInputEvent-timestamp
drop 44 end-structure
\ struct SDL_MouseMotionEvent
begin-structure SDL_MouseMotionEvent
	drop 32 4 +field SDL_MouseMotionEvent-yrel
	drop 20 4 +field SDL_MouseMotionEvent-x
	drop 12 4 +field SDL_MouseMotionEvent-which
	drop 24 4 +field SDL_MouseMotionEvent-y
	drop 8 4 +field SDL_MouseMotionEvent-windowID
	drop 0 4 +field SDL_MouseMotionEvent-type
	drop 4 4 +field SDL_MouseMotionEvent-timestamp
	drop 16 4 +field SDL_MouseMotionEvent-state
	drop 28 4 +field SDL_MouseMotionEvent-xrel
drop 36 end-structure
\ struct SDL_MouseButtonEvent
begin-structure SDL_MouseButtonEvent
	drop 20 4 +field SDL_MouseButtonEvent-x
	drop 12 4 +field SDL_MouseButtonEvent-which
	drop 24 4 +field SDL_MouseButtonEvent-y
	drop 8 4 +field SDL_MouseButtonEvent-windowID
	drop 16 1 +field SDL_MouseButtonEvent-button
	drop 0 4 +field SDL_MouseButtonEvent-type
	drop 18 1 +field SDL_MouseButtonEvent-clicks
	drop 19 1 +field SDL_MouseButtonEvent-padding1
	drop 4 4 +field SDL_MouseButtonEvent-timestamp
	drop 17 1 +field SDL_MouseButtonEvent-state
drop 28 end-structure
\ struct SDL_MouseWheelEvent
begin-structure SDL_MouseWheelEvent
	drop 16 4 +field SDL_MouseWheelEvent-x
	drop 36 4 +field SDL_MouseWheelEvent-mouseX
	drop 12 4 +field SDL_MouseWheelEvent-which
	drop 20 4 +field SDL_MouseWheelEvent-y
	drop 28 4 +field SDL_MouseWheelEvent-preciseX
	drop 40 4 +field SDL_MouseWheelEvent-mouseY
	drop 8 4 +field SDL_MouseWheelEvent-windowID
	drop 32 4 +field SDL_MouseWheelEvent-preciseY
	drop 0 4 +field SDL_MouseWheelEvent-type
	drop 4 4 +field SDL_MouseWheelEvent-timestamp
	drop 24 4 +field SDL_MouseWheelEvent-direction
drop 44 end-structure
\ struct SDL_JoyAxisEvent
begin-structure SDL_JoyAxisEvent
	drop 18 2 +field SDL_JoyAxisEvent-padding4
	drop 8 4 +field SDL_JoyAxisEvent-which
	drop 16 2 +field SDL_JoyAxisEvent-value
	drop 0 4 +field SDL_JoyAxisEvent-type
	drop 12 1 +field SDL_JoyAxisEvent-axis
	drop 13 1 +field SDL_JoyAxisEvent-padding1
	drop 4 4 +field SDL_JoyAxisEvent-timestamp
	drop 14 1 +field SDL_JoyAxisEvent-padding2
	drop 15 1 +field SDL_JoyAxisEvent-padding3
drop 20 end-structure
\ struct SDL_JoyBallEvent
begin-structure SDL_JoyBallEvent
	drop 18 2 +field SDL_JoyBallEvent-yrel
	drop 8 4 +field SDL_JoyBallEvent-which
	drop 0 4 +field SDL_JoyBallEvent-type
	drop 13 1 +field SDL_JoyBallEvent-padding1
	drop 4 4 +field SDL_JoyBallEvent-timestamp
	drop 14 1 +field SDL_JoyBallEvent-padding2
	drop 12 1 +field SDL_JoyBallEvent-ball
	drop 15 1 +field SDL_JoyBallEvent-padding3
	drop 16 2 +field SDL_JoyBallEvent-xrel
drop 20 end-structure
\ struct SDL_JoyHatEvent
begin-structure SDL_JoyHatEvent
	drop 8 4 +field SDL_JoyHatEvent-which
	drop 13 1 +field SDL_JoyHatEvent-value
	drop 0 4 +field SDL_JoyHatEvent-type
	drop 14 1 +field SDL_JoyHatEvent-padding1
	drop 4 4 +field SDL_JoyHatEvent-timestamp
	drop 12 1 +field SDL_JoyHatEvent-hat
	drop 15 1 +field SDL_JoyHatEvent-padding2
drop 16 end-structure
\ struct SDL_JoyButtonEvent
begin-structure SDL_JoyButtonEvent
	drop 8 4 +field SDL_JoyButtonEvent-which
	drop 12 1 +field SDL_JoyButtonEvent-button
	drop 0 4 +field SDL_JoyButtonEvent-type
	drop 14 1 +field SDL_JoyButtonEvent-padding1
	drop 4 4 +field SDL_JoyButtonEvent-timestamp
	drop 13 1 +field SDL_JoyButtonEvent-state
	drop 15 1 +field SDL_JoyButtonEvent-padding2
drop 16 end-structure
\ struct SDL_JoyDeviceEvent
begin-structure SDL_JoyDeviceEvent
	drop 8 4 +field SDL_JoyDeviceEvent-which
	drop 0 4 +field SDL_JoyDeviceEvent-type
	drop 4 4 +field SDL_JoyDeviceEvent-timestamp
drop 12 end-structure
\ struct SDL_JoyBatteryEvent
begin-structure SDL_JoyBatteryEvent
	drop 12 4 +field SDL_JoyBatteryEvent-level
	drop 8 4 +field SDL_JoyBatteryEvent-which
	drop 0 4 +field SDL_JoyBatteryEvent-type
	drop 4 4 +field SDL_JoyBatteryEvent-timestamp
drop 16 end-structure
\ struct SDL_ControllerAxisEvent
begin-structure SDL_ControllerAxisEvent
	drop 18 2 +field SDL_ControllerAxisEvent-padding4
	drop 8 4 +field SDL_ControllerAxisEvent-which
	drop 16 2 +field SDL_ControllerAxisEvent-value
	drop 0 4 +field SDL_ControllerAxisEvent-type
	drop 12 1 +field SDL_ControllerAxisEvent-axis
	drop 13 1 +field SDL_ControllerAxisEvent-padding1
	drop 4 4 +field SDL_ControllerAxisEvent-timestamp
	drop 14 1 +field SDL_ControllerAxisEvent-padding2
	drop 15 1 +field SDL_ControllerAxisEvent-padding3
drop 20 end-structure
\ struct SDL_ControllerButtonEvent
begin-structure SDL_ControllerButtonEvent
	drop 8 4 +field SDL_ControllerButtonEvent-which
	drop 12 1 +field SDL_ControllerButtonEvent-button
	drop 0 4 +field SDL_ControllerButtonEvent-type
	drop 14 1 +field SDL_ControllerButtonEvent-padding1
	drop 4 4 +field SDL_ControllerButtonEvent-timestamp
	drop 13 1 +field SDL_ControllerButtonEvent-state
	drop 15 1 +field SDL_ControllerButtonEvent-padding2
drop 16 end-structure
\ struct SDL_ControllerDeviceEvent
begin-structure SDL_ControllerDeviceEvent
	drop 8 4 +field SDL_ControllerDeviceEvent-which
	drop 0 4 +field SDL_ControllerDeviceEvent-type
	drop 4 4 +field SDL_ControllerDeviceEvent-timestamp
drop 12 end-structure
\ struct SDL_ControllerTouchpadEvent
begin-structure SDL_ControllerTouchpadEvent
	drop 16 4 +field SDL_ControllerTouchpadEvent-finger
	drop 12 4 +field SDL_ControllerTouchpadEvent-touchpad
	drop 20 4 +field SDL_ControllerTouchpadEvent-x
	drop 8 4 +field SDL_ControllerTouchpadEvent-which
	drop 24 4 +field SDL_ControllerTouchpadEvent-y
	drop 0 4 +field SDL_ControllerTouchpadEvent-type
	drop 4 4 +field SDL_ControllerTouchpadEvent-timestamp
	drop 28 4 +field SDL_ControllerTouchpadEvent-pressure
drop 32 end-structure
\ struct SDL_ControllerSensorEvent
begin-structure SDL_ControllerSensorEvent
	drop 16 12 +field SDL_ControllerSensorEvent-data
	drop 32 8 +field SDL_ControllerSensorEvent-timestamp_us
	drop 8 4 +field SDL_ControllerSensorEvent-which
	drop 0 4 +field SDL_ControllerSensorEvent-type
	drop 12 4 +field SDL_ControllerSensorEvent-sensor
	drop 4 4 +field SDL_ControllerSensorEvent-timestamp
drop 40 end-structure
\ struct SDL_AudioDeviceEvent
begin-structure SDL_AudioDeviceEvent
	drop 8 4 +field SDL_AudioDeviceEvent-which
	drop 0 4 +field SDL_AudioDeviceEvent-type
	drop 13 1 +field SDL_AudioDeviceEvent-padding1
	drop 4 4 +field SDL_AudioDeviceEvent-timestamp
	drop 14 1 +field SDL_AudioDeviceEvent-padding2
	drop 12 1 +field SDL_AudioDeviceEvent-iscapture
	drop 15 1 +field SDL_AudioDeviceEvent-padding3
drop 16 end-structure
\ struct SDL_TouchFingerEvent
begin-structure SDL_TouchFingerEvent
	drop 8 8 +field SDL_TouchFingerEvent-touchId
	drop 24 4 +field SDL_TouchFingerEvent-x
	drop 28 4 +field SDL_TouchFingerEvent-y
	drop 32 4 +field SDL_TouchFingerEvent-dx
	drop 36 4 +field SDL_TouchFingerEvent-dy
	drop 44 4 +field SDL_TouchFingerEvent-windowID
	drop 0 4 +field SDL_TouchFingerEvent-type
	drop 4 4 +field SDL_TouchFingerEvent-timestamp
	drop 40 4 +field SDL_TouchFingerEvent-pressure
	drop 16 8 +field SDL_TouchFingerEvent-fingerId
drop 48 end-structure
\ struct SDL_MultiGestureEvent
begin-structure SDL_MultiGestureEvent
	drop 8 8 +field SDL_MultiGestureEvent-touchId
	drop 16 4 +field SDL_MultiGestureEvent-dTheta
	drop 20 4 +field SDL_MultiGestureEvent-dDist
	drop 24 4 +field SDL_MultiGestureEvent-x
	drop 28 4 +field SDL_MultiGestureEvent-y
	drop 34 2 +field SDL_MultiGestureEvent-padding
	drop 0 4 +field SDL_MultiGestureEvent-type
	drop 4 4 +field SDL_MultiGestureEvent-timestamp
	drop 32 2 +field SDL_MultiGestureEvent-numFingers
drop 40 end-structure
\ struct SDL_DollarGestureEvent
begin-structure SDL_DollarGestureEvent
	drop 8 8 +field SDL_DollarGestureEvent-touchId
	drop 32 4 +field SDL_DollarGestureEvent-x
	drop 28 4 +field SDL_DollarGestureEvent-error
	drop 36 4 +field SDL_DollarGestureEvent-y
	drop 0 4 +field SDL_DollarGestureEvent-type
	drop 4 4 +field SDL_DollarGestureEvent-timestamp
	drop 16 8 +field SDL_DollarGestureEvent-gestureId
	drop 24 4 +field SDL_DollarGestureEvent-numFingers
drop 40 end-structure
\ struct SDL_DropEvent
begin-structure SDL_DropEvent
	drop 16 4 +field SDL_DropEvent-windowID
	drop 0 4 +field SDL_DropEvent-type
	drop 4 4 +field SDL_DropEvent-timestamp
	drop 8 8 +field SDL_DropEvent-file
drop 24 end-structure
\ struct SDL_SensorEvent
begin-structure SDL_SensorEvent
	drop 12 24 +field SDL_SensorEvent-data
	drop 40 8 +field SDL_SensorEvent-timestamp_us
	drop 8 4 +field SDL_SensorEvent-which
	drop 0 4 +field SDL_SensorEvent-type
	drop 4 4 +field SDL_SensorEvent-timestamp
drop 48 end-structure
\ struct SDL_QuitEvent
begin-structure SDL_QuitEvent
	drop 0 4 +field SDL_QuitEvent-type
	drop 4 4 +field SDL_QuitEvent-timestamp
drop 8 end-structure
\ struct SDL_OSEvent
begin-structure SDL_OSEvent
	drop 0 4 +field SDL_OSEvent-type
	drop 4 4 +field SDL_OSEvent-timestamp
drop 8 end-structure
\ struct SDL_UserEvent
begin-structure SDL_UserEvent
	drop 8 4 +field SDL_UserEvent-windowID
	drop 12 4 +field SDL_UserEvent-code
	drop 0 4 +field SDL_UserEvent-type
	drop 16 8 +field SDL_UserEvent-data1
	drop 4 4 +field SDL_UserEvent-timestamp
	drop 24 8 +field SDL_UserEvent-data2
drop 32 end-structure
\ struct SDL_SysWMEvent
begin-structure SDL_SysWMEvent
	drop 0 4 +field SDL_SysWMEvent-type
	drop 8 8 +field SDL_SysWMEvent-msg
	drop 4 4 +field SDL_SysWMEvent-timestamp
drop 16 end-structure
\ union SDL_Event
begin-structure SDL_Event
	drop 0 16 +field SDL_Event-jhat
	drop 0 24 +field SDL_Event-window
	drop 0 12 +field SDL_Event-cdevice
	drop 0 16 +field SDL_Event-adevice
	drop 0 48 +field SDL_Event-sensor
	drop 0 20 +field SDL_Event-jball
	drop 0 20 +field SDL_Event-caxis
	drop 0 28 +field SDL_Event-button
	drop 0 16 +field SDL_Event-jbutton
	drop 0 40 +field SDL_Event-csensor
	drop 0 44 +field SDL_Event-wheel
	drop 0 36 +field SDL_Event-motion
	drop 0 40 +field SDL_Event-mgesture
	drop 0 40 +field SDL_Event-dgesture
	drop 0 24 +field SDL_Event-drop
	drop 0 8 +field SDL_Event-common
	drop 0 32 +field SDL_Event-key
	drop 0 52 +field SDL_Event-edit
	drop 0 20 +field SDL_Event-display
	drop 0 16 +field SDL_Event-cbutton
	drop 0 32 +field SDL_Event-ctouchpad
	drop 0 48 +field SDL_Event-tfinger
	drop 0 32 +field SDL_Event-editExt
	drop 0 4 +field SDL_Event-type
	drop 0 20 +field SDL_Event-jaxis
	drop 0 12 +field SDL_Event-jdevice
	drop 0 16 +field SDL_Event-syswm
	drop 0 56 +field SDL_Event-padding
	drop 0 8 +field SDL_Event-quit
	drop 0 32 +field SDL_Event-user
	drop 0 44 +field SDL_Event-text
	drop 0 16 +field SDL_Event-jbattery
drop 56 end-structure

\ ------===< functions >===-------
c-function SDL_PumpEvents SDL_PumpEvents  -- void	( -- )
c-function SDL_PeepEvents SDL_PeepEvents a n n n n -- n	( events numevents action minType maxType -- )
c-function SDL_HasEvent SDL_HasEvent n -- n	( type -- )
c-function SDL_HasEvents SDL_HasEvents n n -- n	( minType maxType -- )
c-function SDL_FlushEvent SDL_FlushEvent n -- void	( type -- )
c-function SDL_FlushEvents SDL_FlushEvents n n -- void	( minType maxType -- )
c-function SDL_PollEvent SDL_PollEvent a -- n	( event -- )
c-function SDL_WaitEvent SDL_WaitEvent a -- n	( event -- )
c-function SDL_WaitEventTimeout SDL_WaitEventTimeout a n -- n	( event timeout -- )
c-function SDL_PushEvent SDL_PushEvent a -- n	( event -- )
c-function SDL_SetEventFilter SDL_SetEventFilter a a -- void	( filter userdata -- )
c-function SDL_GetEventFilter SDL_GetEventFilter a a -- n	( filter userdata -- )
c-function SDL_AddEventWatch SDL_AddEventWatch a a -- void	( filter userdata -- )
c-function SDL_DelEventWatch SDL_DelEventWatch a a -- void	( filter userdata -- )
c-function SDL_FilterEvents SDL_FilterEvents a a -- void	( filter userdata -- )
c-function SDL_EventState SDL_EventState n n -- n	( type state -- )
c-function SDL_RegisterEvents SDL_RegisterEvents n -- n	( numevents -- )

\ ----===< postfix >===-----
end-c-library
