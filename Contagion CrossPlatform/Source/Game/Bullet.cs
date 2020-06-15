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

        const int maxTimer = 180;
        const float speed = 8f;

        public Bullet()
        {
            active = false;
        }

        public override void Load(ContentManager content)
        {
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

        public void Fire(FireCharacter inputOwner, Vector2 inputPosition, Vector2 inputDirection)
        {
            Console.WriteLine(inputPosition.ToString());

            owner = inputOwner;
            position = inputPosition;
            direction = inputDirection;
            active = true;
            destroyTimer = maxTimer;
        }
    }
}
