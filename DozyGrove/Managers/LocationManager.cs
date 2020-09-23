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
        protected Location currentLocation { get; set; }
        protected string currentLocationName { get; set; }

        public LocationManager()
        {
            locations = new List<Location>();
            // TODO: Change to find file based on base directory
            // Reading location files and converting to JSON
            string stringToDeserialise = System.IO.File.ReadAllText(@"D:\Git Projects\DozyGrove\DozyGrove\Locations\grove.txt");
            // Adding the location
            locations.Add(DeserialiseJSON(stringToDeserialise));
            // Forming the grids in each location
            foreach (var location in locations)
            {
                location.FormGrid();
                location.AddSprites();
            }
            // Setting the initial location to be the grove
            SwitchLocation("the_grove");
        }

        public void SwitchLocation(string locationName)
        {
            currentLocation = locations.FirstOrDefault(item => item.locationName == locationName);
        }

        public void Update(GameTime gameTime)
        {
            currentLocation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentLocation.Draw(spriteBatch);
        }

        private Location DeserialiseJSON(string strJSON)
        {
            // TODO - change this method
            TheGrove location = JsonConvert.DeserializeObject<TheGrove>(strJSON);
            return location;
        }

        public void MovePlayer(int vertical, int horizontal) 
        {
            if (currentLocation.MovePlayer(vertical, horizontal))
                Game1.sounds["player_move"].Play();
            else
                Game1.sounds["player_block"].Play();
        }

        public void DailyUpdate()
        {
            currentLocation.DailyUpdate();
        }
    }
}
