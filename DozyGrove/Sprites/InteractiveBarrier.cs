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
    public class InteractiveBarrier : Barrier
    {
        public bool currentlyInteractive = false;

        public InteractiveBarrier(Texture2D texture, Rectangle textureRectangle) : base(texture, textureRectangle)
        {
        }

        public InteractiveBarrier(Texture2D texture) : base(texture)
        {
        }

        public InteractiveBarrier(Animation animation) : base(animation)
        {
        }

        public virtual void InteractAction()
        {
        }
    }
}
