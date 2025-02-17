using SFML.Graphics;
using SFML.Window;
using static SFML.Graphics.Text;

namespace CrossEngine.Engine
{
    class Window
    {
        static RenderWindow? mainWindow;
        static Keyboard.Key endKey = Keyboard.Key.Escape;
        public bool Running = false;
        private Color backgroundColor = Color.Black;

        public static int Width;
        public static int Height;
        
        public Window(uint width, uint height, string name, Keyboard.Key quitKey = Keyboard.Key.Escape)
        {
            Width = (int)width;
            Height = (int)height;

            mainWindow = new RenderWindow(new VideoMode(width, height), name);
            mainWindow.KeyPressed += WindowKeyPress;
            mainWindow.Closed += WindowClosed;
            endKey = quitKey;
        }

        public void SetView(View view)
        {
            if(mainWindow != null)
            {
                mainWindow.SetView(view);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Draw(Sprite sprite)
        {
            if(mainWindow == null)
            {
                Log.Error("Cannot draw window. Window is null");
                throw new ArgumentNullException();
            }

            if (sprite != null && sprite.GetDrawable() != null)
            {
                
                for(int i = 0; i < sprite.GetViews().Count; i++)
                {
                    KeyValuePair<View, XYf> viewAndPos = sprite.GetViews().ElementAt(i);
                    if (Game.Control == null || Game.Control.gameWindow == null)
                    {
                        throw new ArgumentNullException();
                    }

                    Game.Control.gameWindow.SetView(viewAndPos.Key);
                    sprite.SetRenderPosition(viewAndPos.Value.X, viewAndPos.Value.Y);
                    mainWindow.Draw(sprite.GetDrawable());
                }
            }
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
                throw new ArgumentNullException();
            }

            mainWindow.DispatchEvents();
        }

        public void Render()
        {
            if (mainWindow == null) return;

            mainWindow.Clear(backgroundColor);

            RenderCurrentScene();

            mainWindow.Display();
        }

        private void RenderCurrentScene()
        {
            if (Game.Control == null || mainWindow == null)
            {
                throw new ArgumentNullException();
            }

            List<List<Sprite>> layers = Game.Control.GetSceneManager().CurrentScene.GetDrawLayers();
            mainWindow.Draw(Game.Control.GetSceneManager().CurrentScene.GetTilemap());
            for (int layer = 0; layer < layers.Count; layer++)
            {
                foreach (Sprite sprite in layers[layer])
                {
                    mainWindow.Draw(sprite.GetDrawable());
                }
            }
        }
        public static XYf PixelToWorld(XYi pos)
        {
            return PixelToWorld(pos.X, pos.Y);
        }
        
        public static XYf WorldToPixel(XYf pos)
        {
            return WorldToPixel(pos.X, pos.Y);
        }
        public static XYf PixelToWorld(int x, int y)
        {
            if (mainWindow == null)
            {
                throw new ArgumentNullException();
            }

            SFML.System.Vector2f world = mainWindow.MapPixelToCoords(new SFML.System.Vector2i(x, y));
            return new XYf(world.X, world.Y);
        }
        public static XYf WorldToPixel(float x, float y)
        {
            if (mainWindow == null)
            {
                throw new ArgumentNullException();
            }

            SFML.System.Vector2i pixel = mainWindow.MapCoordsToPixel(new SFML.System.Vector2f(x, y));
            return new XYf(pixel.X, pixel.Y);
        }
        public void End()
        {
            Log.Print("Window Closed");
        }
    }
}
