﻿using CrossEngine.Engine;
using CrossEngine.Shine.Scenes;

new ShineGame();

class ShineGame
{
    public static ShineGame ?control;

    public ShineGame()
    {
        // Create shine singleton
        if (control == null)
        {
            control = this;

            // Create shine game
            Game game = new Game(1280, 720, "Shine v.1.0.0", SFML.Window.Keyboard.Key.Escape);
            
            // Create all the possible scenes and add them to game
            Sandbox menu = new Sandbox("SandBox");
            game.AddScene(menu);

            // Start the game
            game.Start(menu);
        }
    }
}