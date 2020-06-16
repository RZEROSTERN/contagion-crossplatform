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
        protected int id;
        protected bool active = true;
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        private static ContentManager content;

        public static ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(active)
                spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Misc\\Tiles\\Tile" + i);
            id = i;
            this.Rectangle = newRectangle;
        }
    }
}
