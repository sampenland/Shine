
namespace Shine.Engine
{
    enum Keys
    {
        LeftArrow,
        RightArrow,
        UpArrow,
        DownArrow,

        W,
        A,
        S,
        D
    }

    class InputHandler
    {
        public static InputHandler? Control;
        public static Dictionary<Keys, bool> ?PressedKeys;

        public InputHandler()
        {
            if (Control == null)
            {
                Control = this;
            }

            PressedKeys = new Dictionary<Keys, bool>();
            PopulatePressedKeys();
        }

        private void PopulatePressedKeys()
        {
            if (PressedKeys == null) return;

            PressedKeys.Add(Keys.LeftArrow, false);
            PressedKeys.Add(Keys.RightArrow, false);
            PressedKeys.Add(Keys.UpArrow, false);
            PressedKeys.Add(Keys.DownArrow, false);

            PressedKeys.Add(Keys.W, false);
            PressedKeys.Add(Keys.A, false);
            PressedKeys.Add(Keys.S, false);
            PressedKeys.Add(Keys.D, false);

        }

        public void Update()
        {
            if (PressedKeys == null) return;

            PressedKeys[Keys.UpArrow] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Up);
            PressedKeys[Keys.DownArrow] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Down);
            PressedKeys[Keys.RightArrow] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Right);
            PressedKeys[Keys.LeftArrow] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Left);

            PressedKeys[Keys.W] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.W);
            PressedKeys[Keys.A] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.A);
            PressedKeys[Keys.S] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S);
            PressedKeys[Keys.D] = SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D);

        }

    }
}
