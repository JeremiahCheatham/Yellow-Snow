package main

import "fmt"

const (
	windowWidth  = 800
	windowHeight = 600
	windowTitle  = "Don't Eat the Yellow Snow!"
	fontPath     = "fonts/freesansbold.ttf"
	fontSize     = 24
	targetFPS    = 60
	ground       = 551
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
