require("gosu")
require_relative("player")
require_relative("flake")

WIDTH = 800
HEIGHT = 600

class Game < Gosu::Window
    def initialize
        super(WIDTH, HEIGHT)

        # Set the window Caption.
        self.caption = "Don't Eat The Yellow Snow!"

        # Game variables.
        @score = 0
        @playing = false
        @ground = 550

        # Load background image.
        @background = Gosu::Image.new("images/background.png")
        
        # Create player.
        @player = Player.new

        # Generate flakes.
        @flakes = []
        10.times { @flakes << Flake.new("white", @playing) }
        5.times { @flakes << Flake.new("yellow", @playing) }

        # Load sound effects.
        @collect = Gosu::Sample.new("sounds/collect.wav")
        @hit = Gosu::Sample.new("sounds/hit.wav")

        # Load and start playing music.
        @music = Gosu::Song.new("music/winter_loop.ogg")
        @music.play

        # Create font.
        @font = Gosu::Font.new(24, options = {name: "fonts/freesansbold.ttf"})

        @playing = true
    end

    def update
        if @playing
            # Get the delta time since last update.
            dt = update_interval / 1000

            # Update player and flake movement using dt.
            @player.update(dt)
            @flakes.each do |flake|
                flake.update(dt)

                # Check for flake collisions with player or ground.
                check_collision(flake, @player)
            end
        end
    end

    def draw
        # Draw everything from back to front.
        @background.draw(0, 0)
        @player.draw
        @flakes.each { |flake| flake.draw }
        @font.draw_text("Score: " + @score.to_s, 10, 10, 0)
    end

    def button_down(id)
        # Check if a key was pressed. Escape to close and Space to reset.
        if id == Gosu::KB_ESCAPE
            close
        elsif (id == Gosu::KB_SPACE) && !@playing
            @score = 0
            @flakes.each { |flake| flake.reset(@playing) }
            @music.play
            @playing = true
        end
    end

    def check_collision(flake, player)
        # Reset flake above screen if hitting the ground.
        if flake.bottom > @ground
            flake.reset(@playing)
        # Check flake collision with player. White scores and yellow ends the game.
        elsif flake.bottom > player.top && flake.right > player.left && flake.left < player.right
            if flake.color == "white"
                @collect.play
                @score += 1
                flake.reset(@playing)
            else
                @music.stop
                @hit.play
                @playing = false
            end
        end
    end
end

Game.new.show