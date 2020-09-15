using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Managers
{
    public class InputManager
    {
        private bool holdingUp { get; set; }
        private bool holdingDown { get; set; }
        private bool holdingLeft { get; set; }
        private bool holdingRight { get; set; }

        public InputManager()
        {
            holdingUp = false;
            holdingDown = false;
            holdingLeft = false;
            holdingRight = false;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSingleKeyPress(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
        }

        private void CheckSingleKeyPress(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.W))
            {
                if (!holdingUp)
                    Game1.locationManager.MoveUp();
                holdingUp = true;
            }
            else holdingUp = false;

            if (keyboardState.IsKeyDown(Keys.S))
            {
                if (!holdingDown)
                    Game1.locationManager.MoveDown();
                holdingDown = true;
            }
            else holdingDown = false;

            if (keyboardState.IsKeyDown(Keys.A))
            {
                if (!holdingLeft)
                    Game1.locationManager.MoveLeft();
                holdingLeft = true;
            }
            else holdingLeft = false;

            if (keyboardState.IsKeyDown(Keys.D))
            {
                if (!holdingRight)
                    Game1.locationManager.MoveRight();
                holdingRight = true;
            }
            else holdingRight = false;
        }

        public void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {

        }
    }
}
