![Screenshot](images/screenshot.png)

# Don't Eat the Yellow Snow! (C++ - SDL2)
Earn points by collecting all the tasty white snow flakes that fall. But watch out for the yellow snow.

# Build
To build the yellow-snow binary you will need all required build tools needed to compile via Makefile and g++. You will also need SDL2 with image, ttf and mixer both the libraries and headerfiles. This was created in linux where the SDL2 headerfiles are in the SDL2 folder. In windows i believe the "SDL2/" may need to be removed.

ArchLinux instructions.

    sudo pacman -S --needed base-devel
    sudo pacman -S --needed sdl2 sdl2_image sdl2_mixer sdl2_ttf
    make
    ./yellow-snow


# Controls
Left Arrow - Moves left.\
Right Arrow - Moves right.\
Space Bar - Resets the Game.\
Escape - Quits and closes game.
