using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefense.Lib.Graphics;

namespace TowerDefense.Lib.Objects
{
    class Range : GameObject
    {
        public float AttackRange = 3;

        public Range()
        {

        }

        public override void Draw(SpriteBatch batch)
        {

        }

        public void Draw(SpriteBatch batch, GameObject gameObject)
        {
         
            Texture2D range = GameGraphics.Range;
            Vector2 center = new Vector2()
            {
                X = (range.Width / 2),
                Y = (range.Height / 2)
            };

            batch.Draw(range, new Vector2(gameObject.Position.X, gameObject.Position.Y), null, Color.White, 0f, center, AttackRange, SpriteEffects.None, 0f);
        }
    }
}
