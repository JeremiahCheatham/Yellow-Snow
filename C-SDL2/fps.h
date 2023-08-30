#ifndef FPS_H
#define FPS_H

#include "main.h"

struct Fps {
    Uint32 last_time;
    double target_delay;
    double cap_delay;
    double carry_delay;
    double delta_time;
    Uint32 fps_last_time;
    Uint32 fps_counter;
    bool fps_display;
};

bool fps_new(struct Fps **fps);
void fps_free(struct Fps **fps);
void fps_toggle_display(struct Fps *f);
Uint32 fps_time_since(Uint32 last_time, Uint32 *new_last_time);
double fps_update(struct Fps *f);

#endif