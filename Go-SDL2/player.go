package main

import (
	"github.com/veandco/go-sdl2/sdl"
)

type player struct {
	_renderer    *sdl.Renderer
	_image       *sdl.Texture
	_rect        sdl.Rect
	_xVel        float64
	_xPos        float64
	_topOffset   int32
	_leftOffset  int32
	_rightOffset int32
	_flip        sdl.RendererFlip
	_keystate    []uint8
}

func newPlayer(renderer *sdl.Renderer, image *sdl.Texture) (*player, error) {
	p := &player{}
	var err error

	p._renderer = renderer
	p._image = image
	p._xVel = 300
	p._topOffset = 10
	p._leftOffset = 47
	p._rightOffset = 38

	if _, _, p._rect.W, p._rect.H, err = p._image.Query(); err != nil {
		return p, err
	}

	p._rect.X = (windowWidth - p._rect.W) / 2
	p._xPos = float64(p._rect.X)
	p._rect.Y = 377

	p._flip = sdl.FLIP_NONE

	p._keystate = sdl.GetKeyboardState()

	return p, err
}

func (p *player) update(dt float64) {
	if p._keystate[sdl.SCANCODE_LEFT] == 1 {
		p._xPos -= p._xVel * dt
		if p._xPos+float64(p._leftOffset) < 0 {
			p._xPos = -float64(p._leftOffset)
		}
		p._rect.X = int32(p._xPos)
		p._flip = sdl.FLIP_HORIZONTAL
	}
	if p._keystate[sdl.SCANCODE_RIGHT] == 1 {
		p._xPos += p._xVel * dt
		if p._xPos+float64(p._rect.W-p._rightOffset) > windowWidth {
			p._xPos = float64(windowWidth - p._rect.W + p._rightOffset)
		}
		p._rect.X = int32(p._xPos)
		p._flip = sdl.FLIP_NONE
	}
}

func (p *player) left() int32 {
	return p._rect.X + p._leftOffset
}

func (p *player) right() int32 {
	return p._rect.X + p._rect.W - p._rightOffset
}

func (p *player) top() int32 {
	return p._rect.Y + p._topOffset
}

func (p *player) draw() {
	p._renderer.CopyEx(p._image, nil, &p._rect, 0, nil, p._flip)
}
