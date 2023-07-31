package main

import (
	"math/rand"

	"github.com/veandco/go-sdl2/sdl"
)

type flake struct {
	_renderer *sdl.Renderer
	_image    *sdl.Texture
	_rect     sdl.Rect
	_isYellow bool
	_yVel     float64
	_yPos     float64
}

func newFlake(renderer *sdl.Renderer, image *sdl.Texture, isYellow bool) (*flake, error) {
	f := &flake{}
	var err error

	f._renderer = renderer
	f._image = image
	f._isYellow = isYellow
	f._yVel = 300

	if _, _, f._rect.W, f._rect.H, err = f._image.Query(); err != nil {
		return f, err
	}

	f.reset(true)

	return f, err
}

func (f *flake) reset(full bool) {
	if full {
		f._rect.Y = (-f._rect.H - int32(rand.Intn(windowHeight))) * 2
	} else {
		f._rect.Y = -f._rect.H - int32(rand.Intn(windowHeight))
	}
	f._yPos = float64(f._rect.Y)
	f._rect.X = int32(rand.Intn(windowWidth - int(f._rect.W)))
}

func (f *flake) update(dt float64) {
	f._yPos += f._yVel * dt
	f._rect.Y = int32(f._yPos)
}

func (f *flake) left() int32 {
	return f._rect.X
}

func (f *flake) right() int32 {
	return f._rect.X + f._rect.W
}

func (f *flake) bottom() int32 {
	return f._rect.Y + f._rect.H
}

func (f *flake) isYellow() bool {
	return f._isYellow
}

func (f *flake) draw() {
	f._renderer.Copy(f._image, nil, &f._rect)
}
