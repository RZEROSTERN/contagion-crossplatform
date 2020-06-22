using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Contagion_CrossPlatform
{
    class Bullet : GameObject
    {
        FireCharacter owner;
        int destroyTimer;
        bool specialBullet = false;
        ContentManager content;

        const int maxTimer = 180;
        const float speed = 8f;

        private Rectangle rectangle;

        public bool SpecialBullet
        {
            get { return specialBullet; }
            set { specialBullet = value; }
        }

        public Bullet(bool isSpecial = false)
        {
            active = false;
            SpecialBullet = isSpecial;
        }

        public override void Load(ContentManager content)
        {
            this.content = content;

            if (SpecialBullet == true)
                image = TextureLoader.Load("Misc\\Bullets\\plasmabullet", this.content);
            else
                image = TextureLoader.Load("Misc\\Bullets\\bullet", this.content);

            base.Load(this.content);
        }
        public override void Update(GameTime gameTime)
        {
            if (active == false)
                return;

            if(specialBullet == true)
                image = TextureLoader.Load("Misc\\Bullets\\plasmabullet", this.content);
            else
                image = TextureLoader.Load("Misc\\Bullets\\bullet", this.content);

            position += direction * speed;

            rectangle = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);

            destroyTimer--;

            if (destroyTimer <= 0 && active == true)
                Destroy();

            base.Update(gameTime);
        }

        public void Destroy()
        {
            active = false;
        }

        public void Fire(FireCharacter inputOwner, Vector2 inputPosition, Vector2 inputDirection, bool hasSpecialAmmo)
        {
            SpecialBullet = hasSpecialAmmo;
            owner = inputOwner;
            position = inputPosition;
            direction = inputDirection;
            active = true;
            destroyTimer = maxTimer;
        }

        public void Collision(Map map, Enemy enemy = null)
        {
            foreach(Tiles tile in map.CollisionTiles)
            {
                if ((rectangle.TouchLeftOf(tile.Rectangle) || rectangle.TouchRightOf(tile.Rectangle)) && (tile.Id != 3 && tile.Id != 4))
                {
                    Destroy();
                    break;
                }
            }

            if(enemy != null)
            {
                if(enemy.active == true)
                {
                    if (rectangle.TouchLeftOf(enemy.BoundingBox) || rectangle.TouchRightOf(enemy.BoundingBox))
                    {
                        enemy.Destroy();
                        GameState.score += 100;
                        Destroy();
                    }
                }
            }
        }
    }
}
