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
        public bool hasTextureRectangle { get; set; }

        public Sprite(Texture2D texture, Rectangle textureRectangle)
        {
            this.texture = texture;
            this.textureRectangle = textureRectangle;
            hasTextureRectangle = true;
        }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            hasTextureRectangle = false;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!hasTextureRectangle)
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, position, textureRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
