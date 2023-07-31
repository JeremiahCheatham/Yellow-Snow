package main

import (
	"math/rand"
	"time"

	"github.com/veandco/go-sdl2/img"
	"github.com/veandco/go-sdl2/mix"
	"github.com/veandco/go-sdl2/sdl"
	"github.com/veandco/go-sdl2/ttf"
)

type game struct {
	window          *sdl.Window
	renderer        *sdl.Renderer
	backgroundRect  sdl.Rect
	backgroundImage *sdl.Texture
	playerImage     *sdl.Texture
	whiteImage      *sdl.Texture
	yellowImage     *sdl.Texture
	music           *mix.Music
	collect         *mix.Chunk
	hit             *mix.Chunk
	player          *player
	flakes          []*flake
	score           *score
	fps             *fps
	deltaTime       float64
	running         bool
	playing         bool
}

func newGame() (*game, error) {

	g := &game{}
	var err error

	if err = sdl.Init(sdl.INIT_VIDEO | sdl.INIT_TIMER | sdl.INIT_AUDIO); err != nil {
		return g, err
	}

	if err = ttf.Init(); err != nil {
		return g, err
	}

	if err = mix.OpenAudio(44100, mix.DEFAULT_FORMAT, 2, 1024); err != nil {
		return g, err
	}

	if g.window, err = sdl.CreateWindow(windowTitle, sdl.WINDOWPOS_UNDEFINED, sdl.WINDOWPOS_UNDEFINED, windowWidth, windowHeight, sdl.WINDOW_SHOWN); err != nil {
		return g, err
	}

	if g.renderer, err = sdl.CreateRenderer(g.window, -1, sdl.RENDERER_ACCELERATED); err != nil {
		return g, err
	}

	if g.backgroundImage, err = img.LoadTexture(g.renderer, "images/background.png"); err != nil {
		return g, err
	}

	if _, _, g.backgroundRect.W, g.backgroundRect.H, err = g.backgroundImage.Query(); err != nil {
		return g, err
	}

	if g.playerImage, err = img.LoadTexture(g.renderer, "images/player.png"); err != nil {
		return g, err
	}

	if g.whiteImage, err = img.LoadTexture(g.renderer, "images/white.png"); err != nil {
		return g, err
	}

	if g.yellowImage, err = img.LoadTexture(g.renderer, "images/yellow.png"); err != nil {
		return g, err
	}

	if g.music, err = mix.LoadMUS("music/winter_loop.ogg"); err != nil {
		return g, err
	}

	if g.collect, err = mix.LoadWAV("sounds/collect.ogg"); err != nil {
		return g, err
	}

	if g.hit, err = mix.LoadWAV("sounds/hit.ogg"); err != nil {
		return g, err
	}

	if g.player, err = newPlayer(g.renderer, g.playerImage); err != nil {
		return g, err
	}

	for i := 0; i < 10; i++ {
		flake, err := newFlake(g.renderer, g.whiteImage, false)
		if err != nil {
			return g, err
		}
		g.flakes = append(g.flakes, flake)
	}

	for i := 0; i < 5; i++ {
		flake, err := newFlake(g.renderer, g.yellowImage, true)
		if err != nil {
			return g, err
		}
		g.flakes = append(g.flakes, flake)
	}

	if g.score, err = newScore(g.renderer); err != nil {
		return g, err
	}

	g.fps = newFps()

	g.running = true
	g.playing = true

	return g, err
}

func (g *game) close() {
	if g.score != nil {
		g.score.close()
	}
	g.hit.Free()
	g.collect.Free()
	g.music.Free()
	g.backgroundImage.Destroy()
	g.playerImage.Destroy()
	g.yellowImage.Destroy()
	g.whiteImage.Destroy()
	g.renderer.Destroy()
	g.window.Destroy()
	ttf.Quit()
	mix.Quit()
	sdl.Quit()
}

func (g *game) run() error {
	var err error

	rand.Seed(time.Now().UnixNano())

	if err = g.music.Play(-1); err != nil {
		return err
	}

	for g.running {
		for event := sdl.PollEvent(); event != nil; event = sdl.PollEvent() {
			switch t := event.(type) {
			case *sdl.QuitEvent:
				g.running = false
			case *sdl.KeyboardEvent:
				switch t.Keysym.Sym {
				case sdl.K_ESCAPE:
					g.running = false
				case sdl.K_SPACE:
					if err = g.reset(); err != nil {
						return err
					}
				}
			}
		}

		if g.playing {
			g.player.update(g.deltaTime)
			for _, flake := range g.flakes {
				flake.update(g.deltaTime)
				if err = g.checkCollision(flake); err != nil {
					return err
				}
			}
		}

		g.renderer.Clear()

		g.renderer.Copy(g.backgroundImage, nil, &g.backgroundRect)

		g.player.draw()

		for _, flake := range g.flakes {
			flake.draw()
		}

		g.score.draw()

		g.renderer.Present()

		g.deltaTime = g.fps.update()
	}

	return err
}

func (g *game) reset() error {
	var err error
	for _, flake := range g.flakes {
		flake.reset(true)
	}
	if err = g.score.reset(); err != nil {
		return err
	}
	g.playing = true

	if !mix.PlayingMusic() {
		if err = g.music.Play(-1); err != nil {
			return err
		}
	}

	return err
}

func (g *game) checkCollision(f *flake) error {
	var err error
	if f.bottom() > ground {
		f.reset(false)
	} else if f.bottom() > g.player.top() && f.right() > g.player.left() && f.left() < g.player.right() {
		if f.isYellow() == false {
			if _, err = g.collect.Play(-1, 0); err != nil {
				return err
			}
			f.reset(false)
			if err = g.score.increment(); err != nil {
				return err
			}
		} else {
			mix.HaltMusic()
			if _, err = g.hit.Play(-1, 0); err != nil {
				return err
			}
			g.playing = false
		}
	}
	return err
}
