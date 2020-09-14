using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Sprites
{
    public class Sprite
    {
        // public Animation animation;
        public Texture2D texture;
        public Rectangle textureRectangle;

        public Sprite(Texture2D texture, Rectangle textureRectangle)
        {
            this.texture = texture;
            this.textureRectangle = textureRectangle;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, textureRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
