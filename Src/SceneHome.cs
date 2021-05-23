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
    class SceneHome : Scene
    {
        private Button buttonStart;
        private Sprite Background;
        private Sprite BackgroundStars;
        private Sprite PlayerShip1Blue;

        public void OnClickStart()
        {
            GameState.ChangeScene(GameState.SceneType.Game);
        }

        public SceneHome(Game pGame) : base(pGame)
        {
            
        }

        public override void Initialize()
        {
            Debug.WriteLine("New home scene create");


            float x, y;
            x = ((screen.Width / 2) - AssetManager.lstButtonStart[0].Width / 2);
            y = ((screen.Height / 2) - AssetManager.lstButtonStart[0].Height / 2);

            buttonStart = new Button(AssetManager.lstButtonStart, new Vector2(x, y), game, OnClickStart, "Play", AssetManager.DefaultFont, AddToListActor);
            lstActors.Add(buttonStart);

            x = (screen.Width / 2) - screen.Width / 3;
            y = screen.Height / 2 - AssetManager.PlayerShip1Blue.Width / 2;

            PlayerShip1Blue = new Sprite(AssetManager.PlayerShip1Blue, new Vector2(x, y), game);
            PlayerShip1Blue.Rotation = 90;
            lstActors.Add(PlayerShip1Blue);

            BackgroundStars = new Sprite(AssetManager.BackgroundStars, Vector2.Zero, game);
            BackgroundStars.Scale = new Vector2(2, 2);
            lstActors.Add(BackgroundStars);

            Background = new Sprite(AssetManager.Background, Vector2.Zero, game);
            Background.Scale = new Vector2(1.4f, 1.4f);
            lstActors.Add(Background);

            base.Initialize();

        }

    }
}
