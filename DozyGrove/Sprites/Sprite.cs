using DozyGrove.Models;
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
        public Texture2D texture { get; set; }
        public Rectangle textureRectangle { get; set; }
        public bool hasTextureRectangle { get; set; }

        protected bool transitioning = false;
        protected Vector2 transitionDirection { get; set; }
        protected float transitionDuration { get; set; }
        protected float currentTransitionDuration = 0f;
        protected Vector2 offset = Vector2.Zero;

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
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (transitioning)
            {
                currentTransitionDuration += t;
                if (currentTransitionDuration >= transitionDuration)
                {
                    // Resetting transition params
                    currentTransitionDuration = 0f;
                    transitioning = false;
                    offset = Vector2.Zero;
                }
                else
                {
                    // -ve due to the entity being in the new tile but looking like they are slowly moving towards it
                    offset = -transitionDirection * Tile.tileSize * (transitionDuration - currentTransitionDuration) / transitionDuration;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!hasTextureRectangle)
                spriteBatch.Draw(texture, position + offset, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, position, textureRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void SmoothTransition(Vector2 direction, float duration)
        {
            transitioning = true;
            transitionDirection = direction;
            transitionDuration = duration;
        }
    }
}
