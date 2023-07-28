package main

import "time"

type fps struct {
	targetFrameDuration time.Duration
	lastTime            time.Time
	carryDelay          time.Duration
}

func newFps() *fps {
	f := &fps{}
	f.targetFrameDuration = time.Second / targetFPS
	f.lastTime = time.Now()
	return f
}

func (f *fps) update() int64 {
	elapsedTime := time.Since(f.lastTime)

	sleepDuration := f.targetFrameDuration + f.carryDelay - elapsedTime
	if sleepDuration > 0 {
		time.Sleep(sleepDuration)
		elapsedTime = time.Since(f.lastTime)
	}

	f.carryDelay = f.targetFrameDuration + f.carryDelay - elapsedTime
	if f.carryDelay > f.targetFrameDuration {
		f.carryDelay = f.targetFrameDuration
	} else if f.carryDelay < -f.targetFrameDuration {
		f.carryDelay = -f.targetFrameDuration
	}

	f.lastTime = time.Now()

	return elapsedTime.Milliseconds()

}
