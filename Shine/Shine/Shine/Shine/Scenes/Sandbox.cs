using CrossEngine.Engine;
using CrossEngine.Shine.Sprites.MainMenu;

namespace CrossEngine.Shine.Scenes
{
    class Sandbox : Scene
    {
        public Sandbox(string name) : base(name)
        {
            View mainView = new View(0, 0, 1280, 720);
            View miniMap = new View(mainView, new XYf(0f, 0.8f), new XYf(0.2f, 0.2f));

            int[] tiles = {
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0,
            };
            SetTilemap("Assets/Tileset.png", new XYi(32, 32), tiles, 12, 12);
            AddTilemapToView(mainView);
            AddTilemapToView(miniMap);


            Player player = new Player(2, "Assets/Tree.png", 32, 32);
            player.AddToView(mainView);
            player.AddToView(miniMap);

            AddSprite(player, 0);
            player.SetWorldPosition(0, 0);

        }
    }
}
