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
    public static class AssetManager
    {
        public static SpriteFont DefaultFont { get; set; }

        public static List<Texture2D> lstButtonStart { get; set; }
        public static Texture2D Background { get; set; }
        public static Texture2D BackgroundStars { get; set; }
        public static Texture2D MouseCursor { get; set; }
        public static Texture2D PlayerShip1Blue { get; set; }
        public static Texture2D LaserBlue { get; set; }
        public static Texture2D EnemyBlack1 { get; set; }

        public static void LoadContent(ContentManager pContent)
        {
            DefaultFont = pContent.Load<SpriteFont>("DefaultFont");

            lstButtonStart = new List<Texture2D>();
            for (int s = 0; s < 3; s++)
            {
                Texture2D buttonStart = pContent.Load<Texture2D>("SceneHome\\blue_button0" + s);
                lstButtonStart.Add(buttonStart);
            }

            BackgroundStars = pContent.Load<Texture2D>("SceneHome\\background_stars");
            Background = pContent.Load<Texture2D>("SceneHome\\background");

            MouseCursor = pContent.Load<Texture2D>("cursor");

            PlayerShip1Blue = pContent.Load<Texture2D>("Game\\player_ship1_blue");
            LaserBlue = pContent.Load<Texture2D>("Game\\laserBlue");
            EnemyBlack1 = pContent.Load<Texture2D>("Game\\enemyBlack1");
        }
    }
}
