using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contagion_CrossPlatform
{
    class Hero
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private Rectangle rectangle;

        private bool hasJumped = false;

        public static int lives = 3;

        public Vector2 Position
        {
            get { return position; }
        }

        public Hero() { }

        public void Load(ContentManager contentManager)
        {
            texture = TextureLoader.Load("Characters\\playertest", contentManager);
            position.X = 200;
            position.Y = 350;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            CheckInput(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;
        }

        private void CheckInput(GameTime gameTime)
        {
            Console.WriteLine(Keyboard.GetState().IsKeyDown(Keys.D));

            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else
                velocity.X = 0f;

            if(Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.TouchLeftOf(newRectangle))
                position.X = newRectangle.X - rectangle.Width - 2;

            if (rectangle.TouchRightOf(newRectangle))
                position.X = newRectangle.X + newRectangle.Width + 2;

            if (rectangle.TouchBottomOf(newRectangle))
                velocity.Y = 1f;

            if (position.X < 0)
                position.X = 0;

            if (position.X > xOffset - rectangle.Width)
                position.X = xOffset - rectangle.Width;

            if (position.Y < 0)
                velocity.Y = 1f;

            if (position.Y > yOffset - rectangle.Height)
                position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
