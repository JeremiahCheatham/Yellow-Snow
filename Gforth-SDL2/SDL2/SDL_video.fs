\ ----===< prefix >===-----
c-library sdl_video
s" SDL2" add-lib
\c #include <SDL2/SDL_video.h>

\ ----===< int constants >===-----
#536805376	constant SDL_WINDOWPOS_UNDEFINED_MASK
#536805376	constant SDL_WINDOWPOS_UNDEFINED
#805240832	constant SDL_WINDOWPOS_CENTERED_MASK
#805240832	constant SDL_WINDOWPOS_CENTERED

\ --------===< enums >===---------
#1	constant SDL_WINDOW_FULLSCREEN
#2	constant SDL_WINDOW_OPENGL
#4	constant SDL_WINDOW_SHOWN
#8	constant SDL_WINDOW_HIDDEN
#16	constant SDL_WINDOW_BORDERLESS
#32	constant SDL_WINDOW_RESIZABLE
#64	constant SDL_WINDOW_MINIMIZED
#128	constant SDL_WINDOW_MAXIMIZED
#256	constant SDL_WINDOW_MOUSE_GRABBED
#512	constant SDL_WINDOW_INPUT_FOCUS
#1024	constant SDL_WINDOW_MOUSE_FOCUS
#4097	constant SDL_WINDOW_FULLSCREEN_DESKTOP
#2048	constant SDL_WINDOW_FOREIGN
#8192	constant SDL_WINDOW_ALLOW_HIGHDPI
#16384	constant SDL_WINDOW_MOUSE_CAPTURE
#32768	constant SDL_WINDOW_ALWAYS_ON_TOP
#65536	constant SDL_WINDOW_SKIP_TASKBAR
#131072	constant SDL_WINDOW_UTILITY
#262144	constant SDL_WINDOW_TOOLTIP
#524288	constant SDL_WINDOW_POPUP_MENU
#1048576	constant SDL_WINDOW_KEYBOARD_GRABBED
#268435456	constant SDL_WINDOW_VULKAN
#536870912	constant SDL_WINDOW_METAL
#256	constant SDL_WINDOW_INPUT_GRABBED
#0	constant SDL_WINDOWEVENT_NONE
#1	constant SDL_WINDOWEVENT_SHOWN
#2	constant SDL_WINDOWEVENT_HIDDEN
#3	constant SDL_WINDOWEVENT_EXPOSED
#4	constant SDL_WINDOWEVENT_MOVED
#5	constant SDL_WINDOWEVENT_RESIZED
#6	constant SDL_WINDOWEVENT_SIZE_CHANGED
#7	constant SDL_WINDOWEVENT_MINIMIZED
#8	constant SDL_WINDOWEVENT_MAXIMIZED
#9	constant SDL_WINDOWEVENT_RESTORED
#10	constant SDL_WINDOWEVENT_ENTER
#11	constant SDL_WINDOWEVENT_LEAVE
#12	constant SDL_WINDOWEVENT_FOCUS_GAINED
#13	constant SDL_WINDOWEVENT_FOCUS_LOST
#14	constant SDL_WINDOWEVENT_CLOSE
#15	constant SDL_WINDOWEVENT_TAKE_FOCUS
#16	constant SDL_WINDOWEVENT_HIT_TEST
#17	constant SDL_WINDOWEVENT_ICCPROF_CHANGED
#18	constant SDL_WINDOWEVENT_DISPLAY_CHANGED
#0	constant SDL_DISPLAYEVENT_NONE
#1	constant SDL_DISPLAYEVENT_ORIENTATION
#2	constant SDL_DISPLAYEVENT_CONNECTED
#3	constant SDL_DISPLAYEVENT_DISCONNECTED
#4	constant SDL_DISPLAYEVENT_MOVED
#0	constant SDL_ORIENTATION_UNKNOWN
#1	constant SDL_ORIENTATION_LANDSCAPE
#2	constant SDL_ORIENTATION_LANDSCAPE_FLIPPED
#3	constant SDL_ORIENTATION_PORTRAIT
#4	constant SDL_ORIENTATION_PORTRAIT_FLIPPED
#0	constant SDL_FLASH_CANCEL
#1	constant SDL_FLASH_BRIEFLY
#2	constant SDL_FLASH_UNTIL_FOCUSED
#0	constant SDL_GL_RED_SIZE
#1	constant SDL_GL_GREEN_SIZE
#2	constant SDL_GL_BLUE_SIZE
#3	constant SDL_GL_ALPHA_SIZE
#4	constant SDL_GL_BUFFER_SIZE
#5	constant SDL_GL_DOUBLEBUFFER
#6	constant SDL_GL_DEPTH_SIZE
#7	constant SDL_GL_STENCIL_SIZE
#8	constant SDL_GL_ACCUM_RED_SIZE
#9	constant SDL_GL_ACCUM_GREEN_SIZE
#10	constant SDL_GL_ACCUM_BLUE_SIZE
#11	constant SDL_GL_ACCUM_ALPHA_SIZE
#12	constant SDL_GL_STEREO
#13	constant SDL_GL_MULTISAMPLEBUFFERS
#14	constant SDL_GL_MULTISAMPLESAMPLES
#15	constant SDL_GL_ACCELERATED_VISUAL
#16	constant SDL_GL_RETAINED_BACKING
#17	constant SDL_GL_CONTEXT_MAJOR_VERSION
#18	constant SDL_GL_CONTEXT_MINOR_VERSION
#19	constant SDL_GL_CONTEXT_EGL
#20	constant SDL_GL_CONTEXT_FLAGS
#21	constant SDL_GL_CONTEXT_PROFILE_MASK
#22	constant SDL_GL_SHARE_WITH_CURRENT_CONTEXT
#23	constant SDL_GL_FRAMEBUFFER_SRGB_CAPABLE
#24	constant SDL_GL_CONTEXT_RELEASE_BEHAVIOR
#25	constant SDL_GL_CONTEXT_RESET_NOTIFICATION
#26	constant SDL_GL_CONTEXT_NO_ERROR
#27	constant SDL_GL_FLOATBUFFERS
#1	constant SDL_GL_CONTEXT_PROFILE_CORE
#2	constant SDL_GL_CONTEXT_PROFILE_COMPATIBILITY
#4	constant SDL_GL_CONTEXT_PROFILE_ES
#1	constant SDL_GL_CONTEXT_DEBUG_FLAG
#2	constant SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG
#4	constant SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG
#8	constant SDL_GL_CONTEXT_RESET_ISOLATION_FLAG
#0	constant SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE
#1	constant SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH
#0	constant SDL_GL_CONTEXT_RESET_NO_NOTIFICATION
#1	constant SDL_GL_CONTEXT_RESET_LOSE_CONTEXT
#0	constant SDL_HITTEST_NORMAL
#1	constant SDL_HITTEST_DRAGGABLE
#2	constant SDL_HITTEST_RESIZE_TOPLEFT
#3	constant SDL_HITTEST_RESIZE_TOP
#4	constant SDL_HITTEST_RESIZE_TOPRIGHT
#5	constant SDL_HITTEST_RESIZE_RIGHT
#6	constant SDL_HITTEST_RESIZE_BOTTOMRIGHT
#7	constant SDL_HITTEST_RESIZE_BOTTOM
#8	constant SDL_HITTEST_RESIZE_BOTTOMLEFT
#9	constant SDL_HITTEST_RESIZE_LEFT

