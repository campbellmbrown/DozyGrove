using DozyGrove.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class Soil : InteractiveSprite
    {
        public Plant plant;
        public bool hasPlant { get { return plant != null; } }

        public Soil() : base(Game1.textures["soil"])
        {
            if (Game1.r.Next(1, 101) <= 20)
                plant = new Plant(Game1.textures["plants"], "tomato");
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            base.Draw(spriteBatch, position);
            if (hasPlant)
                plant.Draw(spriteBatch, position);
        }

        public override void DailyUpdate()
        {
            if (!hasPlant && Game1.r.Next(1, 101) <= 5)
                plant = new Plant(Game1.textures["plants"], "weed");
            if (hasPlant)
                plant.Grow();
            base.DailyUpdate();
        }
    }
}
