using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefense.Lib.Graphics;

namespace TowerDefense.Lib.Objects
{
    class SimpleTower : GameObject
    {
        public SimpleTower()
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(GameGraphics.SimpleTower, new Vector2(100, 100), null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
        }
    }
}
