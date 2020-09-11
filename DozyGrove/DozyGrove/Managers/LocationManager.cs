using DozyGrove.Locations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Managers
{
    public class LocationManager
    {
        protected List<Location> locations;

        public LocationManager()
        {
            locations = new List<Location>();
            locations.Add(new TheGrove());
        }

        public void Update(GameTime gameTime)
        {
            // Needs to change to selected location
            foreach (var location in locations)
                location.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Needs to change to selected location
            foreach (var location in locations)
                location.Draw(spriteBatch);
        }
    }
}
