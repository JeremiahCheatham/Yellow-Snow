package main

import "fmt"

const (
	windowWidth  = 1280
	windowHeight = 720
	windowTitle  = "Bubble Text"
	fontPath     = "fonts/freesansbold.ttf"
	fontSize     = 100
	targetFPS    = 60
)

func main() {
	g, err := newGame()
	defer g.close()
	if err != nil {
		fmt.Printf("Error: %s\n", err)
		return
	}

	g.run()
}
