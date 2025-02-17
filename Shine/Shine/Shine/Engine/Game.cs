using SFML.Window;

namespace Shine.Engine
{
    class Game
    {
        public static Game? Control;

        // IMPORTANT
        public Window ?gameWindow = null;
        private SceneManager sceneManager;
        private InputHandler inputHandler;

        // Secondary
        public static float DeltaTime;
        public static bool IsRunning = false;

        public Game(uint windowWidth, uint windowHeight, string gameName, Keyboard.Key endKey)
        {
            if (Control == null)
            {
                Control = this;
            }

            gameWindow = new Window(windowWidth, windowHeight, gameName, endKey);
            sceneManager = new SceneManager();
            inputHandler = new InputHandler();
        }

        private void Init()
        {
            if (gameWindow == null)
            {
                Log.Error("Could not init Cross Engine. Null window.");
                return;
            }

            gameWindow.Init(SFML.Graphics.Color.Black);
        }

        public void Start(Scene startScene)
        {
            Init();
            Log.Print("Cross Engine booted.");
            sceneManager.ChangeScene(startScene);
            IsRunning = true;
            Update();
        }

        public void AddScene(Scene scene)
        {
            sceneManager.AddScene(scene);
        }

        public void RemoveScene(Scene scene)
        {
            sceneManager.RemoveScene(scene);
        }

        private void Update()
        {
            if (gameWindow == null)
            {
                Log.Error("Cannot update game. Window null.");
                End();
                return;
            }

            while(IsRunning)
            {
                if (!gameWindow.Running) break;

                // Update inputs
                inputHandler.Update();
                gameWindow.Update();
                sceneManager.Update();

                // Update display
                gameWindow.Render();
            }

            End();
        }

        public void End()
        {
            Log.Print("Cross Engine shutdown.");
        }

        public SceneManager GetSceneManager()
        {
            return sceneManager;
        }

    }
}
