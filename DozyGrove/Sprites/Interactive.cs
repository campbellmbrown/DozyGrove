﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class InteractiveSprite : Sprite
    {
        public InteractiveSprite(Texture2D texture) : base(texture)
        {
        }

        public InteractiveSprite(Texture2D texture, Rectangle textureRectangle) : base(texture, textureRectangle)
        {
        }
    }
}
