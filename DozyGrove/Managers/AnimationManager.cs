using DozyGrove.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Managers
{
    public class AnimationManager
    {
        private int frameCount { get; set; }
        private float frameSpeed { get; set; }
        private int currentFrame { get; set; }
        private float timer { get; set; }
        private Animation animation;

        public AnimationManager(Animation animation)
        {
            this.animation = animation;
            this.frameCount = animation.frameCount;
            this.frameSpeed = animation.frameSpeed;
            currentFrame = 0;
            timer = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle rectangle = new Rectangle(currentFrame * animation.frameWidth, 0, animation.frameWidth, animation.frameHeight);
            spriteBatch.Draw(animation.texture, position, rectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Reset() { currentFrame = 0; }

        public void Play(Animation animation)
        {
            if (this.animation != animation)
            {
                this.animation = animation;
                frameCount = animation.frameCount;
                frameSpeed = animation.frameSpeed;
                currentFrame = 0;
                timer = 0f;
            }
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > frameSpeed)
            {
                timer -= frameSpeed;
                currentFrame++;
                if (currentFrame >= frameCount)
                {
                    currentFrame = 0;
                }
            }
        }
    }
}
