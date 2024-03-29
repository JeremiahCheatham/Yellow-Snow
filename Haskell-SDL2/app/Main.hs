{-# LANGUAGE OverloadedStrings #-}

-- Load required modules.
import qualified SDL
import qualified SDL.Image
import qualified SDL.Mixer
import qualified SDL.Font
import Foreign.C.Types
import Control.Monad.State
import System.Random
import qualified Data.Text
import Data.Word (Word32)


-- Define a new GameData record.
data GameData = GameData
    { gameRenderer :: SDL.Renderer
    , gameBackground :: SDL.Texture
    , gamePlayer :: SDL.Texture
    , gamePlayerDim :: SDL.V2 CInt
    , gameWhiteFlake :: SDL.Texture
    , gameYellowFlake :: SDL.Texture
    , gameFlakeDim :: SDL.V2 CInt
    , gameMusic :: SDL.Mixer.Music
    , gameCollect :: SDL.Mixer.Chunk
    , gameHit :: SDL.Mixer.Chunk
    , gameFps :: Float
    , gameFlakeVel :: Float
    , gamePlayerVel :: Float }


-- Define a new GameState record.
data GameState = GameState
    { gamePlayerRect :: SDL.Rectangle CInt
    , gamePlayerLeft :: Bool
    , gameFlakes :: [(SDL.Texture, Bool, SDL.Rectangle CInt)]
    , gameCollected :: Int
    , gameScore :: Int
    , gameScoreTex :: SDL.Texture
    , gameScoreRect :: SDL.Rectangle CInt
    , gameOver :: Bool
    , gameLastTime :: Word32
    , gameCarryDelay :: Float
    , gameDeltaTime :: Float
    , gameFpsTime :: Word32
    , gameFpsCount :: Word32
    , gameFpsEnable :: Bool }


-- Load an image in as surface. Get dimensions, free surface, return tex and dim.
loadTexWithDim :: SDL.Renderer -> FilePath -> IO (SDL.Texture, SDL.V2 CInt)
loadTexWithDim renderer imageFile = do
    surf <- SDL.Image.load imageFile
    dim <- SDL.surfaceDimensions surf
    tex <- SDL.createTextureFromSurface renderer surf
    SDL.freeSurface surf
    return (tex, dim)


-- Load all images and sounds assets and return GameData record.
createGameData :: SDL.Renderer -> IO GameData
createGameData renderer = do
    background <- SDL.Image.loadTexture renderer "images/background.png"
    (player, playerDim) <- loadTexWithDim renderer "images/player.png"
    (white, flakeDim) <- loadTexWithDim renderer "images/white.png"
    yellow <- SDL.Image.loadTexture renderer "images/yellow.png"
    collect <- SDL.Mixer.load "sounds/collect.wav"
    hit <- SDL.Mixer.load "sounds/hit.wav"
    music <- SDL.Mixer.load "music/winter_loop.mp3"
    return GameData
        { gameRenderer = renderer
        , gameBackground = background
        , gamePlayer = player
        , gamePlayerDim = playerDim
        , gameWhiteFlake = white
        , gameYellowFlake = yellow
        , gameFlakeDim = flakeDim
        , gameMusic = music
        , gameCollect = collect
        , gameHit = hit
        , gameFps = 1000 / 60
        , gameFlakeVel = 300
        , gamePlayerVel = 300 }


-- Load all state assets and return GameState record.
createGameState :: GameData -> IO GameState
createGameState gameData = do
    let renderer = gameRenderer gameData
        playerDim = gamePlayerDim gameData
        flakeDim = gameFlakeDim gameData
        white = gameWhiteFlake gameData
        yellow = gameYellowFlake gameData
    let playerRect = SDL.Rectangle (SDL.P (SDL.V2 350 374)) playerDim
    whiteFlakes <- sequence (replicate 10 (generateFlake white True flakeDim))
    yellowFlakes <- sequence (replicate 5 (generateFlake yellow False flakeDim))
    (scoreTex, scoreRect) <- generateMsg renderer 10 10 ("Score: 0") 24
    return GameState
        { gamePlayerRect = playerRect
        , gamePlayerLeft = False
        , gameFlakes = whiteFlakes ++ yellowFlakes
        , gameCollected = 0
        , gameScore = 0
        , gameScoreTex = scoreTex
        , gameScoreRect = scoreRect
        , gameOver = False
        , gameLastTime = 0
        , gameCarryDelay = 0
        , gameDeltaTime = 0
        , gameFpsTime = 0
        , gameFpsCount = 0
        , gameFpsEnable = False }


-- Generate a flake 2 screens above window.
generateFlake :: SDL.Texture -> Bool -> SDL.V2 CInt -> IO (SDL.Texture, Bool, SDL.Rectangle CInt)
generateFlake tex color dim = do
    let (SDL.V2 width height) = dim
    x <- randomRIO (0, 800 - width)
    y <- randomRIO (0, 1200)
    let y' = (-y) - height
    let rect = SDL.Rectangle (SDL.P (SDL.V2 x y')) dim
    return (tex, color, rect)


-- Generate a texture and rect from a string.
generateMsg :: SDL.Renderer -> CInt -> CInt -> String -> Int -> IO (SDL.Texture, SDL.Rectangle CInt)
generateMsg renderer x y msg size = do
    font <- SDL.Font.load "fonts/freesansbold.ttf" size
    let text = Data.Text.pack msg
    surf <- SDL.Font.blended font (SDL.V4 255 255 255 255) text
    dim <- SDL.surfaceDimensions surf
    let rect = SDL.Rectangle (SDL.P (SDL.V2 x y)) dim
    tex <- SDL.createTextureFromSurface renderer surf
    SDL.Font.free font
    SDL.freeSurface surf
    return (tex, rect)


-- Check the direction keys if they are in the down state and return the updated player position
checkKeysDown :: SDL.Rectangle CInt -> (SDL.Scancode -> Bool) -> Bool -> Float -> Float -> (SDL.Rectangle CInt, Bool)
checkKeysDown playerRect keyboardState leftBool velX deltaTime = do
    -- Get bool for each key thats down.
    let leftPressed = keyboardState SDL.ScancodeLeft
    let rightPressed = keyboardState SDL.ScancodeRight

    -- Deconstruct the Rect to its parts.
    let (SDL.Rectangle (SDL.P (SDL.V2 oldX oldY)) playerDim) = playerRect
    let (SDL.V2 width _) = playerDim

    let leftBool' = if leftPressed && not rightPressed then True
                    else if rightPressed && not leftPressed then False
                    else leftBool

    -- Update the x and y position.
    let x = if leftPressed && not rightPressed then oldX - round (velX * deltaTime)
            else if rightPressed && not leftPressed then oldX + round (velX * deltaTime)
            else oldX

    -- Check bounds and update x and y.
    let x' = if x < -40 then -40
            else if x > 800 - width + 36 then 800 - width + 36
            else x

    -- Return the updated rectangle.
    ((SDL.Rectangle (SDL.P (SDL.V2 x' oldY)) playerDim), leftBool')


-- Check all the events and return whether escape or space are pressed.
checkKeysPressed :: [SDL.Event] -> (Bool, Bool)
checkKeysPressed events = foldr checkKey (False, False) events
    where checkKey event (quit, space) =
            case SDL.eventPayload event of
                SDL.KeyboardEvent keyboardEvent ->
                    if SDL.keyboardEventKeyMotion keyboardEvent == SDL.Pressed then
                        case SDL.keysymKeycode (SDL.keyboardEventKeysym keyboardEvent) of
                            SDL.KeycodeEscape -> (True, space)
                            SDL.KeycodeSpace -> (quit, True)
                            _ -> (quit, space)
                    else (quit, space)
                SDL.QuitEvent -> (True, space)
                _ -> (quit, space)


-- Free all asset memory and shutdown SDL.
cleanup :: GameData -> GameState -> SDL.Window -> IO ()
cleanup gameData gameState window = do
    let renderer = gameRenderer gameData
        background = gameBackground gameData
        player = gamePlayer gameData
        white = gameWhiteFlake gameData
        yellow = gameYellowFlake gameData
        collect = gameCollect gameData
        hit = gameHit gameData
        music = gameMusic gameData
    let scoreTex = gameScoreTex gameState
    SDL.Mixer.free music
    SDL.Mixer.free collect
    SDL.Mixer.free hit
    SDL.destroyTexture scoreTex
    SDL.destroyTexture white
    SDL.destroyTexture yellow
    SDL.destroyTexture player
    SDL.destroyTexture background
    SDL.destroyRenderer renderer
    SDL.destroyWindow window
    SDL.Mixer.closeAudio
    SDL.Font.quit


main :: IO ()
main = do
    -- Initialize SDL and SDL.TTF for use.
    SDL.initializeAll
    SDL.Font.initialize

    -- Initialize SDL Mixer.
    let myAudioConfig = SDL.Mixer.Audio { SDL.Mixer.audioFrequency = 44100
                                        , SDL.Mixer.audioFormat = SDL.Mixer.FormatS16_LSB
                                        , SDL.Mixer.audioOutput = SDL.Mixer.Stereo }
    SDL.Mixer.openAudio myAudioConfig 1024

    -- Create the window and renderer.
    window <- SDL.createWindow "Don't Eat The Yellow Snow!" SDL.defaultWindow
    renderer <- SDL.createRenderer window (-1) SDL.defaultRenderer

    -- Set the Window icon to the yellow flake.
    icon <- SDL.Image.load "images/yellow.png"
    SDL.setWindowIcon window icon
    SDL.freeSurface icon

    -- Load all images and sounds assets and return GameData record.
    gameData <- createGameData renderer

    -- Load all state assets and return GameState record.
    gameState <- createGameState gameData

    -- Start playing background music on repeat.
    SDL.Mixer.playMusic SDL.Mixer.Forever $ gameMusic gameData

    -- Start the main game loop using the gameState.
    evalStateT (gameLoop gameData) gameState

    -- Free all asset memory and shutdown SDL.
    cleanup gameData gameState window


-- Update all Flakes keeping track of white flakes collected and if a yellow flake was hit.
updateFlakes :: [(SDL.Texture, Bool, SDL.Rectangle CInt)] -> SDL.V2 CInt -> Int -> Bool -> Float -> Float -> IO ([(SDL.Texture, Bool, SDL.Rectangle CInt)], Int, Bool)
updateFlakes [] _ collected over _ _ = return ([], collected, over)
updateFlakes (x:xs) playerPos collected over velY deltaTime = do
    (flake, newCollected, newOver) <- updateFlake x playerPos velY deltaTime
    (flakes, finalCollected, finalOver) <- updateFlakes xs playerPos (newCollected + collected) (newOver || over) velY deltaTime
    return (flake : flakes, finalCollected, finalOver)


-- Update a falling flake. If it his the ground reset above the screen, else check if collided with player.
updateFlake :: (SDL.Texture, Bool, SDL.Rectangle CInt) -> SDL.V2 CInt -> Float -> Float -> IO ((SDL.Texture, Bool, SDL.Rectangle CInt), Int, Bool)
updateFlake (tex, color, (SDL.Rectangle (SDL.P (SDL.V2 x y)) (SDL.V2 w h))) (SDL.V2 playerX _ ) velY deltaTime = do
    let y' = y + round ( velY * deltaTime )
    (x', y'', s, o) <-
        if y' > 520 then do
            numX <- randomRIO (0, 800 - w)
            numY <- randomRIO (0, 600)
            let numY' = (-numY) - h
            return (numX, numY', 0, False)
        else if y' > 354 && x > (playerX + 10) && x < (playerX + 100) then
            if color then do
                numX <- randomRIO (0, 800 - w)
                numY <- randomRIO (0, 600)
                let numY' = (-numY) - h
                return (numX, numY', 1, False)
            else return (x, y', 0, True)
        else return (x, y', 0, False)
    return ((tex, color, (SDL.Rectangle (SDL.P (SDL.V2 x' y'')) (SDL.V2 w h))), s, o)


-- Resets all flakes somewhere 2 screens above the window. For game reset.
resetFlakes :: [(SDL.Texture, Bool, SDL.Rectangle CInt)] -> IO [(SDL.Texture, Bool, SDL.Rectangle CInt)]
resetFlakes = mapM (\(tex, color, (SDL.Rectangle (SDL.P _) (SDL.V2 w h))) -> do
    numX <- randomRIO (0, 800 - w)
    numY <- randomRIO (0, 1200)
    let numY' = (-numY) - h
    return (tex, color, (SDL.Rectangle (SDL.P (SDL.V2 numX numY')) (SDL.V2 w h))))


-- Rest game.
resetGame :: SDL.Renderer -> SDL.Mixer.Music -> StateT GameState IO ()
resetGame renderer music = do
    gameState <- get
    let oldFlakes = gameFlakes gameState
        oldScoreTex = gameScoreTex gameState
    newFlakes <- liftIO $ resetFlakes oldFlakes
    (newScoreTex, newScoreRect) <- liftIO $ generateMsg renderer 10 10 "Score: 0" 24
    SDL.destroyTexture oldScoreTex
    _ <- liftIO $ SDL.Mixer.playMusic SDL.Mixer.Forever music
    put gameState { gameScore = 0
                  , gameFlakes = newFlakes
                  , gameScoreTex = newScoreTex
                  , gameScoreRect = newScoreRect
                  , gameOver = False }


-- Get current state of keyboard and update position and direction facing.
updatePlayer :: Float -> StateT GameState IO ()
updatePlayer velX = do
    keyboardState <- SDL.getKeyboardState
    gameState <- get
    let oldPlayerRect = gamePlayerRect gameState
        oldPlayerLeft = gamePlayerLeft gameState
        deltaTime = gameDeltaTime gameState
    let (newPlayerRect, newPlayerLeft) = checkKeysDown oldPlayerRect keyboardState oldPlayerLeft velX deltaTime
    put gameState { gamePlayerRect = newPlayerRect, gamePlayerLeft = newPlayerLeft }


-- Only update flakes if game is not over.
checkCollision :: SDL.Mixer.Chunk -> Float -> StateT GameState IO ()
checkCollision hit velY = do
    gameState <- get
    let deltaTime = gameDeltaTime gameState
        oldFlakes = gameFlakes gameState
        (SDL.Rectangle (SDL.P playerPos) _ ) = gamePlayerRect gameState
    (newFlakes, newCollected, newOver) <- liftIO $ updateFlakes oldFlakes playerPos 0 False velY deltaTime
    when newOver $ do
        SDL.Mixer.haltMusic
        SDL.Mixer.play hit
    put gameState { gameFlakes = newFlakes, gameCollected = newCollected, gameOver = newOver }


-- Update the score and score texture.
updateScore :: SDL.Renderer -> SDL.Mixer.Chunk -> StateT GameState IO ()
updateScore renderer collect = do
    gameState <- get
    let newCollected = gameCollected gameState
    when (newCollected > 0) $ do
        let newScore = (gameScore gameState) + newCollected
            oldScoreTex = gameScoreTex gameState
        SDL.Mixer.play collect
        (newScoreTex, newScoreRect) <- liftIO $ generateMsg renderer 10 10 ("Score: " ++ show newScore) 24
        SDL.destroyTexture oldScoreTex
        put gameState { gameCollected = 0
                      , gameScore = newScore
                      , gameScoreTex = newScoreTex
                      , gameScoreRect = newScoreRect }


drawEverything  :: GameData -> StateT GameState IO ()
drawEverything gameData = do
    gameState <- get
    let playerRect = gamePlayerRect gameState
        playerLeft = gamePlayerLeft gameState
        flakes = gameFlakes gameState
        scoreTex = gameScoreTex gameState
        scoreRect = gameScoreRect gameState
    let renderer = gameRenderer gameData
        background = gameBackground gameData
        player = gamePlayer gameData

    -- Clear the renderer
    SDL.clear $ renderer

    -- Draw the assets to the renderer.
    SDL.copy renderer background Nothing Nothing
    SDL.copyEx renderer player Nothing (Just playerRect) 0 Nothing (SDL.V2 playerLeft False)

    -- Draw all flakes to the renderer.
    liftIO $ mapM_ (\(tex, _, rect) -> SDL.copy renderer tex Nothing (Just rect)) flakes

    -- Draw the score.
    SDL.copy renderer scoreTex Nothing (Just scoreRect)

    -- Present the renderer/flip back and front buffers.
    SDL.present renderer


fpsPrint :: StateT GameState IO ()
fpsPrint = do
    gameState <- get
    when (gameFpsEnable gameState) $ do
        let fpsTime = gameFpsTime gameState
            fpsCount = gameFpsCount gameState
        currentTime <- SDL.ticks
        (newTime, newCount) <-
            if (currentTime >= fpsTime ) then do
                if ((currentTime - 1000) > fpsTime) then do
                    liftIO $ putStrLn $ show fpsCount
                    return (fpsTime + 1000, 1)
                else 
                    return (fpsTime , fpsCount + 1)
            else return (fpsTime, fpsCount + 1)
        put gameState { gameFpsTime = newTime, gameFpsCount = newCount }


fpsDelay :: Float -> StateT GameState IO ()
fpsDelay frameDelay = do
    gameState <- get
    let lastTime = gameLastTime gameState
        carryDelay = gameCarryDelay gameState
    
    firstTime <- SDL.ticks
    (newCarryDelay, newTime, newElapsedTime) <-
        if (firstTime >= lastTime) then do
            let elapsedTime = fromIntegral (firstTime - lastTime)
            if ((frameDelay + carryDelay) > elapsedTime) then do
                let delay = frameDelay - elapsedTime + carryDelay
                SDL.delay $ round delay
                secondTime <- SDL.ticks
                if (secondTime >= lastTime) then do
                    let secondElapsedTime = fromIntegral (secondTime - lastTime)
                    return ((frameDelay - secondElapsedTime + carryDelay), secondTime, secondElapsedTime)
                else return (0, secondTime, elapsedTime)
            else return ((frameDelay - elapsedTime + carryDelay), firstTime, elapsedTime)
        else return (0, firstTime, 0)

    let newCarryDelay' =
            if (newCarryDelay > frameDelay) then frameDelay
            else if (newCarryDelay < (-frameDelay)) then (-frameDelay)
            else newCarryDelay
    
    let deltaTime = newElapsedTime / 1000

    put gameState { gameLastTime = newTime
                  , gameCarryDelay = newCarryDelay'
                  , gameDeltaTime = deltaTime }


-- Main game loop using gameState.
gameLoop :: GameData -> StateT GameState IO ()
gameLoop gameData = do
    -- Get the current gameState. Get current gameState variables.
    gameState <- get
    let over = gameOver gameState

    -- Get current events and check for key pressed events.
    events <- SDL.pollEvents
    let (quitRequest, spacePressed) = ( checkKeysPressed events )

    if over then do
        when spacePressed $ resetGame (gameRenderer gameData) (gameMusic gameData)
    else do
        updatePlayer (gamePlayerVel gameData)
        checkCollision (gameHit gameData) (gameFlakeVel gameData)
        updateScore (gameRenderer gameData) (gameCollect gameData)

    drawEverything gameData

    fpsPrint
    fpsDelay $ gameFps gameData

    -- Loop unless escaped pressed.
    unless quitRequest (gameLoop gameData)