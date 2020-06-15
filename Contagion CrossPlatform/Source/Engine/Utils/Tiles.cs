using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contagion_CrossPlatform
{
    class Tiles
    {
        protected Texture2D texture;

        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;

        public static ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Misc\\Tiles\\Tile" + i);
            this.Rectangle = newRectangle;
        }
    }

    class PowerUpTiles : Tiles
    {
        private const string PATH = "Misc\\Tiles\\Tile";
        public PowerUpTiles(int powerup, Rectangle newRectangle)
        {
            string tile = PATH;

            switch(powerup)
            {
                case 3: tile = PATH + "3"; break;
                case 4: tile = PATH + "4"; break;
            }

            texture = Content.Load<Texture2D>(tile);
            this.Rectangle = newRectangle;
        }
    }
}
