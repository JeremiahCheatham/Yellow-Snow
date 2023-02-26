use sdl2::rect::Rect;
use sdl2::render::{Texture, WindowCanvas};
use rand::Rng;


pub struct Flake<'a> {
    texture: &'a Texture<'a>,
    rng: rand::rngs::ThreadRng,
    position: Rect,
    window_width: i32,
    window_height: i32,
    y_pos: f32,
    y_vel: f32,
    pub white: bool,
}

impl<'a> Flake<'a> {
    pub fn new(texture: &'a Texture<'a>, white: bool, window_width: i32, window_height: i32) -> Result<Flake<'a>, String> {
        let y_vel = 300.0;
        let mut rng = rand::thread_rng();
        let mut position = Rect::new(0, 0 as i32, texture.query().width, texture.query().height);
        position.x = rng.gen_range(0..(window_width - position.width() as i32));
        position.y = -(rng.gen_range(0..(window_height * 2)) + position.height() as i32);
        let y_pos = position.y as f32;
        Ok(Flake { texture, white, rng, position, window_width, window_height, y_pos, y_vel })
    }

    pub fn draw(&self, canvas: &mut WindowCanvas) -> Result<(), String> {
        canvas.copy(&self.texture, None, self.position)?;
        Ok(())
    }

    pub fn update(&mut self, delta_time: f32) {
        self.y_pos += self.y_vel * delta_time;
        self.position.y = self.y_pos as i32;
    }

    pub fn left(&self) -> i32 {
        self.position.x
    }

    pub fn right(&self) -> i32 {
        self.position.x + self.position.width() as i32
    }

    pub fn bottom(&self) -> i32 {
        self.position.y + self.position.height() as i32
    }

    pub fn reset(&mut self, full: bool) {
        self.position.x = self.rng.gen_range(0..(self.window_width - self.position.width() as i32));
        if full {
            self.position.y = -(self.rng.gen_range(0..(self.window_height * 2)) + self.position.height() as i32);
        } else {
            self.position.y = -(self.rng.gen_range(0..(self.window_height)) + self.position.height() as i32);
        }
        self.y_pos = self.position.y as f32;
    }
}