using Shine.Engine;
using Shine.Shine.Sprites.MainMenu;

namespace Shine.Shine.Scenes
{
    class MainMenu : Scene
    {
        public MainMenu(string name) : base(name)
        {
            Player player = new Player(2, "Assets/Tree.png", 32, 32);
            AddSprite(player, 0);
            player.SetPosition(Window.Width/2, Window.Height/2);
        }
    }
}
