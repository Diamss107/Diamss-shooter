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
    class Ennemy : Sprite
    {
        public int HP { get; set; }
        
        public Ennemy(Texture2D pTexture, Vector2 pPosition, int pHP, Game pGame) : base(pTexture, pPosition, pGame)
        {
            HP = pHP;
        }
    }
}
