\ ----===< prefix >===-----
c-library sdl_messagebox
s" SDL2" add-lib
\c #include <SDL2/SDL_messagebox.h>

\ --------===< enums >===---------
#16	constant SDL_MESSAGEBOX_ERROR
#32	constant SDL_MESSAGEBOX_WARNING
#64	constant SDL_MESSAGEBOX_INFORMATION
#128	constant SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT
#256	constant SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT
#1	constant SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT
#2	constant SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT
#0	constant SDL_MESSAGEBOX_COLOR_BACKGROUND
#1	constant SDL_MESSAGEBOX_COLOR_TEXT
#2	constant SDL_MESSAGEBOX_COLOR_BUTTON_BORDER
#3	constant SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND
#4	constant SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED
#5	constant SDL_MESSAGEBOX_COLOR_MAX

\ -------===< structs >===--------
\ SDL_MessageBoxButtonData
begin-structure SDL_MessageBoxButtonData
	drop 4 4 +field SDL_MessageBoxButtonData-buttonid
	drop 8 8 +field SDL_MessageBoxButtonData-text
	drop 0 4 +field SDL_MessageBoxButtonData-flags
drop 16 end-structure
\ SDL_MessageBoxColor
begin-structure SDL_MessageBoxColor
	drop 2 1 +field SDL_MessageBoxColor-b
	drop 0 1 +field SDL_MessageBoxColor-r
	drop 1 1 +field SDL_MessageBoxColor-g
drop 3 end-structure
\ SDL_MessageBoxColorScheme
begin-structure SDL_MessageBoxColorScheme
	drop 0 15 +field SDL_MessageBoxColorScheme-colors
drop 15 end-structure
\ SDL_MessageBoxData
begin-structure SDL_MessageBoxData
	drop 32 4 +field SDL_MessageBoxData-numbuttons
	drop 40 8 +field SDL_MessageBoxData-buttons
	drop 8 8 +field SDL_MessageBoxData-window
	drop 48 8 +field SDL_MessageBoxData-colorScheme
	drop 16 8 +field SDL_MessageBoxData-title
	drop 24 8 +field SDL_MessageBoxData-message
	drop 0 4 +field SDL_MessageBoxData-flags
drop 56 end-structure

\ ------===< functions >===-------
c-function SDL_ShowMessageBox SDL_ShowMessageBox a a -- n	( messageboxdata buttonid -- )
c-function SDL_ShowSimpleMessageBox SDL_ShowSimpleMessageBox n a a a -- n	( flags title message window -- )

\ ----===< postfix >===-----
end-c-library
