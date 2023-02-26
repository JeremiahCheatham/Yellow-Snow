use sdl2::render::{Texture, TextureCreator, WindowCanvas};
use sdl2::video::WindowContext;
use sdl2::pixels::Color;
use sdl2::ttf::{Font, Sdl2TtfContext};
use sdl2::rect::Rect;

pub struct Score<'a> {
    texture_creator: &'a TextureCreator<WindowContext>,
    font: Font<'a, 'a>,
    score: u32,
    color: Color,
    texture: Texture<'a>,
    position: Rect,
}

impl<'a> Score<'a> {
    pub fn new(texture_creator: &'a TextureCreator<WindowContext>, ttf_context: &'a Sdl2TtfContext) -> Result<Score<'a>, String> {
        // Initialize SDL2_ttf library
        let font = ttf_context.load_font("fonts/freesansbold.ttf", 24)?;
        let score = 0;
        let text = format!("Score: {:?}", score);
        let color = Color::RGB(255, 255, 255); // White
        let surface = font.render(&text).blended(color).map_err(|e| e.to_string())?;
        let texture = texture_creator.create_texture_from_surface(&surface).map_err(|e| e.to_string())?;
        let position = Rect::new(10, 10, texture.query().width, texture.query().height);
        Ok(Score { texture_creator, font, score, color, texture, position})
    }

    pub fn draw(&self, canvas: &mut WindowCanvas) -> Result<(), String> {
        canvas.copy(&self.texture, None, self.position)?;
        Ok(())
    }

    pub fn update(&mut self) -> Result<(), String> {
        let text = format!("Score: {:?}", self.score);
        let surface = self.font.render(&text).blended(self.color).map_err(|e| e.to_string())?;
        self.texture = self.texture_creator.create_texture_from_surface(&surface).map_err(|e| e.to_string())?;
        self.position = Rect::new(10, 10, self.texture.query().width, self.texture.query().height);
        Ok(())
    }

    pub fn increment(&mut self) -> Result<(), String> {
        self.score += 1;
        self.update()?;
        Ok(())
    }

    pub fn reset(&mut self) -> Result<(), String> {
        self.score = 0;
        self.update()?;
        Ok(())
    }
}