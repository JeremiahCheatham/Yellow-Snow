package main

import (
	"github.com/veandco/go-sdl2/sdl"
	"github.com/veandco/go-sdl2/ttf"
)

type bubbleText struct {
	renderer *sdl.Renderer
	texture  *sdl.Texture
	rect     sdl.Rect
	velX     int32
	velY     int32
}

func newBubbleText(renderer *sdl.Renderer, text string, size int32, radius int32, outerColor sdl.Color, centerColor sdl.Color) (*bubbleText, error) {
	b := &bubbleText{}
	var err error
	var font *ttf.Font
	var outerSurf *sdl.Surface
	var centerSurf *sdl.Surface
	var targetSurf *sdl.Surface
	padding := int32(radius) * 2

	b.renderer = renderer
	b.velX = 2
	b.velY = 2

	if font, err = ttf.OpenFont(fontPath, fontSize); err != nil {
		return b, err
	}
	defer font.Close()

	if outerSurf, err = font.RenderUTF8Blended(text, outerColor); err != nil {
		return b, err
	}
	defer outerSurf.Free()

	if targetSurf, err = sdl.CreateRGBSurface(0, outerSurf.W+padding, outerSurf.H+padding, 32, 0, 0, 0, 0); err != nil {
		return b, err
	}
	defer targetSurf.Free()

	// Polar Coordinates trigonometry Algorithm
	// radiusFloat := float64(radius)
	// for index := 0; index < int(2*math.Pi*radiusFloat); index++ {
	// 	rad := float64(index) * 1 / radiusFloat
	// 	x := int32(math.Cos(rad)*radiusFloat) + int32(radius)
	// 	y := int32(math.Sin(rad)*radiusFloat) + int32(radius)
	// 	outerSurf.Blit(nil, targetSurf, &sdl.Rect{X: x, Y: y, W: 0, H: 0})
	// }

	// Bresenham's Circle Drawing Algorithm
	// https://www.geeksforgeeks.org/bresenhams-circle-drawing-algorithm/
	var x int32 = 0
	y := radius
	d := 3 - 2*radius
	blitSymmetricPoints(outerSurf, targetSurf, radius, x, y)
	for y >= x {
		x++
		if d > 0 {
			y--
			d = d + 4*(x-y) + 10
		} else {
			d = d + 4*x + 6
		}
		blitSymmetricPoints(outerSurf, targetSurf, radius, x, y)
	}

	if centerSurf, err = font.RenderUTF8Blended(text, centerColor); err != nil {
		return b, err
	}
	defer centerSurf.Free()

	if err = centerSurf.Blit(nil, targetSurf, &sdl.Rect{X: radius, Y: radius, W: 0, H: 0}); err != nil {
		return b, err
	}

	if b.texture, err = b.renderer.CreateTextureFromSurface(targetSurf); err != nil {
		return b, err
	}

	_, _, w, h, err := b.texture.Query()
	if err != nil {
		return b, err
	}
	b.rect = sdl.Rect{X: 0, Y: 0, W: w, H: h}

	return b, err
}

func blitSymmetricPoints(surf *sdl.Surface, targetSurf *sdl.Surface, radius int32, x int32, y int32) {
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius + x, Y: radius + y, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius + x, Y: radius - y, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius - x, Y: radius + y, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius - x, Y: radius - y, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius + y, Y: radius + x, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius + y, Y: radius - x, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius - y, Y: radius + x, W: 0, H: 0})
	surf.Blit(nil, targetSurf, &sdl.Rect{X: radius - y, Y: radius - x, W: 0, H: 0})
}

func (b *bubbleText) close() {
	b.texture.Destroy()
}

func (b *bubbleText) update() {
	b.rect.X += b.velX
	if b.velX > 0 {
		if b.rect.X+b.rect.W > windowWidth {
			b.velX = -2
		}
	} else {
		if b.rect.X < 0 {
			b.velX = 2
		}
	}
	b.rect.Y += b.velY
	if b.velY > 0 {
		if b.rect.Y+b.rect.H > windowHeight {
			b.velY = -2
		}
	} else {
		if b.rect.Y < 0 {
			b.velY = 2
		}
	}
}

func (b *bubbleText) draw() {
	b.renderer.Copy(b.texture, nil, &b.rect)
}
