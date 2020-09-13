using DozyGrove.Models;
using DozyGrove.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Locations
{
    public class Location
    {
        public string name { get; set; }
        public int id { get; set; }
        public List<BarrierModel> barriers { get; set; }
        public List<DecorationModel> decorations { get; set; }
        public List<Tile> tiles { get; set; }

        public class BarrierModel : JSONSpriteModel { }
        public class DecorationModel : JSONSpriteModel { }

        public class JSONSpriteModel
        {
            public string type { get; set; }
            public List<int[]> positions { get; set; }
        }

        // Barrier dictionary
        protected Dictionary<string, Sprite> barrierTileAssignments = new Dictionary<string, Sprite>()
        {
            { "dark_green_tree_1", new Barrier(new Rectangle(0 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_2", new Barrier(new Rectangle(1 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_3", new Barrier(new Rectangle(2 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_4", new Barrier(new Rectangle(3 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_1", new Barrier(new Rectangle(0 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_2", new Barrier(new Rectangle(1 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_3", new Barrier(new Rectangle(2 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_4", new Barrier(new Rectangle(3 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_1", new Barrier(new Rectangle(0 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_2", new Barrier(new Rectangle(1 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_3", new Barrier(new Rectangle(2 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_4", new Barrier(new Rectangle(3 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_1", new Barrier(new Rectangle(0 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_2", new Barrier(new Rectangle(1 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_3", new Barrier(new Rectangle(2 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_4", new Barrier(new Rectangle(3 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_1", new Barrier(new Rectangle(0 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_2", new Barrier(new Rectangle(1 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_3", new Barrier(new Rectangle(2 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_4", new Barrier(new Rectangle(3 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "rock_1", new Barrier(new Rectangle(0 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "rock_2", new Barrier(new Rectangle(1 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_rock_1", new Barrier(new Rectangle(2 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_rock_2", new Barrier(new Rectangle(3 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "fallen_log", new Barrier(new Rectangle(4 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "tree_stump_1", new Barrier(new Rectangle(4 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "tree_stump_2", new Barrier(new Rectangle(4 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, 
        };

        // Decoration dictionary
        protected Dictionary<string, Sprite> decorationTileAssignments = new Dictionary<string, Sprite>()
        {
            { "patch", new Decoration(new Rectangle(0 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "small_grass_1", new Decoration(new Rectangle(1 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "small_grass_2", new Decoration(new Rectangle(2 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
        };

        public void AddSprites()
        {
            tiles = new List<Tile>();
            foreach (var barrier in barriers) // Add barriers
            {
                foreach (var position in barrier.positions)
                {
                    Tile tile = new Tile(new Vector2(position[0], position[1]));
                    tile.SetSprite(barrierTileAssignments[barrier.type]);
                    tiles.Add(tile);
                }
            }
            // Add decorations
            foreach (var decoration in decorations)
            {
                foreach (var position in decoration.positions)
                {
                    Tile tile = new Tile(new Vector2(position[0], position[1]));
                    tile.SetSprite(decorationTileAssignments[decoration.type]);
                    tiles.Add(tile);
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var tile in tiles)
                tile.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
                tile.Draw(spriteBatch);
        }
    }
}
