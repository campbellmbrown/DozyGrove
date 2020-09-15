using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class Player : Sprite
    {
        public Player() : base(Game1.textures["player"])
        {
        }
    }
}
