﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class House : InteractiveBarrier
    {
        public House(Texture2D texture) : base(texture)
        {
        }

        public override void InteractAction()
        {
            if (currentlyInteractive)
                Game1.locationManager.DailyUpdate();
            base.InteractAction();
        }
    }
}
