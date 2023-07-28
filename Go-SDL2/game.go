package main

import (
	"github.com/veandco/go-sdl2/sdl"
	"github.com/veandco/go-sdl2/ttf"
)

type game struct {
	window     *sdl.Window
	renderer   *sdl.Renderer
	texture    *sdl.Texture
	bubbleText *bubbleText
	fps        *fps
}

func newGame() (*game, error) {

	g := &game{}
	var err error

	if err = ttf.Init(); err != nil {
		return nil, err
	}

	if err = sdl.Init(sdl.INIT_VIDEO); err != nil {
		return nil, err
	}

	if g.window, err = sdl.CreateWindow(windowTitle, sdl.WINDOWPOS_UNDEFINED, sdl.WINDOWPOS_UNDEFINED, windowWidth, windowHeight, sdl.WINDOW_SHOWN); err != nil {
		return g, err
	}

	if g.renderer, err = sdl.CreateRenderer(g.window, -1, sdl.RENDERER_ACCELERATED); err != nil {
		return g, err
	}

	var outerColor = sdl.Color{R: 200, G: 100, B: 150, A: 255}
	var centerColor = sdl.Color{R: 50, G: 50, B: 150, A: 255}
	g.bubbleText, err = newBubbleText(g.renderer, "Bubble Text", 100, 20, outerColor, centerColor)
	if err != nil {
		return g, err
	}

	g.fps = newFps()

	return g, err
}

func (g *game) close() {
	g.bubbleText.close()
	g.renderer.Destroy()
	g.window.Destroy()
	ttf.Quit()
	sdl.Quit()
}

func (g *game) run() {

	running := true
	for running {
		for event := sdl.PollEvent(); event != nil; event = sdl.PollEvent() {
			switch t := event.(type) {
			case *sdl.QuitEvent:
				running = false
			case *sdl.KeyboardEvent:
				switch t.Keysym.Sym {
				case sdl.K_ESCAPE:
					running = false
				}
			}
		}

		g.bubbleText.update()

		g.renderer.Clear()

		g.bubbleText.draw()

		g.renderer.Present()

		g.fps.update()
	}
}
