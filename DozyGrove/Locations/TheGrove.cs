using DozyGrove.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Locations
{
    public class TheGrove : Location
    {
        public int[] houseIdx { get; set; }

        public override void AddSprites()
        {
            tiles[houseIdx[0], houseIdx[1]].sprite = new House(Game1.textures["house"]);
            base.AddSprites();
        }
    }
}
