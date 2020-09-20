using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class Soil : InteractiveSprite
    {
        public Soil() : base(Game1.textures["soil"])
        {
        }
    }
}
