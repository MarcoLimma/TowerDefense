using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefense.Lib.Objects;

namespace TowerDefense.Lib.Scene
{
    internal class Tile : GameObject
    {

        float TileSize;

        public Tile(Vector2 _mapPosition, Texture2D _sprite, TileType _tileType)
        {
        }

        public override void Draw(SpriteBatch batch)
        {
        }

        

    }

    enum TileType
    {
        O,
        X
    }
}