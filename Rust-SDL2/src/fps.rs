use sdl2::TimerSubsystem;

pub struct Fps<'a> {
    target_frame_duration: f32,
    last_frame_time: u64,
    carry_delay: f32,
    pub delta_time: f32,
    timer_subsystem: &'a TimerSubsystem,
}

impl<'a> Fps<'a> {
    pub fn new(target_fps: u8, timer_subsystem: &'a TimerSubsystem) -> Result<Fps<'a>, String> {
        let target_frame_duration: f32 = 1.0 / target_fps as f32;
        let last_frame_time = timer_subsystem.performance_counter();
        let carry_delay: f32 = 0.0;
        let delta_time: f32 = 0.0;
        Ok(Fps {target_frame_duration, last_frame_time, carry_delay, delta_time, timer_subsystem})
    }
    
    pub fn update(&mut self) {
        let mut current_time = self.timer_subsystem.performance_counter();
        self.delta_time = (current_time - self.last_frame_time) as f32 / self.timer_subsystem.performance_frequency() as f32;
        let sleep_duration = self.target_frame_duration + self.carry_delay - self.delta_time;
        if sleep_duration > 0.0 {
            std::thread::sleep(std::time::Duration::from_secs_f32(sleep_duration));
            current_time = self.timer_subsystem.performance_counter();
            self.delta_time = (current_time - self.last_frame_time) as f32 / self.timer_subsystem.performance_frequency() as f32;
            self.carry_delay = self.target_frame_duration + self.carry_delay - self.delta_time;
            self.carry_delay = self.carry_delay.max(-self.target_frame_duration).min(self.target_frame_duration);
        }
        
        self.last_frame_time = current_time;
    }
}