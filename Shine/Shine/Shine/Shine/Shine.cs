using Shine.Engine;

// Create the game
Game shine = new Game(1280, 720, "Shine v.1.0.0", SFML.Window.Keyboard.Key.Escape);

// Create all the possible scenes
Scene menu = new Scene("MainMenu");
shine.sceneManager.AddScene(menu);

// Start the game
shine.Start(menu);