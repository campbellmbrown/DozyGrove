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
        private float movementDelay { get; set; }
        private float currentMovementDelay { get; set; }
        private bool holdingDownInteract = false;

        public InputManager()
        {
            movementDelay = 0.2f;
            currentMovementDelay = 0f;
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            CheckSingleKeyPress(keyboardState);
            CheckHeldKeyPress(keyboardState, t);
            CheckHover();
        }

        private void CheckHover()
        {
            Game1.locationManager.CheckHover();
        }

        private void CheckInteract()
        {
            Game1.locationManager.CheckInteract();
        }

        private void CheckSingleKeyPress(KeyboardState keyboardState)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!holdingDownInteract)
                {
                    Game1.locationManager.CheckInteract();
                }
                holdingDownInteract = true;
            }
            else holdingDownInteract = false;
        }

        private void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            if (currentMovementDelay > 0) currentMovementDelay -= t;

            int vertical = 0;
            int horizontal = 0;
            if (currentMovementDelay <= 0) {
                if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) vertical -= 1;
                if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)) vertical += 1;
                if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left)) horizontal -= 1;
                if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right)) horizontal += 1;

                if ((vertical != 0) || (horizontal != 0))
                {
                    ResetMovementDelays();
                    Game1.locationManager.MovePlayer(vertical, horizontal);
                }
            }
        }

        private void ResetMovementDelays(float multiplier = 1f)
        {
            currentMovementDelay = multiplier * movementDelay;
        }
    }
}
