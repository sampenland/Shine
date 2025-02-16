using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    public abstract class Scene
    {
        const int DRAW_LAYERS = 10;

        public string Name;
        protected List<Sprite> sprites;
        protected List<List<Sprite>> DrawPriorityLayers;

        public Scene(string name)
        {
            Name = name;

            DrawPriorityLayers = new List<List<Sprite>>();
            for(int i = 0; i < DRAW_LAYERS; i++)
            {
                DrawPriorityLayers.Add(new List<Sprite>());
            }
        }

        public List<List<Sprite>> GetDrawLayers()
        {
            return DrawPriorityLayers;
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

            DrawPriorityLayers[layer].Add(sprite);
        }

        protected void RemoveSprite(Sprite sprite)
        {
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
            for (int layer = 0; layer < DRAW_LAYERS; layer++)
            {
                foreach (Sprite sprite in DrawPriorityLayers[layer])
                {
                    sprite.Update();
                }
            }
        }
    }
}
