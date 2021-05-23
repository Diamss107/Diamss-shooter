using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Diamss_shooter
{
    public delegate void AddToList(iActor actor);
    public delegate void OnClick();

    public class Sprite : iActor
    {
        // Draw variable
        public Texture2D Texture {get; set;}
        public Vector2 Position {get; set;}
        public Color Color {get; set;}
        public float Rotation {get; set;}
        public Vector2 Origin {get; set;}
        public Vector2 Scale {get; set;}
        
        //

        // Miscellaneous
        public List<Texture2D> lstTextures {get; set;}
        public Texture2D CurrentTexture {get; set;}
        public Rectangle BoundingBox {get; set;}
        private bool bIsUpdate;
        private bool bIsDraw;
        public OnClick OnClick { get; set; }
        private bool lstTexture;
        public bool toRemove { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool bisDraw { get; set; }
        public bool bisUpdate { get; set; }
        protected Rectangle screen;
        protected Game game;

        public Point GetCenter {
            get
            {
                return new Point(CurrentTexture.Width/2, CurrentTexture.Height/2);
            }

            private set {}
        }

        //

        // Hover and press
        public bool bIsHover {get; set;}
        public bool isHover {get; set;}
        public bool bIsPressed {get; set;}
        public bool isPressed {get; set;}
        //

        public Sprite(Texture2D pTexture, Vector2 pPosition, Game pGame)
        {
            Texture = pTexture;
            CurrentTexture = Texture;
            Position = pPosition;
            lstTexture = false;
            Scale = new Vector2(1, 1);
            Color = Color.White;
            bisDraw = true;
            bisUpdate = true;
            game = pGame;
            if (CurrentTexture != null)
            {
                Width = CurrentTexture.Width;
                Height = CurrentTexture.Height;
            }
        }

        public Sprite(List<Texture2D> plstTexture, Vector2 pPosition, Game pGame)
        {
            lstTextures = plstTexture;
            CurrentTexture = lstTextures[0];
            Position = pPosition;
            lstTexture = true;
            Scale = new Vector2(1, 1);
            Color = Color.White;
            bisDraw = true;
            bisUpdate = true;
            game = pGame;
            if (CurrentTexture != null)
            {
                Width = CurrentTexture.Width;
                Height = CurrentTexture.Height;
            }
        }

        public void SwitchUpdate()
        {   
            bIsUpdate = !bIsUpdate;
        }
        public void SwitchDraw()
        {
            bIsDraw = !bIsDraw;
        }

        public bool CollideWith(iActor actor)
        {
            if (BoundingBox.Intersects(actor.BoundingBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Initialize()
        {
            screen = game.Window.ClientBounds; 
        }

        public virtual void Update()
        {
            if (CurrentTexture != null)
            {
                if (Rotation == 0)
                {
                    BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(CurrentTexture.Width * Scale.X), (int)(CurrentTexture.Height * Scale.Y));
                }
                else if (Rotation == 90)
                {
                    BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(-CurrentTexture.Height * Scale.X), (int)(CurrentTexture.Width * Scale.Y));
                }
                else if (Rotation == -90)
                {
                    BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)(CurrentTexture.Height * Scale.X), (int)(-CurrentTexture.Width * Scale.Y));
                }
                Width = (int)(CurrentTexture.Width * Scale.X);
                Height = (int)(CurrentTexture.Height * Scale.Y);
            }

            if (isHover && lstTexture)
            {
                CurrentTexture = lstTextures[1];
            }
            
            if (isPressed && lstTexture)
            {
                CurrentTexture = lstTextures[2];
            }
            
            if (isHover == false && isPressed == false && lstTexture)
            {
                CurrentTexture = lstTextures[0];
            }

            if (isPressed && OnClick != null)
            {
                OnClick();
            }
        }
        
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            if (CurrentTexture != null)
            {
                pSpriteBatch.Draw(CurrentTexture, Position, null, Color, MathHelper.ToRadians(Rotation), Origin, Scale, SpriteEffects.None, 1);
            }
            else
            {
                Debug.WriteLine("Texture is not instancied");
            }
        }
    }
}