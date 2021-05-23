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
    class PlayerShip : Sprite
    {
        public int HP { get; set; }
        public int Speed { get; set; }

        private KeyboardState oldKBState;
        private KeyboardState newKBState;

        public PlayerShip(Texture2D pTexture, Vector2 pPosition, int pHP, Game pGame) : base(pTexture, pPosition, pGame)
        {
            HP = pHP;
        }

        public override void Initialize()
        {
            base.Initialize();

            oldKBState = Keyboard.GetState();
            Speed = 5;
        }

        public override void Update()
        {
            base.Update();
            newKBState = Keyboard.GetState();

            if (Util.isKBButtonPressed(oldKBState, newKBState, Keys.Q))
            {
                Position += new Vector2(-Speed, 0);
            }
            if (Util.isKBButtonPressed(oldKBState, newKBState, Keys.Z))
            {
                Position += new Vector2(0, -Speed);
            }
            if (Util.isKBButtonPressed(oldKBState, newKBState, Keys.D))
            {
                Position += new Vector2(Speed, 0);
            }
            if (Util.isKBButtonPressed(oldKBState, newKBState, Keys.S))
            {
                Position += new Vector2(0, Speed);
            }

            if (Position.X - CurrentTexture.Height < screen.X)
            {
                Position = new Vector2(screen.X + CurrentTexture.Height, Position.Y);
            }
            if (Position.Y < screen.X)
            {
                Position = new Vector2(Position.X, screen.Y);
            }
            if (Position.X > screen.Width)
            {
                Position = new Vector2(screen.Width, Position.Y);
            }
            if (Position.Y + CurrentTexture.Width > screen.Height)
            {
                Position = new Vector2(Position.X, screen.Height - CurrentTexture.Width);
            }

            oldKBState = newKBState;
        }
    }
}
