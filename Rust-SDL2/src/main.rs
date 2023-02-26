use sdl2::{event::Event, Sdl, VideoSubsystem};
use sdl2::image::{LoadSurface, LoadTexture, Sdl2ImageContext};
use sdl2::render::{Texture, TextureCreator, WindowCanvas};
use sdl2::video::Window;
use sdl2::keyboard::Keycode;
use sdl2::mixer;
use sdl2::surface::Surface;

mod fps;
mod player;
mod flake;
mod score;

const SCREEN_WIDTH: u32 = 800;
const SCREEN_HEIGHT: u32 = 600;

fn main() -> Result<(), String> {
    // Initialize SDL2
    let sdl_context: Sdl = sdl2::init()?;
    let timer_subsystem = sdl_context.timer()?;
    let video_subsystem: VideoSubsystem = sdl_context.video()?;

    // Initialize SDL2_image
    let _image_context: Sdl2ImageContext = sdl2::image::init(sdl2::image::InitFlag::PNG)?;

    // Create a window
    let mut window: Window = video_subsystem.window(
        "Don't Eat the Yellow Snow!", SCREEN_WIDTH, SCREEN_HEIGHT)
        .position_centered()
        .build()
        .map_err(|e| e.to_string())?;

    // Set the window icon from a surface.
    let icon_surface = Surface::from_file("images/yellow.png")?;
    window.set_icon(&icon_surface);

    // Get the window's canvas
    let mut canvas: WindowCanvas = window.into_canvas().build()
        .map_err(|e| e.to_string())?;

    // Load the background image
    let texture_creator: TextureCreator<_> = canvas.texture_creator();
    let background: Texture = texture_creator.load_texture("images/background.png")?;
    let player_tex: Texture = texture_creator.load_texture("images/player.png")?;
    let white_tex: Texture = texture_creator.load_texture("images/white.png")?;
    let yellow_tex: Texture = texture_creator.load_texture("images/yellow.png")?;

    let ttf_context = sdl2::ttf::init().map_err(|e| e.to_string())?;
    
    // Initialize SDL2_mixer
    let _mixer_context = mixer::init(mixer::InitFlag::OGG)?;
    mixer::open_audio( mixer::DEFAULT_FREQUENCY,mixer::AUDIO_S16LSB,
        mixer::DEFAULT_CHANNELS, 1024 )?;

    // Load music from a file
    let music: mixer::Music = mixer::Music::from_file("music/winter_loop.ogg")?;
    let collect: mixer::Chunk = mixer::Chunk::from_file("sounds/collect.ogg")?;
    let hit: mixer::Chunk = mixer::Chunk::from_file("sounds/hit.ogg")?;

    // Play the music in a loop indefinitely
    music.play(-1)?;

    // Create player instance.
    let mut player = player::Player::new(&player_tex, SCREEN_WIDTH as i32)?;

    // Create a vector of flakes.
    let mut flakes: Vec<flake::Flake> = Vec::new();
    for _i in 0..10 {
        let flake = flake::Flake::new(&white_tex,  true, SCREEN_WIDTH as i32, SCREEN_HEIGHT as i32)?;
        flakes.push(flake);
    }
    for _i in 0..5 {
        let flake = flake::Flake::new(&yellow_tex, false, SCREEN_WIDTH as i32, SCREEN_HEIGHT as i32)?;
        flakes.push(flake);
    }

    // Create score instance.
    let mut score = score::Score::new(&texture_creator, &ttf_context)?;

    // Create fps instance.
    let mut fps = fps::Fps::new(60, &timer_subsystem)?;

    let mut event_pump: sdl2::EventPump = sdl_context.event_pump()?;

    let mut playing = true;

    'running: loop {

        for event in event_pump.poll_iter() {
            match event {
                Event::Quit {..} |
                Event::KeyDown { keycode: Some(Keycode::Escape), .. } => {
                    break 'running
                },
                Event::KeyDown { keycode: Some(Keycode::Space), .. } => {
                    if !playing {
                        for flake in flakes.iter_mut() {
                            flake.reset(true);
                        }
                        music.play(-1)?;
                        playing = true;
                        score.reset()?;
                    }
                },
                _ => {}
            }
        }

        if playing {
            // Update the player
            player.update(fps.delta_time, &mut event_pump);

            // Loop through all the flakes and update their position
            // Check collision with ground or player.
            for flake in flakes.iter_mut() {
                flake.update(fps.delta_time);
                if flake.bottom() > 550 {
                    flake.reset(false);
                } else if flake.bottom() > player.top() && flake.right() > player.left() && flake.left() < player.right() {
                    if flake.white {
                        mixer::Channel::all().play(&collect, 0)?;
                        flake.reset(false);
                        score.increment()?;
                    } else {
                        mixer::Music::halt();
                        mixer::Channel::all().play(&hit, 0)?;
                        playing = false;
                    }
                }
            }
        }

        // Clear the canvas and draw the everything.
        canvas.clear();
        canvas.copy(&background, None, None)?;
        player.draw(&mut canvas)?;
        for flake in flakes.iter_mut() {
            flake.draw(&mut canvas)?;
        }
        score.draw(&mut canvas)?;

        // Flip the buffers.
        canvas.present();

        // Delay the game if needed and save the delta_time.
        fps.update();
    }

    Ok(())
}
