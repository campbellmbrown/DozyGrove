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
        protected Dictionary<int, Sprite> tileAssignments = new Dictionary<int, Sprite>()
        {
            { 0, null },
            { 1, new Barrier(new Rectangle(0, 0, Tile.tileSize, Tile.tileSize)) },
            { 2, new Barrier(new Rectangle(Tile.tileSize, 0, Tile.tileSize, Tile.tileSize)) },
            { 3, new Barrier(new Rectangle(2 * Tile.tileSize, 0, Tile.tileSize, Tile.tileSize)) },
            { 4, new Barrier(new Rectangle(3 * Tile.tileSize, 0, Tile.tileSize, Tile.tileSize)) }
        };

        public List<Tile> tiles;

        public Location(string fileLocation)
        {
            tiles = new List<Tile>();
            int[,] tileList = LoadLocationData(fileLocation);
            for (int i = 0; i < tileList.GetLength(1); ++i) // rows
            {
                for (int j = 0; j < tileList.GetLength(0); ++j) // columns
                {
                    Tile tile = new Tile(new Vector2(50 + i * Tile.tileSize, 50 + j * Tile.tileSize));
                    tile.SetSprite(tileAssignments[tileList[j, i]]);
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

        public int[,] LoadLocationData(string filename)
        {
            using (var streamReader = new StreamReader(filename))
            {
                var serializer = new JsonSerializer();
                return (int[,])serializer.Deserialize(streamReader, typeof(int[,]));
            }
        }
    }
}
