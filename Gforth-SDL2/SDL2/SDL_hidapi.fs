\ ----===< prefix >===-----
c-library sdl_hidapi
s" SDL2" add-lib
\c #include <SDL2/SDL_hidapi.h>

\ -------===< structs >===--------
\ struct SDL_hid_device_info
begin-structure SDL_hid_device_info
	drop 64 4 +field SDL_hid_device_info-interface_protocol
	drop 56 4 +field SDL_hid_device_info-interface_class
	drop 52 4 +field SDL_hid_device_info-interface_number
	drop 24 2 +field SDL_hid_device_info-release_number
	drop 16 8 +field SDL_hid_device_info-serial_number
	drop 0 8 +field SDL_hid_device_info-path
	drop 40 8 +field SDL_hid_device_info-product_string
	drop 32 8 +field SDL_hid_device_info-manufacturer_string
	drop 60 4 +field SDL_hid_device_info-interface_subclass
	drop 50 2 +field SDL_hid_device_info-usage
	drop 72 8 +field SDL_hid_device_info-next
	drop 10 2 +field SDL_hid_device_info-product_id
	drop 48 2 +field SDL_hid_device_info-usage_page
	drop 8 2 +field SDL_hid_device_info-vendor_id
drop 80 end-structure

\ ------===< functions >===-------
c-function SDL_hid_init SDL_hid_init  -- n	( -- )
c-function SDL_hid_exit SDL_hid_exit  -- n	( -- )
c-function SDL_hid_device_change_count SDL_hid_device_change_count  -- n	( -- )
c-function SDL_hid_enumerate SDL_hid_enumerate n n -- a	( vendor_id product_id -- )
c-function SDL_hid_free_enumeration SDL_hid_free_enumeration a -- void	( devs -- )
c-function SDL_hid_open SDL_hid_open n n a -- a	( vendor_id product_id serial_number -- )
c-function SDL_hid_open_path SDL_hid_open_path a n -- a	( path bExclusive -- )
c-function SDL_hid_write SDL_hid_write a a n -- n	( dev data length -- )
c-function SDL_hid_read_timeout SDL_hid_read_timeout a a n n -- n	( dev data length milliseconds -- )
c-function SDL_hid_read SDL_hid_read a a n -- n	( dev data length -- )
c-function SDL_hid_set_nonblocking SDL_hid_set_nonblocking a n -- n	( dev nonblock -- )
c-function SDL_hid_send_feature_report SDL_hid_send_feature_report a a n -- n	( dev data length -- )
c-function SDL_hid_get_feature_report SDL_hid_get_feature_report a a n -- n	( dev data length -- )
c-function SDL_hid_close SDL_hid_close a -- void	( dev -- )
c-function SDL_hid_get_manufacturer_string SDL_hid_get_manufacturer_string a a n -- n	( dev string maxlen -- )
c-function SDL_hid_get_product_string SDL_hid_get_product_string a a n -- n	( dev string maxlen -- )
c-function SDL_hid_get_serial_number_string SDL_hid_get_serial_number_string a a n -- n	( dev string maxlen -- )
c-function SDL_hid_get_indexed_string SDL_hid_get_indexed_string a n a n -- n	( dev string_index string maxlen -- )
c-function SDL_hid_ble_scan SDL_hid_ble_scan n -- void	( active -- )

\ ----===< postfix >===-----
end-c-library
