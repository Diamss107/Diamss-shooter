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
    public static class GameState
    {
        public static Scene CurrentScene {get; set;}
        public static Game Game {get; set;}

        public enum SceneType
        {
            Home,
            Menu,
            Game,
            MapEditor
        }

        public static void ChangeScene(SceneType pSceneType)
        {
            if (Game != null)
            {
                if (CurrentScene != null)
                {
                    //CurrentScene.UnLoad();
                    CurrentScene = null;
                }

                switch (pSceneType)
                {
                    case SceneType.Home:
                        CurrentScene = new SceneHome(Game);
                        break;
                    case SceneType.Menu:
                        break;
                    case SceneType.Game:
                        CurrentScene = new SceneGame(Game);
                        break;
                    case SceneType.MapEditor:
                        break;
                    default:
                        Debug.WriteLine("SCENE NOT EXISTING");
                        break;
                }

                CurrentScene.Initialize();
            }
        }
    }
}
