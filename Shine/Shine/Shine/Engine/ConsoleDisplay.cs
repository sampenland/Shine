using SFML.Graphics;

namespace CrossEngine.Engine
{   
    public class ConsoleDisplay
    {
        public bool visible = true;

        private List<Text> Texts;
        private RectangleShape background;
        private Font defaultFont;
        private int fontSize = 16;

        private int X;
        private int Y;
        private int Width;
        private int Height;
        private int Spacing = 20;

        public ConsoleDisplay(int x, int y, int width, int height)
        {
            // Load default font if found
            try
            {
                defaultFont = new Font("Assets/fonts/default.ttf");
            }
            catch(Exception ex)
            {
                Log.Error("Default font could not be loaded. Make sure bin has Assets/fonts/default.ttf in it. These files are found in Engine folder.");
                throw new Exception();
            }


            Texts = new List<Text>();
            background = new RectangleShape(new SFML.System.Vector2f(Width, Height));
            background.FillColor = Color.Green;
            background.Position = new SFML.System.Vector2f(X, Y);

            Configure(x, y, width, height);
        }

        public void Configure(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            background.Size = new SFML.System.Vector2f(width, height);
            background.Position = new SFML.System.Vector2f(X, Y);
        }

        public void Print(string text)
        {
            if (Texts.Count >= 5)
            {
                Texts.RemoveAt(0);
            }

            Text newText = new Text(" " + text, defaultFont);
            newText.CharacterSize = (uint)fontSize;
            newText.FillColor = Color.Black;
            newText.Style = Text.Styles.Bold;
            Texts.Add(newText);
        }

        public void Update()
        {
            if (InputHandler.JustPressed != null)
            {
                if (InputHandler.JustPressed[Keys.Tilde])
                {
                    visible = !visible;
                }
            }

            for (int i = 0; i <= 5; i++)
            {
                if (Texts.Count <= i) break;

                if (Texts[i] != null)
                {
                    Texts[i].Position = new SFML.System.Vector2f(X, (Y + (Spacing * i)));
                }
                else
                {
                    break;
                }
            }
        }

        public List<Text> GetTexts()
        {
            return Texts;
        }

        public RectangleShape GetBackground()
        {
            return background;
        }
    }
}
