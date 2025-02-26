using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine.Engine
{
    public abstract class Scene
    {
        const int DRAW_LAYERS = 10;

        public string Name;
        protected List<Sprite> ?sprites;
        protected List<List<Sprite>> ?DrawPriorityLayers;
        private TileMap ?tilemap;
        protected List<View>? views;
        private ConsoleDisplay inGameConsole;

        public Scene(string name)
        {
            Name = name;

            DrawPriorityLayers = new List<List<Sprite>>();
            for(int i = 0; i < DRAW_LAYERS; i++)
            {
                DrawPriorityLayers.Add(new List<Sprite>());
            }

            inGameConsole = new ConsoleDisplay(0, Window.Height - 100, Window.Width, 100);
            LinkConsole(inGameConsole);
            inGameConsole.Print("Cross Engine Started.");
        }

        virtual public void Start()
        {

        }

        virtual public void End()
        {

        }

        public void LinkConsole(ConsoleDisplay console)
        {
            inGameConsole = console;
        }

        public ConsoleDisplay GetConsole()
        {
            return inGameConsole;
        }

        public void SetTilemap(string asset, XYi tileSize, int[] tiles, int width, int height)
        {
            tilemap = new TileMap(asset);
            tilemap.Load(tileSize, tiles, width, height);
        }

        public void AddTilemapToView(View view)
        {
            if (tilemap == null) return;
            tilemap.AddToView(view);
        }

        public List<List<Sprite>> GetDrawLayers()
        {
            if (DrawPriorityLayers == null) throw new NullReferenceException();
            return DrawPriorityLayers;
        }

        public TileMap ?GetTilemap()
        {
            return tilemap;
        }

        /*
         * Layer :: Higher the value, lower the priority
         */
        protected void AddSprite(Sprite sprite, int layer)
        {
            if (layer >= DRAW_LAYERS)
            {
                Log.Error("Drawing Sprite: " + sprite.Name + " low prioity since layer greater than DRAW_LAYERS");
                layer = DRAW_LAYERS - 1;
            }

            if (DrawPriorityLayers == null) throw new NullReferenceException();
            DrawPriorityLayers[layer].Add(sprite);
        }

        protected void RemoveSprite(Sprite sprite)
        {
            if (DrawPriorityLayers == null) throw new NullReferenceException();
            
            int layerFnd = -1;
            for(int layer = 0; layer < DRAW_LAYERS; layer++)
            {
                foreach(Sprite spr in DrawPriorityLayers[layer])
                {
                    if (spr == sprite)
                    {
                        layerFnd = layer;
                        break;
                    }
                }
            }

            if (layerFnd == -1) return;

            DrawPriorityLayers[layerFnd].Remove(sprite);
        }

        public void Update()
        {
            if (DrawPriorityLayers == null) throw new NullReferenceException();

            if (inGameConsole != null) inGameConsole.Update();

            for (int layer = 0; layer < DRAW_LAYERS; layer++)
            {
                foreach (Sprite sprite in DrawPriorityLayers[layer])
                {
                    sprite.Update();
                    if (sprite != null && sprite.GetDrawable() != null)
                    {

                        for (int i = 0; i < sprite.GetViews().Count; i++)
                        {
                            KeyValuePair<View, XYf> viewAndPos = sprite.GetViews().ElementAt(i);
                            if (Game.Control == null || Game.Control.gameWindow == null)
                            {
                                throw new NullReferenceException();
                            }

                            Game.Control.gameWindow.SetView(viewAndPos.Key);
                            viewAndPos.Key.Update();
                        }
                    }
                }
            }
        }
    }
}
