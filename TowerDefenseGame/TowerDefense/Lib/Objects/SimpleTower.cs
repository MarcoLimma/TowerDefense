using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TowerDefense.Lib.Graphics;

namespace TowerDefense.Lib.Objects
{
    class SimpleTower : GameObject
    {


        float scale = 0.1f;
        Texture2D tower = GameGraphics.SimpleTower;
        Vector2 center;


        public SimpleTower()
        {
        }

        public override void Draw(SpriteBatch batch)
        {
            center = new Vector2()
            {
                X = (tower.Width / 2),
                Y = (tower.Height / 2)
            };

            batch.Draw(tower, new Vector2(this.Position.X, this.Position.Y), null, Color.White, 0f, center, scale, SpriteEffects.None, 0f);
        }

        public void Attack(Range range, List<GameObject> gameObjects)
        {
            List<GameObject> gos = new List<GameObject>();
            gos.AddRange(gameObjects);
            gos.Remove(this);

            foreach (var go in gos)
            {
                if (GetDistance(this.Position, go.Position) < (range.AttackRange * 100))
                {
                    this.coisa();
                }
            }


        }

        private double GetDistance(Vector2 p1, Vector2 p2)
        {
            double aaa = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            return aaa;
        }

        public void coisa()
        {
            this.scale -= 0.001f; 
        }

    }
}
