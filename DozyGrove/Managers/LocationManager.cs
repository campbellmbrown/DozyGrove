using DozyGrove.Locations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Managers
{
    public class LocationManager
    {
        protected List<Location> locations { get; set; }

        public LocationManager()
        {
            locations = new List<Location>();

            // TODO: Change to find file based on base directory
            string stringToDeserialise = System.IO.File.ReadAllText(@"D:\Git Projects\DozyGrove\DozyGrove\Locations\grove.txt");
            locations.Add(DeserialiseJSON(stringToDeserialise));
            foreach (var location in locations)
            {
                location.FormGrid();
                location.AddSprites();
            }
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

        private Location DeserialiseJSON(string strJSON)
        {
            Location location = JsonConvert.DeserializeObject<Location>(strJSON);
            return location;
        }

        public void MovePlayer(int vertical, int horizontal) 
        {
            if (locations[0].MovePlayer(vertical, horizontal))
            {
                Game1.sounds["player_move"].Play();
            }
        }
    }
}
