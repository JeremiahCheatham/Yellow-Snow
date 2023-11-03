: background-init ( -- )
    s\" images/background.png\0" DROP background-image background-rect create-texture-and-rect ;

: main-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF clean-and-exit THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                DUP SDL_SCANCODE_ESCAPE = IF clean-and-exit THEN
                SDL_SCANCODE_SPACE = IF .s CR THEN
            THEN
        REPEAT

        player-update
        
        renderer @ SDL_RenderClear DROP

        renderer @ background-image @ 0 background-rect SDL_RenderCopy DROP
        renderer @ player-image @ 0 player-rect 0e 0 player-direction @ SDL_RenderCopyEX DROP

        renderer @ SDL_RenderPresent

        16 SDL_Delay
    FALSE UNTIL ;

