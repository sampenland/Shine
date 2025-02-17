﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    public abstract class Sprite
    {
        private Texture ?texture;
        private SFML.Graphics.Sprite ?sprite;
        public string ?Name;
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
                sprite = new SFML.Graphics.Sprite(texture);
            }
            catch(Exception e)
            {
                Log.Error("Error loading texture: " + textureAsset);
                texture = null;
                throw new ArgumentNullException();
            }
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public SFML.Graphics.Sprite GetDrawable()
        {
            if (sprite == null) throw new ArgumentNullException();
            return sprite;
        }

        public virtual void Update()
        {
            if (sprite == null) throw new ArgumentNullException();
            sprite.Position = new SFML.System.Vector2f(X, Y);
        }

        public void Render()
        {
            if (Game.Control != null && Game.Control.gameWindow != null)
            {
                Game.Control.gameWindow.Draw(this);
            }
        }
    }
}
