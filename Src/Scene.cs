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
    abstract public class Scene
    {
        protected List<iActor> lstActors;
        protected Rectangle screen;
        protected Game game;
        protected Point mousePos;

        protected MouseState oldMouseState;
        protected MouseState newMouseState;

        public Scene(Game pGame)
        {
            game = pGame;
            lstActors = new List<iActor>();
            screen = game.Window.ClientBounds;
        }

        public virtual void Initialize()
        {
            Debug.WriteLine("New scene create");

            oldMouseState = Mouse.GetState();

            for (int a = lstActors.Count - 1; a >= 0; a--)
            {
                iActor actor;
                if (lstActors.Count > 0)
                {
                    actor = lstActors[a];
                    actor.Initialize();
                }
            }

        }

        protected void AddToListActor(iActor actor)
        {
            lstActors.Add(actor);
        }

        public void UnLoad()
        {
            lstActors.RemoveAll(item => item.toRemove);
        }

        protected void isHover(Point mousePos)
        {
            for (int b = 0; b <= lstActors.Count - 1; b++)
            {
                iActor actors = lstActors[b];
                if (actors.BoundingBox.Contains(mousePos))
                {
                    actors.isHover = true;
                }
                else
                {
                    actors.isHover = false;
                }
            }
        }

        public void isPressed(MouseState pOldMouseState, MouseState pNewMouseState, bool pContinue = false, bool pIsReleased = false, string pTypeButton = "left")
        {
            for (int b = 0; b <= lstActors.Count - 1; b++)
            {
                iActor actors = lstActors[b];
                if (actors.isHover)
                {
                    if (pTypeButton == "left")
                    {
                        if (pIsReleased == false)
                        {
                            if (pContinue == true)
                            {
                                if (pNewMouseState.LeftButton == ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                            else
                            {
                                if (pNewMouseState.LeftButton == ButtonState.Pressed && pOldMouseState.LeftButton != ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                        }
                        else
                        {
                            if (pNewMouseState.LeftButton == ButtonState.Released && pOldMouseState.LeftButton != ButtonState.Released)
                            {
                                actors.isPressed = true;
                            }
                            else
                            {
                                actors.isPressed = false;
                            }
                        }
                    }
                    else if (pTypeButton == "right")
                    {
                        if (pIsReleased == false)
                        {
                            if (pContinue == true)
                            {
                                if (pNewMouseState.RightButton == ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                            else
                            {
                                if (pNewMouseState.RightButton == ButtonState.Pressed && pOldMouseState.RightButton != ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                        }
                        else
                        {
                            if (pNewMouseState.RightButton == ButtonState.Released && pOldMouseState.RightButton != ButtonState.Released)
                            {
                                actors.isPressed = true;
                            }
                            else
                            {
                                actors.isPressed = false;
                            }
                        }
                    }
                    else if (pTypeButton == "middle")
                    {
                        if (pIsReleased == false)
                        {
                            if (pContinue == true)
                            {
                                if (pNewMouseState.MiddleButton == ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                            else
                            {
                                if (pNewMouseState.MiddleButton == ButtonState.Pressed && pOldMouseState.MiddleButton != ButtonState.Pressed)
                                {
                                    actors.isPressed = true;
                                }
                                else
                                {
                                    actors.isPressed = false;
                                }
                            }
                        }
                        else
                        {
                            if (pNewMouseState.MiddleButton == ButtonState.Released && pOldMouseState.MiddleButton != ButtonState.Released)
                            {
                                actors.isPressed = true;
                            }
                            else
                            {
                                actors.isPressed = false;
                            }
                        }
                    }
                    else
                    {
                        actors.isPressed = false;
                    }
                }
            }
            
        }

        public virtual void Update()
        {
            newMouseState = Mouse.GetState();

            mousePos = Mouse.GetState().Position;

            isHover(mousePos);
            isPressed(oldMouseState, newMouseState, true, false);

            for (int a = lstActors.Count - 1; a >= 0; a--)
            {
                iActor actor;
                if (lstActors.Count > 0)
                {
                    actor = lstActors[a];
                    if (actor.bisUpdate)
                    {
                        actor.Update();
                        if (actor is Ennemy) 
                        {
                            foreach (iActor actor2 in lstActors)
                            {
                                if (actor2 is Missile)
                                {
                                    actor.CollideWith(actor2);
                                }
                            }
                        }
                    }
                }
            }

            oldMouseState = newMouseState;
        }

        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            for (int a = lstActors.Count - 1; a >= 0; a--)
            {
                iActor actor;
                if (lstActors.Count > 0)
                {
                    actor = lstActors[a];
                    if (actor.bisDraw)
                    {
                        if (actor is Missile)
                        {

                        }
                        else
                        {
                            actor.Draw(pSpriteBatch);
                        }
                    }
                }
            }

            foreach (iActor actor in lstActors)
            {
                if (actor is Missile)
                {
                    actor.Draw(pSpriteBatch);
                }
            }
        }
    }
}
