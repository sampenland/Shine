using SFML.Graphics;
using SFML.Window;

namespace Shine.Engine
{
    class Window
    {
        static RenderWindow? mainWindow;
        static Keyboard.Key endKey = Keyboard.Key.Escape;
        public bool Running = false;
        private Color backgroundColor = Color.Black;
        
        public Window(uint width, uint height, string name, Keyboard.Key quitKey = Keyboard.Key.Escape)
        {
            mainWindow = new RenderWindow(new SFML.Window.VideoMode(width, height), name);
            mainWindow.KeyPressed += WindowKeyPress;
            mainWindow.Closed += WindowClosed;
            endKey = quitKey;
        }

        private void WindowClosed(object? sender, EventArgs e)
        {
            Running = false;
        }

        public void Init(Color background, uint fps = 60)
        {
            Running = true;
            if (mainWindow == null)
            {
                Log.Error("Cannot init. main screen - is null.");
                return;
            }

            mainWindow.SetFramerateLimit(fps);
            backgroundColor = background;
        }

        public void WindowKeyPress(object ?sender, KeyEventArgs e)
        {
            if (e.Code == endKey) Running = false;
        }
        public void Update()
        {
            if (Running == false) return;

            if (mainWindow == null)
            {
                Log.Error("Cannot update main screen - is null");
                Running = false;
                return;
            }

            mainWindow.DispatchEvents();
        }

        public void Render()
        {
            if (mainWindow == null) return;

            mainWindow.Clear(backgroundColor);
            mainWindow.Display();
        }

        public void End()
        {
            Log.Print("Shine Game :: Ended");
        }
    }
}
