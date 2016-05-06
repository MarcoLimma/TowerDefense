using TowerDefense.Lib.Graphics;
using TowerDefense.Lib.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TowerDefense.Lib.Objects;
using Microsoft.Xna.Framework.Content;

namespace TowerDefense.Lib.Scene
{
    class Prototype : Scene
    {
        private bool click = false;

        private Rectangle playButton = new Rectangle(290, 400, 220, 64);

        MouseState mouseState;

        List<GameObject> coisas;

        Tile[,] map;

        TestLevel level1 = new TestLevel(30, 17);

        public MouseState MouseLastState { get; private set; }

        public Prototype(Game game)
        {
            Game = game;

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            mouseState = Mouse.GetState();

            coisas = new List<GameObject>();

        }

        public override void Load()
        {
            Texture2D grass = GameGraphics.Grama;
            Texture2D path = GameGraphics.Terra;

            level1.AddTexture(grass);
            level1.AddTexture(path);

        }

        public override void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && MouseLastState.LeftButton == ButtonState.Released)
            {
                click = true;
            }


            if (click)
            {
                coisas.Add(new SimpleTower() { Position = InputManager.MousePosition });

                click = false;
            }


            MouseLastState = mouseState;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            level1.Draw(spriteBatch);
            

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

