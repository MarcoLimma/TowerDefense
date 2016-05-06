using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Lib.Objects
{
    class TestLevel
    {
        public int[,] map;

        public TestLevel(int width, int height)
        {
            map = GenerateMap(width, height);
        }

        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }

        private List<Texture2D> tileTextures = new List<Texture2D>();

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(texture, new Rectangle(
                        x * 64, y * 64, 64, 64), Color.White);
                }
            }
        }

        public int[,] GenerateMap(int width, int height)
        {
            int[,] map =  new int[height,width];

            int origin = new Random(Guid.NewGuid().GetHashCode()).Next(2, height - 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y == origin && x == 0)
                    {
                        map[y, x] = 1;
                    }
                    else
                    {
                        if (x > 0 && y > 0 && map[y, x-1] == 1 && map[y -1, x] != 1 && map[y + 1, x] != 1)
                        {
                            int index = new Random(Guid.NewGuid().GetHashCode()).Next(0, 3);

                            switch (index)
                            {
                                case 0:
                                    map[y, x] = 1;
                                    break;
                                case 1:
                                    map[y-1, x] = 1;
                                    break;
                                case 2:
                                    if(x < height - 1)
                                    map[y + 1, x ] = 1;
                                    break;
                              
                            }

                            map[y, x] = 1;
                        }
                        else
                        {
                            map[y, x] = 0;
                        }
                       
                    }
                   
                }
            }

            return map;
        }

    }
}
