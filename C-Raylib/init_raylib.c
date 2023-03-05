#include "init_raylib.h"

bool init_raylib() {
    // Initialize Raylib
    InitWindow(WIDTH, HEIGHT, TITLE);
    if (!IsWindowReady()) {
        fprintf(stderr, "Failed to initialize Raylib!\n");
        return false;
    }

    // Initialize Raylib Audio
    InitAudioDevice();
    if (!IsAudioDeviceReady()) {
        fprintf(stderr, "Failed to initialize Raylib Audio!\n");
        return false;
    }

    SetTargetFPS(FPS);

    // Set Window Icon
    Image icon = LoadImage("images/yellow.png");
    if (!icon.data) {
        fprintf(stderr, "Failed to load icon Image!\n");
        return false;
    }
    SetWindowIcon(icon);
    UnloadImage(icon);

    return true;
}

void close_raylib() {
    CloseAudioDevice();
    CloseWindow();
}