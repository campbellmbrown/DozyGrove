using DozyGrove.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class Decoration : Sprite
    {
        public Decoration(Texture2D texture, Rectangle textureRectangle) : base(texture, textureRectangle)
        {
        }

        public Decoration(Texture2D texture) : base(texture)
        {
        }

        public Decoration(Animation animation) : base(animation)
        {
        }
    }
}
