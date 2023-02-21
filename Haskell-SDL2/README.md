![Screenshot](images/screenshot.png)

# Don't Eat the Yellow Snow! (Haskell - SDL2)
Earn points by collecting all the tasty white snow flakes that fall. But watch out for the yellow snow.

# Build
To build the yellow-snow binary you will need all required build tools needed to compile via ghc and stack. You will also need SDL2 with image, ttf and mixer both the libraries and headerfiles.

ArchLinux instructions.

    sudo pacman -S --needed base-devel ghc stack
    sudo pacman -S --needed sdl2 sdl2_image sdl2_mixer sdl2_ttf
    stack build
    stack run


# Controls
Left Arrow - Moves left.\
Right Arrow - Moves right.\
Space Bar - Resets the Game.\
Escape - Quits and closes game.
