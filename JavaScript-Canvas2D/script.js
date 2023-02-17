"use strict";

const canvas = document.getElementById('gameCanvas');
const ctx = canvas.getContext('2d');

// Set the font properties
ctx.font = '24px FreeSansBold';
ctx.fillStyle = 'white';


const backgroundImg = new Image();
const playerImg = new Image();
const whiteImg = new Image();
const yellowImg = new Image();
const collect = new Audio();
const hit = new Audio();
const music = new Audio();

const keysPressed = new Set();

// All assets to be loaded.
const resources = [
    { src: 'images/background.png', img: backgroundImg },
    { src: 'images/player.png', img: playerImg },
    { src: 'images/white.png', img: whiteImg },
    { src: 'images/yellow.png', img: yellowImg },
    { src: 'sounds/collect.wav', audio: collect },
    { src: 'sounds/hit.wav', audio: hit },
    { src: 'music/winter_loop.ogg', audio: music, loop: true },
    { src: 'fonts/freesansbold.ttf', font: 'FreeSansBold' }
];

const promises = resources.map(({ src, img, audio, font, loop }) => {
    return new Promise((resolve) => {
        if (img) {
            img.src = src;
            img.addEventListener('load', resolve);
        } else if (audio) {
            audio.src = src;
            audio.loop = loop || false;
            audio.addEventListener('canplaythrough', resolve);
        } else if (font) {
            const fontFace = new FontFace(font, `url(${src})`);
            fontFace.load().then(() => {
                document.fonts.add(fontFace);
                resolve();
            });
        } else {
            resolve();
        }
    });
});
  
const resourcesLoadedPromise = Promise.all(promises);
  

class Flake {
    constructor(image, color) {
        this._image = image;
        this._color = color;
        this._speed = 300;
        this.x = 300;
        this.y = 0;
        this._width = this._image.width;
        this._height = this._image.height;
        this.reset(true);
    }

    get color() {
        return this._color;
    }

    reset(full) {
        this.x = Math.floor(Math.random() * (canvas.width - this._width));
        let height = (full) ? canvas.height * 2 : canvas.height;
        this.y = -Math.floor(Math.random() * height) - this._height;
    }

    get left() {
        return this.x;
    }

    get right() {
        return this.x + this._width;
    }

    get bottom() {
        return this.y + this._height;
    }

    update(dt) {
        this.y += this._speed * dt;
    }

    draw(ctx) {
        // Draw flake.
        ctx.drawImage(this._image, this.x, this.y);
    }
}


class Player {
    constructor(image) {
        this._image = image;
        this._speed = 300;
        this.y = 378;
        this.top = 390;
        this._is_right = true;
        this._left_offset = 48;
        this._right_offset = 44;
        this._width = this._image.width;
        this._height = this._image.height;
        this.x = (canvas.width - this._width) / 2;
    }

    get left() {
        return this.x + this._left_offset;
    }

    set left(newLeft) {
        this.x = newLeft - this._left_offset;
    }

    get right() {
        return this.x + this._width - this._right_offset;
    }

    set right(newRight) {
        this.x = newRight + this._right_offset - this._width;
    }

    update(dt) {
        if (keysPressed.has('ArrowLeft')) {
            this._is_right = false;
            this.left -= this._speed * dt;
            this.left = (this.left < 0) ? 0 : this.left;
        }
        if (keysPressed.has('ArrowRight')) {
            this._is_right = true;
            this.right += this._speed * dt;
            if (this.right > canvas.width) {
                this.right = canvas.width;
            }
        }
    }

    draw(ctx) {
        // Draw player or flip image and adjust by width for left.
        if (this._is_right) {
            ctx.drawImage(this._image, this.x, this.y);
        } else {
            ctx.save();
            ctx.scale(-1, 1);
            ctx.drawImage(this._image, -this.x - this._width, this.y);
            ctx.restore();
        }
    }
}

resourcesLoadedPromise.then(() => {
    function gameLoop(timeStamp) {
        let dt = (timeStamp - lastTime) / 1000;
        lastTime = timeStamp;
    
        // Update game state
        if (playing) {
            player.update(dt);
            flakes.forEach(flake => {
                flake.update(dt);
                if (flake.bottom > 550) {
                    flake.reset(false)
                } else if (flake.bottom > player.top && flake.right > player.left && flake.left < player.right) {
                    if (flake.color) {
                        // collect.play();
                        collect.cloneNode().play();
                        flake.reset(false)
                        score += 1;
                    } else {
                        music.pause();
                        music.currentTime = 0;
                        hit.play();
                        playing = false;
                    }
                }
            });
        }
    
        // Clear the canvas
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.drawImage(backgroundImg, 0, 0, canvas.width, canvas.height);
    
        // Draw game objects
        player.draw(ctx);
        flakes.forEach(flake => {
            flake.draw(ctx);
        });

        // Draw the score on the canvas
        ctx.fillText(`Score: ${score}`, 10, 30);
    
        // Schedule the next animation frame
        requestAnimationFrame(gameLoop);
    }

    window.addEventListener('keyup', (event) => {
        keysPressed.delete(event.key);
    });
    
    window.addEventListener('keydown', (event) => {
        keysPressed.add(event.key);
        if (event.key === 'Escape') {
            window.close();
        } else if (event.key === ' ') {
            if (!playing) {
                score = 0;
                playing = true;
                music.play();
                flakes.forEach(flake => {
                    flake.reset(true);
                });
            }
        }
    });

    let playing = true;
    let score = 0;
    let lastTime = performance.now();
    const player = new Player(playerImg);

    const flakes = [];
    for (let i = 0; i < 10; i++) {
        flakes.push(new Flake(whiteImg, true));
    }
    for (let i = 0; i < 5; i++) {
        flakes.push(new Flake(yellowImg, false));
    }

    music.play();
  
    // Start the game loop
    requestAnimationFrame(gameLoop);
}).catch((err) => {
    console.error('Error loading resources:', err);
});