\ -------===< structs >===--------
\ SDL_DisplayMode
begin-structure SDL_DisplayMode
	drop 4 4 +field SDL_DisplayMode-w
	drop 12 4 +field SDL_DisplayMode-refresh_rate
	drop 0 4 +field SDL_DisplayMode-format
	drop 8 4 +field SDL_DisplayMode-h
	drop 16 8 +field SDL_DisplayMode-driverdata
drop 24 end-structure

\ ------===< functions >===-------
c-function SDL_GetNumVideoDrivers SDL_GetNumVideoDrivers  -- n	( -- )
c-function SDL_GetVideoDriver SDL_GetVideoDriver n -- a	( index -- )
c-function SDL_VideoInit SDL_VideoInit a -- n	( driver_name -- )
c-function SDL_VideoQuit SDL_VideoQuit  -- void	( -- )
c-function SDL_GetCurrentVideoDriver SDL_GetCurrentVideoDriver  -- a	( -- )
c-function SDL_GetNumVideoDisplays SDL_GetNumVideoDisplays  -- n	( -- )
c-function SDL_GetDisplayName SDL_GetDisplayName n -- a	( displayIndex -- )
c-function SDL_GetDisplayBounds SDL_GetDisplayBounds n a -- n	( displayIndex rect -- )
c-function SDL_GetDisplayUsableBounds SDL_GetDisplayUsableBounds n a -- n	( displayIndex rect -- )
c-function SDL_GetDisplayDPI SDL_GetDisplayDPI n a a a -- n	( displayIndex ddpi hdpi vdpi -- )
c-function SDL_GetDisplayOrientation SDL_GetDisplayOrientation n -- n	( displayIndex -- )
c-function SDL_GetNumDisplayModes SDL_GetNumDisplayModes n -- n	( displayIndex -- )
c-function SDL_GetDisplayMode SDL_GetDisplayMode n n a -- n	( displayIndex modeIndex mode -- )
c-function SDL_GetDesktopDisplayMode SDL_GetDesktopDisplayMode n a -- n	( displayIndex mode -- )
c-function SDL_GetCurrentDisplayMode SDL_GetCurrentDisplayMode n a -- n	( displayIndex mode -- )
c-function SDL_GetClosestDisplayMode SDL_GetClosestDisplayMode n a a -- a	( displayIndex mode closest -- )
c-function SDL_GetPointDisplayIndex SDL_GetPointDisplayIndex a -- n	( point -- )
c-function SDL_GetRectDisplayIndex SDL_GetRectDisplayIndex a -- n	( rect -- )
c-function SDL_GetWindowDisplayIndex SDL_GetWindowDisplayIndex a -- n	( window -- )
c-function SDL_SetWindowDisplayMode SDL_SetWindowDisplayMode a a -- n	( window mode -- )
c-function SDL_GetWindowDisplayMode SDL_GetWindowDisplayMode a a -- n	( window mode -- )
c-function SDL_GetWindowICCProfile SDL_GetWindowICCProfile a a -- a	( window size -- )
c-function SDL_GetWindowPixelFormat SDL_GetWindowPixelFormat a -- n	( window -- )
c-function SDL_CreateWindow SDL_CreateWindow a n n n n n -- a	( title x y w h flags -- )
c-function SDL_CreateWindowFrom SDL_CreateWindowFrom a -- a	( data -- )
c-function SDL_GetWindowID SDL_GetWindowID a -- n	( window -- )
c-function SDL_GetWindowFromID SDL_GetWindowFromID n -- a	( id -- )
c-function SDL_GetWindowFlags SDL_GetWindowFlags a -- n	( window -- )
c-function SDL_SetWindowTitle SDL_SetWindowTitle a a -- void	( window title -- )
c-function SDL_GetWindowTitle SDL_GetWindowTitle a -- a	( window -- )
c-function SDL_SetWindowIcon SDL_SetWindowIcon a a -- void	( window icon -- )
c-function SDL_SetWindowData SDL_SetWindowData a a a -- a	( window name userdata -- )
c-function SDL_GetWindowData SDL_GetWindowData a a -- a	( window name -- )
c-function SDL_SetWindowPosition SDL_SetWindowPosition a n n -- void	( window x y -- )
c-function SDL_GetWindowPosition SDL_GetWindowPosition a a a -- void	( window x y -- )
c-function SDL_SetWindowSize SDL_SetWindowSize a n n -- void	( window w h -- )
c-function SDL_GetWindowSize SDL_GetWindowSize a a a -- void	( window w h -- )
c-function SDL_GetWindowBordersSize SDL_GetWindowBordersSize a a a a a -- n	( window top left bottom right -- )
c-function SDL_GetWindowSizeInPixels SDL_GetWindowSizeInPixels a a a -- void	( window w h -- )
c-function SDL_SetWindowMinimumSize SDL_SetWindowMinimumSize a n n -- void	( window min_w min_h -- )
c-function SDL_GetWindowMinimumSize SDL_GetWindowMinimumSize a a a -- void	( window w h -- )
c-function SDL_SetWindowMaximumSize SDL_SetWindowMaximumSize a n n -- void	( window max_w max_h -- )
c-function SDL_GetWindowMaximumSize SDL_GetWindowMaximumSize a a a -- void	( window w h -- )
c-function SDL_SetWindowBordered SDL_SetWindowBordered a n -- void	( window bordered -- )
c-function SDL_SetWindowResizable SDL_SetWindowResizable a n -- void	( window resizable -- )
c-function SDL_SetWindowAlwaysOnTop SDL_SetWindowAlwaysOnTop a n -- void	( window on_top -- )
c-function SDL_ShowWindow SDL_ShowWindow a -- void	( window -- )
c-function SDL_HideWindow SDL_HideWindow a -- void	( window -- )
c-function SDL_RaiseWindow SDL_RaiseWindow a -- void	( window -- )
c-function SDL_MaximizeWindow SDL_MaximizeWindow a -- void	( window -- )
c-function SDL_MinimizeWindow SDL_MinimizeWindow a -- void	( window -- )
c-function SDL_RestoreWindow SDL_RestoreWindow a -- void	( window -- )
c-function SDL_SetWindowFullscreen SDL_SetWindowFullscreen a n -- n	( window flags -- )
c-function SDL_HasWindowSurface SDL_HasWindowSurface a -- n	( window -- )
c-function SDL_GetWindowSurface SDL_GetWindowSurface a -- a	( window -- )
c-function SDL_UpdateWindowSurface SDL_UpdateWindowSurface a -- n	( window -- )
c-function SDL_UpdateWindowSurfaceRects SDL_UpdateWindowSurfaceRects a a n -- n	( window rects numrects -- )
c-function SDL_DestroyWindowSurface SDL_DestroyWindowSurface a -- n	( window -- )
c-function SDL_SetWindowGrab SDL_SetWindowGrab a n -- void	( window grabbed -- )
c-function SDL_SetWindowKeyboardGrab SDL_SetWindowKeyboardGrab a n -- void	( window grabbed -- )
c-function SDL_SetWindowMouseGrab SDL_SetWindowMouseGrab a n -- void	( window grabbed -- )
c-function SDL_GetWindowGrab SDL_GetWindowGrab a -- n	( window -- )
c-function SDL_GetWindowKeyboardGrab SDL_GetWindowKeyboardGrab a -- n	( window -- )
c-function SDL_GetWindowMouseGrab SDL_GetWindowMouseGrab a -- n	( window -- )
c-function SDL_GetGrabbedWindow SDL_GetGrabbedWindow  -- a	( -- )
c-function SDL_SetWindowMouseRect SDL_SetWindowMouseRect a a -- n	( window rect -- )
c-function SDL_GetWindowMouseRect SDL_GetWindowMouseRect a -- a	( window -- )
c-function SDL_SetWindowBrightness SDL_SetWindowBrightness a r -- n	( window brightness -- )
c-function SDL_GetWindowBrightness SDL_GetWindowBrightness a -- r	( window -- )
c-function SDL_SetWindowOpacity SDL_SetWindowOpacity a r -- n	( window opacity -- )
c-function SDL_GetWindowOpacity SDL_GetWindowOpacity a a -- n	( window out_opacity -- )
c-function SDL_SetWindowModalFor SDL_SetWindowModalFor a a -- n	( modal_window parent_window -- )
c-function SDL_SetWindowInputFocus SDL_SetWindowInputFocus a -- n	( window -- )
c-function SDL_SetWindowGammaRamp SDL_SetWindowGammaRamp a a a a -- n	( window red green blue -- )
c-function SDL_GetWindowGammaRamp SDL_GetWindowGammaRamp a a a a -- n	( window red green blue -- )
c-function SDL_SetWindowHitTest SDL_SetWindowHitTest a a a -- n	( window callback callback_data -- )
c-function SDL_FlashWindow SDL_FlashWindow a n -- n	( window operation -- )
c-function SDL_DestroyWindow SDL_DestroyWindow a -- void	( window -- )
c-function SDL_IsScreenSaverEnabled SDL_IsScreenSaverEnabled  -- n	( -- )
c-function SDL_EnableScreenSaver SDL_EnableScreenSaver  -- void	( -- )
c-function SDL_DisableScreenSaver SDL_DisableScreenSaver  -- void	( -- )
c-function SDL_GL_LoadLibrary SDL_GL_LoadLibrary a -- n	( path -- )
c-function SDL_GL_GetProcAddress SDL_GL_GetProcAddress a -- a	( proc -- )
c-function SDL_GL_UnloadLibrary SDL_GL_UnloadLibrary  -- void	( -- )
c-function SDL_GL_ExtensionSupported SDL_GL_ExtensionSupported a -- n	( extension -- )
c-function SDL_GL_ResetAttributes SDL_GL_ResetAttributes  -- void	( -- )
c-function SDL_GL_SetAttribute SDL_GL_SetAttribute n n -- n	( attr value -- )
c-function SDL_GL_GetAttribute SDL_GL_GetAttribute n a -- n	( attr value -- )
c-function SDL_GL_CreateContext SDL_GL_CreateContext a -- a	( window -- )
c-function SDL_GL_MakeCurrent SDL_GL_MakeCurrent a a -- n	( window context -- )
c-function SDL_GL_GetCurrentWindow SDL_GL_GetCurrentWindow  -- a	( -- )
c-function SDL_GL_GetCurrentContext SDL_GL_GetCurrentContext  -- a	( -- )
c-function SDL_GL_GetDrawableSize SDL_GL_GetDrawableSize a a a -- void	( window w h -- )
c-function SDL_GL_SetSwapInterval SDL_GL_SetSwapInterval n -- n	( interval -- )
c-function SDL_GL_GetSwapInterval SDL_GL_GetSwapInterval  -- n	( -- )
c-function SDL_GL_SwapWindow SDL_GL_SwapWindow a -- void	( window -- )
c-function SDL_GL_DeleteContext SDL_GL_DeleteContext a -- void	( context -- )

\ ----===< postfix >===-----
end-c-library
