using CrossEngine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine.Shine.Sprites.MainMenu
{
    class Player : ArrowActor
    {

        public Player(int movementSpeed, string asset, int width, int height) : base(movementSpeed, asset, width, height)
        {
            
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
