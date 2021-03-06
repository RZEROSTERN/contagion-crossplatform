﻿using Microsoft.Xna.Framework;
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
    class Enemy : AIFireCharacter
    {
        private Texture2D texture;
        public Rectangle rectangle;
        private Vector2 velocity;
        private bool hasJumped = false;
        private bool goRight = true, goLeft = false, disabledFlipRight = false, disabledFlipLeft = false;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            texture = TextureLoader.Load("Characters\\enemytest", content);

            position.X = 750;
            position.Y = 350;

            base.Load(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (active == false)
                return;

            position += velocity;

            Move(gameTime);

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            base.Update(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            if(goRight == true && goLeft == false)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                direction.X = 1;
            }

            if(goLeft == true && goRight == false)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                direction.X = -1;
            }
        }

        public void Flip()
        {
            if(goRight == true && goLeft == false && hasJumped == false)
            {
                goRight = false;
                goLeft = true;
                disabledFlipLeft = true;
                disabledFlipRight = false;
            } 
            else if(goLeft == true && goRight == false && hasJumped == false)
            {
                goLeft = false;
                goRight = true;
                disabledFlipLeft = false;
                disabledFlipRight = true;
            }
        }

        public void Collision(Tiles tile, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(tile.Rectangle) && tile.Active == true)
            {
                rectangle.Y = tile.Rectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }

            if (rectangle.TouchLeftOf(tile.Rectangle) && tile.Active == true && disabledFlipLeft == false)
            {
                Flip();
            }


            if (rectangle.TouchRightOf(tile.Rectangle) && tile.Active == true && disabledFlipRight == false)
            {
                Flip();
            }

            if (rectangle.TouchBottomOf(tile.Rectangle) && tile.Active == true)
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

        public void CollisionWithHero(Hero hero)
        {
            if ((rectangle.TouchTopOf(hero.rectangle) || rectangle.TouchBottomOf(hero.rectangle)
                || rectangle.TouchLeftOf(hero.rectangle) || rectangle.TouchRightOf(hero.rectangle)) && active == true)
            {
                hero.Lives -= 1;
                Destroy();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(active == true)
                spriteBatch.Draw(texture, rectangle, Color.White);
            
            base.Draw(spriteBatch);
        }

        public void Destroy()
        {
            active = false;
        }
    }
}
