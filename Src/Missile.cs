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
    public class Missile : Sprite
    {
        public int nbDamage { get; set; }

        public Missile(Texture2D pTexture, Vector2 pPosition, int pnbDamage, Game pGame) : base(pTexture, pPosition, pGame)
        {
            nbDamage = pnbDamage;
        }

        public override void Update()
        {
            base.Update();

            Position += new Vector2(20, 0);
        }
    }
}
