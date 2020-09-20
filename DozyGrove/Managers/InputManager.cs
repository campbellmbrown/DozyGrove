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
        private bool holdingDownUp { get; set; }
        private bool holdingDownDown { get; set; }
        private bool holdingDownLeft { get; set; }
        private bool holdingDownRight { get; set; }

        public InputManager()
        {
            movementDelay = 0.2f;
            currentMovementDelay = 0f;
            holdingDownUp = false;
            holdingDownDown = false;
            holdingDownLeft = false;
            holdingDownRight = false;
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
        //    if (keyboardState.IsKeyDown(Keys.W))
        //    {
        //        if (!holdingDownUp)
        //        {
        //            Game1.sounds["player_move"].Play();
        //            Game1.locationManager.MoveUp();
        //            ResetMovementDelays();
        //        }
        //        holdingDownUp = true;
        //    }
        //    else holdingDownUp = false;

        //    if (keyboardState.IsKeyDown(Keys.S))
        //    {
        //        if (!holdingDownDown)
        //        {
        //            Game1.locationManager.MoveDown();
        //            ResetMovementDelays();
        //        }
        //        holdingDownDown = true;
        //    }
        //    else holdingDownDown = false;

        //    if (keyboardState.IsKeyDown(Keys.A))
        //    {
        //        if (!holdingDownLeft)
        //        {
        //            Game1.locationManager.MoveLeft();
        //            ResetMovementDelays();
        //        }
        //        holdingDownLeft = true;
        //    }
        //    else holdingDownLeft = false;

        //    if (keyboardState.IsKeyDown(Keys.D))
        //    {
        //        if (!holdingDownRight)
        //        {
        //            Game1.locationManager.MoveRight();
        //            ResetMovementDelays();
        //        }
        //        holdingDownRight = true;
        //    }
        //    else holdingDownRight = false;
        }

        private void CheckHeldKeyPress(KeyboardState keyboardState, float t)
        {
            if (currentMovementDelay > 0) currentMovementDelay -= t;

            int vertical = 0;
            int horizontal = 0;
            if (currentMovementDelay <= 0) {
                if (keyboardState.IsKeyDown(Keys.W)) vertical -= 1;
                if (keyboardState.IsKeyDown(Keys.S)) vertical += 1;
                if (keyboardState.IsKeyDown(Keys.A)) horizontal -= 1;
                if (keyboardState.IsKeyDown(Keys.D)) horizontal += 1;

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
