using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Models
{
    public class Plant
    {
        protected Texture2D texture { get; set; }
        protected string plantType { get; set; }
        protected Rectangle textureRectangle { get; set; }
        protected int stage { get; set; }
        protected int maxStage { get; set; }

        public Dictionary<string, int> maxStages = new Dictionary<string, int>()
        {
            { "weed", 1 },
            { "tomato", 6 }
        };

        public Dictionary<int, Rectangle> tomatoAssignments = new Dictionary<int, Rectangle>()
        {
            { 1, new Rectangle(0 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
            { 2, new Rectangle(1 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
            { 3, new Rectangle(2 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
            { 4, new Rectangle(3 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
            { 5, new Rectangle(4 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
            { 6, new Rectangle(5 * Tile.tileSize, Tile.tileSize, Tile.tileSize, Tile.tileSize) },
        };

        public Plant(Texture2D texture, string plantType)
        {
            this.texture = texture;
            this.plantType = plantType;
            stage = 1;
            maxStage = maxStages[plantType];
            UpdateRectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, textureRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Grow()
        {
            if (stage < maxStage)
                stage++;
            UpdateRectangle();
        }

        public void UpdateRectangle()
        {
            switch (plantType)
            {
                case "weed":
                    textureRectangle = new Rectangle(0, 0, Tile.tileSize, Tile.tileSize);
                    break;
                case "tomato":
                    textureRectangle = tomatoAssignments[stage];
                    break;
            }
        }
    }
}
