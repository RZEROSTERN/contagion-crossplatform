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
    class Hero : FireCharacter
    {
        private Texture2D texture;
        private Vector2 velocity;
        private Rectangle rectangle;

        private bool hasJumped = false;

        public static int lives = 3;
        public static int specialAmmo = 0;
        public static bool hasSpecialAmmo = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Hero() { }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager contentManager)
        {
            texture = TextureLoader.Load("Characters\\playertest", contentManager);
            position.X = 200;
            position.Y = 350;

            base.Load(contentManager);
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            CheckInput(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            base.Update(gameTime);
        }

        private void CheckInput(GameTime gameTime)
        {
            if (Input.IsKeyDown(Keys.D) == true)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                direction.X = 1;
            }
            else if (Input.IsKeyDown(Keys.A) == true)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                direction.X = -1;
            }
            else
                velocity.X = 0f;

            if(Input.IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }

            if (Input.KeyPressed(Keys.J))
            {
                Console.WriteLine(Position.ToString());
                Fire();
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

        public void CollisionPowerUps(Rectangle newRectangle, int xOffset, int yOffset)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            base.Draw(spriteBatch);
        }
    }
}
