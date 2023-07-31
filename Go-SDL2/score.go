package main

import (
	"strconv"

	"github.com/veandco/go-sdl2/sdl"
	"github.com/veandco/go-sdl2/ttf"
)

type score struct {
	_renderer  *sdl.Renderer
	_font      *ttf.Font
	_fontColor sdl.Color
	_image     *sdl.Texture
	_rect      sdl.Rect
	_score     int
	_xPos      int32
	_yPos      int32
}

func newScore(renderer *sdl.Renderer) (*score, error) {
	s := &score{}
	var err error

	s._renderer = renderer
	s._xPos = 10
	s._yPos = 10
	s._score = 0

	if s._font, err = ttf.OpenFont(fontPath, fontSize); err != nil {
		return s, err
	}

	s._fontColor = sdl.Color{R: 255, G: 255, B: 255, A: 255}

	if err = s.update(); err != nil {
		return s, err
	}

	return s, err
}

func (s *score) close() {
	s._font.Close()
	s._image.Destroy()
}

func (s *score) reset() error {
	s._score = 0
	err := s.update()
	return err

}

func (s *score) increment() error {
	s._score += 1
	err := s.update()
	return err

}

func (s *score) update() error {
	var scoreSurf *sdl.Surface
	var err error

	if scoreSurf, err = s._font.RenderUTF8Blended(strconv.Itoa(s._score), s._fontColor); err != nil {
		return err
	}
	defer scoreSurf.Free()

	s._image.Destroy()
	if s._image, err = s._renderer.CreateTextureFromSurface(scoreSurf); err != nil {
		return err
	}

	if _, _, s._rect.W, s._rect.H, err = s._image.Query(); err != nil {
		return err
	}

	s._rect.X = s._xPos
	s._rect.Y = s._yPos

	return err
}

func (f *score) draw() {
	f._renderer.Copy(f._image, nil, &f._rect)
}
