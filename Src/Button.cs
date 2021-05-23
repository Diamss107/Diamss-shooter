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
    class Button : Sprite
    {
        public string sText { get; set; }
        private Text text;
        private SpriteFont font;

        private AddToList addToList;

        public Button(Texture2D pTexture, Vector2 pPosition, Game pGame, OnClick pOnClick = null, string pText = "", SpriteFont pFont = null, AddToList pAddToList = null) : base(pTexture, pPosition, pGame)
        {
            sText = pText;
            font = pFont;
            addToList = pAddToList;
            OnClick = pOnClick;
            if (font != null & sText != null)
            {
                text = new Text(sText, font, Position, game);
                text.Position = new Vector2(Position.X + CurrentTexture.Width / 2, Position.Y + CurrentTexture.Height / 2);
                if (addToList != null)
                {
                    addToList(text);
                }
            }
        }

        public Button(List<Texture2D> plstTextures, Vector2 pPosition, Game pGame, OnClick pOnClick = null, string pText = "", SpriteFont pFont = null, AddToList pAddToList = null) : base(plstTextures, pPosition, pGame)
        {
            sText = pText;
            font = pFont;
            addToList = pAddToList;
            OnClick = pOnClick;
            if (font != null & sText != null)
            {
                text = new Text(sText, font, Position, game);
                text.Position = new Vector2(Position.X + CurrentTexture.Width / 2, Position.Y + CurrentTexture.Height / 2);
                if (addToList != null)
                {
                    addToList(text);
                }
            }
        }

        public override void Update()
        {
            base.Update();

            if (text != null)
            {
                text.Origin = text.Size / 2;
            }
        }
    }
}
