![Screenshot](images/screenshot.png)

# Don't Eat the Yellow Snow! (Gforth - SDL2)
Earn points by collecting all the tasty white snow flakes that fall. But watch out for the yellow snow.

ArchLinux instructions.

    sudo pacman -S --needed base-devel
    sudo pacman -S --needed sdl2 sdl2_image sdl2_mixer sdl2_ttf

    cd ~
    git clone https://aur.archlinux.org/gforth.git
    cd ~/gforth
    makepkg -i

    cd ~
    git clone git clone https://github.com/jeremiahcheatham/Yellow-Snow
    cd ~/Yellow-Snow/Gforth-SDL2

    gforth main.fs


# Controls
Left Arrow - Moves left.\
Right Arrow - Moves right.\
Space Bar - Resets the Game.\
Escape - Quits and closes game.\
F - Prints FPS to the console.

