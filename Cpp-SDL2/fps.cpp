#include "fps.h"
#include <thread>

Fps::Fps(double target_fps) 
    : target_frame_duration(1000.0 / target_fps)
    , last_frame_time(std::chrono::steady_clock::now())
    , carry_delay(0) {
}

void Fps::update() {
    this->current_time = std::chrono::steady_clock::now();
    this->elapsed_time_first = this->current_time - this->last_frame_time;
    auto sleep_duration =
        std::chrono::duration_cast<std::chrono::milliseconds>(this->target_frame_duration - this->elapsed_time_first + this->carry_delay);

    if (sleep_duration.count() > 0) {
        std::this_thread::sleep_for(sleep_duration);
    }

    this->current_time = std::chrono::steady_clock::now();
    this->elapsed_time_second = this->current_time - this->last_frame_time;
    this->carry_delay = this->target_frame_duration - this->elapsed_time_second + this->carry_delay;
    if (this->carry_delay > this->target_frame_duration)
        this->carry_delay = this->target_frame_duration;
    if (this->carry_delay < -(this->target_frame_duration))
        this->carry_delay = -(this->target_frame_duration);
    this->last_frame_time = this->current_time;
}

double Fps::delta_time() const { return this->elapsed_time_second.count() / 1000; }