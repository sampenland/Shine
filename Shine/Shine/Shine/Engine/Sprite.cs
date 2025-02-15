using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    class Sprite
    {
        private Texture texture;
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public Sprite(string textureAsset, int texWidth, int texHeight)
        {
            try
            {
                texture = new Texture(textureAsset, new IntRect(0, 0, texWidth, texHeight));
            }
            catch(Exception e)
            {
                Log.Error("Error loading texture: " + textureAsset);
                texture = null;
            }
        }

        public void Update()
        {
            
        }

        public void Render()
        {

        }
    }
}
