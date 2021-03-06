﻿using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.Lib.Scene
{
    public class MainMenuScene : Scene
    {
            public MainMenuScene(Game game)
            {
                Game = game;
                spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            }

            public override void MouseClick(MouseButton button)
            {
                if (button == MouseButton.Left)
                {
                    //switch (mainMenu.SelectedOption)
                    //{
                    //    case MainMenuFunction.NewGame:
                    //        Game.NewGame();
                    //        break;
                    //    case MainMenuFunction.LoadGame:
                    //        Game.StartTransition(GameState.LoadGame);
                    //        break;
                    //    case MainMenuFunction.Help:
                    //        Game.StartTransition(GameState.Help);
                    //        break;
                    //    case MainMenuFunction.Exit:
                    //        //Exit();
                    //        break;
                    //    case MainMenuFunction.GameStats:
                    //        Game.StartTransition(GameState.GameStatsHelp);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }

            public override void Update(GameTime gameTime)
            {
                
            }

            public override void Draw(GameTime gameTime)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(GameGraphics.MainMenu, Game.GraphicsDevice.Viewport.Bounds, Color.White);
                
                spriteBatch.End();
            }

            //public override void MouseDown(MouseButton button)
            //{
            //    if (play)
            //    {
            //        GameGraphics.SoundSelect.Play();
            //        Game.State = GameState.GameStarted;
            //    }
            //    base.MouseDown(button);
            //}

            //public override void Load()
            //{

            //}
        }
    }

