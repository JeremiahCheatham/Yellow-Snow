require("gosu")

WIDTH = 800
HEIGHT = 600

class Game < Gosu::Window
    def initialize
        @score = 0
        @playing = true

        super(WIDTH, HEIGHT)

        self.caption = "Don't Eat The Yellow Snow!"

        @font = Gosu::Font.new(30)

        @collect = Gosu::Sample.new("sounds/collect.wav")
        @hit = Gosu::Sample.new("sounds/hit.wav")

        @music = Gosu::Song.new("music/winter_loop.ogg")
        @music.play

        @background = Gosu::Image.new("images/background.png")
        
        @player = Player.new

        @flakes = []
        10.times { @flakes << Flake.new("white") }
        10.times { @flakes << Flake.new("yellow") }
    end

    def update
        if @playing
            @player.update
            @flakes.each do |flake|
                if flake.update(@player.x)
                    if flake.color == "white"
                        @collect.play
                        @score += 1
                        flake.reset
                    else
                        @music.stop
                        @hit.play
                        @playing = false
                    end
                end
            end
        end
    end

    def draw
        @background.draw(0, 0)
        @player.draw
        @flakes.each { |flake| flake.draw }
        @font.draw_text("Score: " + @score.to_s, 10, 10, 0)
    end

    def button_down(id)
        if id == Gosu::KB_ESCAPE
            close
        elsif id == Gosu::KB_SPACE
            @score = 0
            @flakes.each { |flake| flake.reset }
            @music.play
            @playing = true
        end
    end
end

class Player
    attr_reader :x
    def initialize
        @win_width = WIDTH
        @win_height = HEIGHT
        @image = Gosu::Image.new("images/player.png")
        @width = @image.width
        @height = @image.height
        @x = ( @win_width - @width ) / 2
        @y = 378
        @right = true
    end

    def update
        if Gosu.button_down?(Gosu::KB_LEFT)
            @right = false
            @x -= 5
            @x = -40 if @x < -40
        end

        if Gosu.button_down?(Gosu::KB_RIGHT)
            @right = true
            @x += 5
            if @x > @win_width - @width + 36
                @x = @win_width - @width + 36
            end
        end
    end

    def draw
        if @right
            @image.draw(@x, @y, 0, 1)
        else
            @image.draw(@x + @width, @y, 0, -1)
        end

    end
end

class Flake
    @@white_img = Gosu::Image.new("images/white.png")
    @@yellow_img = Gosu::Image.new("images/yellow.png")
    attr_reader :color
    def initialize(color)
        @win_width = WIDTH
        @win_height = HEIGHT
        @color = color
        @image = @color == "white" ? @@white_img : @@yellow_img

        if @color == "white"
            @image = @@white_img
        else
            @image = @@yellow_img
        end
        
        @width = @image.width
        @height = @image.height
        @x = @y = 0
        reset
    end

    def update(player_x)
        @y += 5
        if @y > 520
            reset
        elsif @y > 360
            if @x > player_x + 10 and @x < player_x + 100
                return true
            end
        end
        return false
    end

    def draw
        @image.draw(@x, @y)
    end
    
    def reset
        @x = rand(@win_width - @width)
        @y = -rand(@win_height) - @height
    end
end

Game.new.show