using Shine.Engine;
using Shine.Shine.Sprites.MainMenu;

namespace Shine.Shine.Scenes
{
    class MainMenu : Scene
    {
        public MainMenu(string name) : base(name)
        {
            Tree tree = new Tree();
            AddSprite(tree, 0);
            tree.SetPosition(100, 100);
        }
    }
}
