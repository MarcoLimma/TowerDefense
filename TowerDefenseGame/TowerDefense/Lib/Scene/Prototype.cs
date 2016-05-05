using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TowerDefense.Lib.Objects;

namespace TowerDefense.Lib.Scene
{
    class Prototype : Scene
    {
        private bool click = false;

        private Rectangle playButton = new Rectangle(290, 400, 220, 64);

        MouseState mouseState;

        List<GameObject> coisas;

        public MouseState MouseLastState { get; private set; }

        public Prototype(Game game)
        {
            Game = game;
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            mouseState = Mouse.GetState();

            coisas = new List<GameObject>();
        }


        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && MouseLastState.LeftButton == ButtonState.Released)
            {
                click = true;
            }
            
            MouseLastState = mouseState;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (click)
            {
                coisas.Add(new SimpleTower() { Position = new Vector2(mouseState.X, mouseState.Y) });

                click = false;
            }

            foreach (var a in coisas)
            {
                Range aa = new Range();
                a.Draw(spriteBatch);
                (a as SimpleTower).Attack(aa, coisas);
                aa.Draw(spriteBatch, a);
            }

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

