using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine.Engine
{
    abstract class ArrowActor : Sprite
    {
        private float speed = 1f;
        private bool wasd = true;
        private bool movementEnabled = true;

        protected ArrowActor(float movementSpeed, string textureAsset, int texWidth, int texHeight) : 
            base(textureAsset, texWidth, texHeight)
        {
            speed = movementSpeed;
        }

        public void EnableMovement()
        {
            movementEnabled = true;
        }

        public void DisableMovement()
        {
            movementEnabled = false;
        }

        public void DisableWASD()
        {
            wasd = false;
        }

        public void EnableWASD()
        {
            wasd = true;
        }

        public override void Update()
        {
            if (InputHandler.PressedKeys != null)
            {
                if (InputHandler.PressedKeys[Keys.UpArrow] || wasd && InputHandler.PressedKeys[Keys.W])
                {
                    Y -= speed;
                }
            }

            if (InputHandler.PressedKeys != null)
            {
                if (InputHandler.PressedKeys[Keys.DownArrow] || wasd && InputHandler.PressedKeys[Keys.S])
                {
                    Y += speed;
                }
            }

            if (InputHandler.PressedKeys != null)
            {
                if (InputHandler.PressedKeys[Keys.RightArrow] || wasd && InputHandler.PressedKeys[Keys.D])
                {
                    X += speed;
                }
            }

            if (InputHandler.PressedKeys != null)
            {
                if (InputHandler.PressedKeys[Keys.LeftArrow] || wasd && InputHandler.PressedKeys[Keys.A])
                {
                    X -= speed;
                }
            }

            base.Update();
        }
    }
}
