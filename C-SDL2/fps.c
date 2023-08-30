#include "fps.h"

bool fps_new(struct Fps **fps) {

    *fps = calloc(1, sizeof(struct Fps));
    if (!*fps) {
        fprintf(stderr, "Error in calloc of fps!\n");
        return true;
    }

    struct Fps *f = *fps;

    f->target_delay = 1000.0 / TARGET_FPS;
    f->cap_delay = (double)TARGET_FPS / 30;
    f->last_time = SDL_GetTicks();
    f->carry_delay = 0;

    return false;
}

void fps_free(struct Fps **fps) {
    if (*fps) {
        free(*fps);
        *fps = NULL;
    }
}

void fps_toggle_display(struct Fps *f) {
    if (f->fps_display) {
        f->fps_display = false;
    } else {
        f->fps_display = true;
        f->fps_counter = 0;
        f->fps_last_time = SDL_GetTicks();
    }
}

Uint32 fps_time_since(Uint32 last_time, Uint32 *new_last_time) {

    Uint32 current_time = SDL_GetTicks();
    Uint32 elapsed_time = 0;

    if (current_time >= last_time) {
        elapsed_time = current_time - last_time;
    } else {
        elapsed_time = (Uint32)-1 - last_time + current_time;
    }

    if (new_last_time) {
        *new_last_time = current_time;
    }

    return elapsed_time;
}

double fps_update(struct Fps *f) {

    Uint32 elapsed_time = fps_time_since(f->last_time, NULL);
    double delay = f->target_delay + f->carry_delay;

    if (delay > elapsed_time) {
        Uint32 current_delay = (Uint32)delay - elapsed_time;
        SDL_Delay(current_delay);
    }

    elapsed_time = fps_time_since(f->last_time, &f->last_time);

    f->carry_delay = delay - elapsed_time;
    if (f->carry_delay > f->cap_delay) {
        f->carry_delay = f->cap_delay;
    } else if (f->carry_delay < -f->cap_delay) {
        f->carry_delay = -f->cap_delay;
    }

    if (f->fps_display) {
		f->fps_counter++;
		if (fps_time_since(f->fps_last_time, NULL) > 1000) {
			printf("%i\n", f->fps_counter);
			f->fps_counter = 0;
			f->fps_last_time += 1000;
		}
	}

    return (double)elapsed_time / 1000;
}