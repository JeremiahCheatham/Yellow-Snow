#ifndef FPS_H
#define FPS_H

#include <chrono>


class Fps {
public:
    explicit Fps(double target_fps);

    void update();
    
    inline double delta_time() const { return this->elapsed_time_second.count() / 1000; }

private:
    const std::chrono::duration<double, std::milli> target_frame_duration;
    std::chrono::time_point<std::chrono::steady_clock> last_frame_time;
    std::chrono::time_point<std::chrono::steady_clock> current_time;
    std::chrono::duration<double, std::milli> carry_delay;
    std::chrono::duration<double, std::milli> elapsed_time_first;
    std::chrono::duration<double, std::milli> elapsed_time_second;
};

#endif // FPS_H