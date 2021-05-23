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
    public class Text : Sprite
    {
        public string sText { get; set; }
        private SpriteFont font;
        public Vector2 Size { get; set; }

        public Text(string pText, SpriteFont pFont, Vector2 pPosition, Game pGame) : base((Texture2D)null, pPosition, pGame)
        {
            sText = pText;
            font = pFont;
            Scale = new Vector2(1, 1);
            Size = font.MeasureString(sText) * Scale;
        }

        public override void Initialize()
        {
            Color = Color.White;
        }

        public override void Update()
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            if (sText != null)
            {
                pSpriteBatch.DrawString(font, sText, Position, Color, Rotation, Origin, Scale, SpriteEffects.None, 1);
            }
            else
            {
                Debug.WriteLine("Text is not instancied");
            }
        }

    }
}
