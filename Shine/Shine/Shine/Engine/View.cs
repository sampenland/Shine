namespace CrossEngine.Engine
{
    public class View : SFML.Graphics.View
    {
        public View(int x, int y, int width, int height) : base(new SFML.Graphics.FloatRect(x, y, width, height))
        {

        }

        public View(View viewToAnotherView, XYf viewPortPosition, XYf viewPortSize) : base(viewToAnotherView)
        {
            Viewport = new SFML.Graphics.FloatRect(new SFML.System.Vector2f(viewPortPosition.X, viewPortPosition.Y),
                new SFML.System.Vector2f(viewPortSize.X, viewPortSize.Y));
        }
    }
}
