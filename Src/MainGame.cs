using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;

namespace Diamss_shooter
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Sprite mouseCursor;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.Title = "Diamss shooter";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ToggleFullScreen();

        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadContent(Content);

            mouseCursor = new Sprite(AssetManager.MouseCursor, new Vector2(100, 100), this);

            GameState.Game = this;
            GameState.ChangeScene(GameState.SceneType.Home);

        }

        protected override void Update(GameTime gameTime)
        {

            if (GameState.CurrentScene != null)
            {
                mouseCursor.Update();
                GameState.CurrentScene.Update();
            }

            mouseCursor.Position = Mouse.GetState().Position.ToVector2();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (GameState.CurrentScene != null)
            {
                GameState.CurrentScene.Draw(spriteBatch);
                mouseCursor.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
