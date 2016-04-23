using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TowerDefense.Lib.Objects;

namespace TowerDefense.Lib.Scene
{
    class SussumuScene : Scene
    {
        List<GameObject> gameObjects;

        public SussumuScene(Game game)
        {
            Game = game;
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            gameObjects = new List<GameObject>();
            gameObjects.Add(new SimpleTower());
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
