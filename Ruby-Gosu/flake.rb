class Flake
    @@white_img = Gosu::Image.new("images/white.png")
    @@yellow_img = Gosu::Image.new("images/yellow.png")
    attr_reader :color, :right, :left, :top, :bottom
    def initialize(color, running)
        @speed = 300
        @color = color
        @image = @color == "white" ? @@white_img : @@yellow_img
        @width = @image.width
        @height = @image.height
        @x = @y = @top = @bottom = @left = @right = 0
        reset(running)
    end

    def update(dt)
        @y += @speed * dt
        @top = @y
        @bottom = @y + @height
    end

    def draw
        @image.draw(@x, @y)
    end
    
    def reset(running)
        # Reset flake to random position above the screen. Or 2 screens above if game reset.
        @x = rand(WIDTH - @width)
        if running
            @y = -@height - rand(HEIGHT)
        else
            @y = -@height - rand(HEIGHT * 2)
        end
        @left = @x
        @right = @x + @width
        @top = @y
        @bottom = @y + @height
    end
end