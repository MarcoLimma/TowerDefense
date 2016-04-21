using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.Lib.Scene
{
    class PrototypeTower : Scene
    {
            private bool play = false;

            private Rectangle playButton = new Rectangle(290, 400, 220, 64);
            public PrototypeTower(Game game)
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
                play = playButton.Contains(InputManager.MousePositionPoint);
            }

            public override void Draw(GameTime gameTime)
            {
                spriteBatch.Begin();
                if (play)
                {
                    spriteBatch.Draw(GameGraphics.Menu2, Game.GraphicsDevice.Viewport.Bounds, Color.White);
                }
                else
                {
                    spriteBatch.Draw(GameGraphics.Menu1, Game.GraphicsDevice.Viewport.Bounds, Color.White);
                }

                //mainMenu.Draw(spriteBatch);

                //spriteBatch.Draw(GameGraphics.SelectedItemTexture, playButton, Color.White);

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

