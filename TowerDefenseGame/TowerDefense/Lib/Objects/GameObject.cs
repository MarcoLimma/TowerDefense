using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.Lib.Objects
{
    public abstract class GameObject
    {
        public int UniqueObjectId { get; set; }
        public Vector2 Position { get; set; }

        public abstract void Draw(SpriteBatch batch);
    }
}
