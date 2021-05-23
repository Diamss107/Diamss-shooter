using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Diamss_shooter
{
    public class SceneGame : Scene
    {
        private Sprite Background;
        private Sprite Background2;
        private Sprite BackgroundStars;
        private Sprite BackgroundStars2;

        private PlayerShip PlayerShip1Blue;
        private Ennemy EnnemyTest1;

        private int BSWidth;
        private int BWidth;

        private new MouseState oldMouseState;
        private new MouseState newMouseState;

        private KeyboardState oldKBState;
        private KeyboardState newKBState;

        public SceneGame(Game pGame) : base(pGame)
        {
            BSWidth = 2048;
            BWidth = 5728;
        }

        public override void Initialize()
        {
            Debug.WriteLine("New game scene create");
            oldMouseState = Mouse.GetState();
            oldKBState = Keyboard.GetState();

            int x, y;
            x = (screen.Width / 2) - screen.Width / 3;
            y = screen.Height / 2 - AssetManager.PlayerShip1Blue.Width / 2;

            PlayerShip1Blue = new PlayerShip(AssetManager.PlayerShip1Blue, new Vector2(x, y), 100, game);
            PlayerShip1Blue.Rotation = 90;
            lstActors.Add(PlayerShip1Blue);

            x = screen.Width;
            y = screen.Height / 2;

            EnnemyTest1 = new Ennemy(AssetManager.EnemyBlack1, new Vector2(x, y), 100, game);
            EnnemyTest1.Rotation = 90;
            lstActors.Add(EnnemyTest1);

            // Background


            BackgroundStars = new Sprite(AssetManager.BackgroundStars, Vector2.Zero, game);
            BackgroundStars.Scale = new Vector2(2, 2);
            lstActors.Add(BackgroundStars);

            BackgroundStars2 = new Sprite(AssetManager.BackgroundStars, new Vector2(BSWidth, 0), game);
            BackgroundStars2.Scale = new Vector2(2, 2);
            lstActors.Add(BackgroundStars2);

            Background = new Sprite(AssetManager.Background, Vector2.Zero, game);
            Background.Scale = new Vector2(1.4f, 1.4f);
            lstActors.Add(Background);

            Background2 = new Sprite(AssetManager.Background, new Vector2(BWidth, 0), game);
            Background2.Scale = new Vector2(1.4f, 1.4f);
            lstActors.Add(Background2);

            base.Initialize();
        }

        public override void Update()
        {
            base.Update();

            newMouseState = Mouse.GetState();
            newKBState = Keyboard.GetState();

            BackgroundStars.Position -= new Vector2(16, 0);
            if (BackgroundStars.Position.X == -BSWidth)
            {

                BackgroundStars.Position = new Vector2(BSWidth, 0);

            }
            BackgroundStars2.Position -= new Vector2(16, 0);
            if (BackgroundStars2.Position.X == -BSWidth)
            {
                BackgroundStars2.Position = new Vector2(BSWidth, 0);
            }

            //

            Background.Position -= new Vector2(8, 0);
            if (Background.Position.X == -BWidth)
            {

                Background.Position = new Vector2(BWidth, 0);

            }
            Background2.Position -= new Vector2(8, 0);
            if (Background2.Position.X == -BWidth)
            {
                Background2.Position = new Vector2(BWidth, 0);
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (Util.isMouseButtonPressed(oldMouseState, newMouseState))
            {
                Missile laserBlue = new Missile(AssetManager.LaserBlue, new Vector2(PlayerShip1Blue.Position.X + PlayerShip1Blue.CurrentTexture.Height / 2, PlayerShip1Blue.Position.Y + PlayerShip1Blue.CurrentTexture.Width / 2 - AssetManager.LaserBlue.Width / 2), 10, game);
                laserBlue.Rotation = 90;
                lstActors.Add(laserBlue);
            }

            oldMouseState = newMouseState;
            oldKBState = newKBState;
        }

    }
}
