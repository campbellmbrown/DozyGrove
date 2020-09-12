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
            { 1, new Barrier(new Rectangle(0 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Dark green tree 1
            { 2, new Barrier(new Rectangle(1 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Dark green tree 2
            { 3, new Barrier(new Rectangle(2 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Dark green tree 3
            { 4, new Barrier(new Rectangle(3 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Dark green tree 4
            { 5, new Barrier(new Rectangle(0 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Light green tree 1
            { 6, new Barrier(new Rectangle(1 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Light green tree 2
            { 7, new Barrier(new Rectangle(2 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Light green tree 3
            { 8, new Barrier(new Rectangle(3 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Light green tree 4
            { 9, new Barrier(new Rectangle(0 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Yellow tree 1
            { 10, new Barrier(new Rectangle(1 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Yellow tree 2
            { 11, new Barrier(new Rectangle(2 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Yellow tree 3
            { 12, new Barrier(new Rectangle(3 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Yellow tree 4
            { 13, new Barrier(new Rectangle(0 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Red tree 1
            { 14, new Barrier(new Rectangle(1 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Red tree 2
            { 15, new Barrier(new Rectangle(2 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Red tree 3
            { 16, new Barrier(new Rectangle(3 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Red tree 4
            { 17, new Barrier(new Rectangle(0 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy tree 1
            { 18, new Barrier(new Rectangle(1 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy tree 2
            { 19, new Barrier(new Rectangle(2 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy tree 3
            { 20, new Barrier(new Rectangle(3 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy tree 4
            { 21, new Barrier(new Rectangle(0 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Rock 1
            { 22, new Barrier(new Rectangle(1 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Rock 2
            { 23, new Barrier(new Rectangle(2 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy rock 1
            { 24, new Barrier(new Rectangle(3 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, // Snowy rock 2
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
                    Tile tile = new Tile(new Vector2(i * Tile.tileSize, j * Tile.tileSize));
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
