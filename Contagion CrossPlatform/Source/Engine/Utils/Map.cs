using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contagion_CrossPlatform
{
    class Map
    {
        public List<CollisionTiles> CollisionTiles { get; } = new List<CollisionTiles>();

        public int Width { get; private set; }

        public int Height { get; private set; }

        public void Generate(int[,] map, int size)
        {
            for(int x = 0; x < map.GetLength(1); x++)
                for(int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }

                    Width = (x + 1) * size;
                    Height = (y + 1) * size;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in CollisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
