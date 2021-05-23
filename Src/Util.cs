using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Diamss_shooter
{
    public static class Util
    {
        public static bool isMouseButtonPressed(MouseState oldMouseState, MouseState newMouseState)
        {
            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isKBButtonPressed(KeyboardState oldKBState, KeyboardState newKBState, Keys pKey)
        {
            if (newKBState.IsKeyDown(pKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
