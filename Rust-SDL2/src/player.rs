use sdl2::rect::Rect;
use sdl2::render::{Texture, WindowCanvas};
use sdl2::keyboard::Scancode;


pub struct Player<'a> {
    texture: &'a Texture<'a>,
    position: Rect,
    window_width: i32,
    x_pos: f32,
    x_vel: f32,
    right_offset: i32,
    left_offset: i32,
    top_offset: i32,
    is_right: bool,
}

impl<'a> Player<'a> {
    pub fn new(texture: &'a Texture<'a>, window_width: i32) -> Result<Player<'a>, String> {
        let x_vel = 300.0;
        let x_pos: f32 = 350.0;
        let y_pos = 374;
        let right_offset = 42;
        let left_offset = 47;
        let top_offset = 12;
        let is_right = true;
        let position = Rect::new(x_pos as i32, y_pos, texture.query().width, texture.query().height);
        Ok(Player { texture, position, window_width, x_vel, x_pos, right_offset, left_offset, top_offset, is_right })
    }

    pub fn draw(&self, canvas: &mut WindowCanvas) -> Result<(), String> {
        if self.is_right {
            canvas.copy(&self.texture, None, self.position)?;
        } else {
            canvas.copy_ex(&self.texture, None, self.position, 0.0, None, true, false)?;
        }
        Ok(())
    }

    pub fn update(&mut self, delta_time: f32, event_pump: &mut sdl2::EventPump) {
        let keyboard_state = event_pump.keyboard_state();

        if keyboard_state.is_scancode_pressed(Scancode::Left) {
            self.is_right = false;
            self.x_pos -= self.x_vel * delta_time;
            if self.x_pos as i32 + self.left_offset < 0 {
                self.x_pos = -self.left_offset as f32;
            }
        }

        if keyboard_state.is_scancode_pressed(Scancode::Right) {
            self.is_right = true;
            self.x_pos += self.x_vel * delta_time;
            if self.x_pos as i32 + self.position.width() as i32 - self.right_offset > self.window_width {
                self.x_pos = self.window_width as f32 - self.position.width() as f32 + self.right_offset as f32;
            }
        }

        self.position.x = self.x_pos as i32;
    }

    pub fn left(&self) -> i32 {
        self.position.x + self.left_offset
    }

    pub fn right(&self) -> i32 {
        self.position.x + self.position.width() as i32 - self.right_offset as i32
    }

    pub fn top(&self) -> i32 {
        self.position.y + self.top_offset
    }
}