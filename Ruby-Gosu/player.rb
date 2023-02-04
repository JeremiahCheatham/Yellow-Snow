class Player
    attr_reader :right, :left, :top
    def initialize
        @image = Gosu::Image.new("images/player.png")
        @width = @image.width
        @height = @image.height
        @left_offset = 48
        @right_offset = 44
        @x = ( WIDTH - @width ) / 2
        @left = @x + @left_offset
        @right = @x + @width - @right_offset
        @y = 378
        @top = 390
        @is_right = true
        @speed = 300
    end

    def update(dt)
        # Move the player if left or right held down. Update left and right variables.
        if Gosu.button_down?(Gosu::KB_LEFT)
            @is_right = false
            @left -= @speed * dt
            @left = 0 if @left < 0
            @x = @left - @left_offset
            @right = @x + @width - @right_offset
        end
        if Gosu.button_down?(Gosu::KB_RIGHT)
            @is_right = true
            @right += @speed * dt
            if @right > WIDTH
                @right = WIDTH
            end
            @x = @right - @width + @right_offset
            @left = @x + @left_offset
        end
    end

    def draw
        # Draw player or flip image and adjust by width for left.
        if @is_right
            @image.draw(@x, @y, 0, 1)
        else
            @image.draw(@x + @width, @y, 0, -1)
        end

    end
end