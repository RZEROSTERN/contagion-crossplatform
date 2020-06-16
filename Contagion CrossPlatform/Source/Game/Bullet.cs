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
    public class Bullet : GameObject
    {
        FireCharacter owner;
        int destroyTimer;
        bool specialBullet = false;

        const int maxTimer = 180;
        const float speed = 8f;

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
            if(SpecialBullet == true)
                image = TextureLoader.Load("Misc\\Bullets\\plasmabullet", content);
            else
                image = TextureLoader.Load("Misc\\Bullets\\bullet", content);

            base.Load(content);
        }
        public override void Update(GameTime gameTime)
        {
            if (active == false)
                return;

            position += direction * speed;

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
            Console.WriteLine(hasSpecialAmmo.ToString());
            owner = inputOwner;
            position = inputPosition;
            direction = inputDirection;
            active = true;
            destroyTimer = maxTimer;
        }
    }
}
