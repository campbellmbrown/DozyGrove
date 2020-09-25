using DozyGrove.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Models
{
    public class Tile
    {
        public Sprite sprite { get; set; }
        public Sprite entity { get; set; }
        protected Vector2 position { get; set; }
        public Rectangle hoverRectangle { get; set; }
        public bool highlight { get; set; }
        public bool hasSprite { get { return sprite != null; } }
        public bool hasEntity { get { return entity != null; } }
        public static int tileSize = 10;

        public Tile(Vector2 position)
        {
            this.position = position;
            hoverRectangle = new Rectangle((int)position.X, (int)position.Y, tileSize, tileSize);
        }

        public void Update(GameTime gameTime)
        {
            if (hasSprite)
                sprite.Update(gameTime);
            if (hasEntity)
                entity.Update(gameTime);
        }

        public void DrawBottomLayer(SpriteBatch spriteBatch)
        {
            if (hasSprite)
                sprite.Draw(spriteBatch, position);
        }

        public void DrawMiddleLayer(SpriteBatch spriteBatch)
        {
            if (hasEntity)
                entity.Draw(spriteBatch, position);
        }

        public void DrawTopLayer(SpriteBatch spriteBatch)
        {
            if (highlight)
                spriteBatch.DrawRectangle(hoverRectangle, Color.White * 0.2f);
        }

        public void EntitySmoothTransition(Vector2 direction, float duration)
        {
            if (hasEntity)
                entity.SmoothTransition(direction, duration);
        }

        public void DailyUpdate()
        {
            if (hasSprite)
                sprite.DailyUpdate();
            if (hasEntity)
                entity.DailyUpdate();
        }
    }
}
