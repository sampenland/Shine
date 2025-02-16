using Shine.Engine;
using Shine.Shine.Sprites.MainMenu;

namespace Shine.Shine.Scenes
{
    class MainMenu : Scene
    {
        public MainMenu(string name) : base(name)
        {
            for(int i = 0; i < 10; i++)
            {
                Tree tree = new Tree();
                AddSprite(tree, 0);
                tree.SetPosition(i * 50, 100);
            }
        }
    }
}
