using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Contagion_CrossPlatform
{
    public class HUD
    {
        SpriteFont spriteFont;

        public HUD(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Fonts\\gamer");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "Test", Vector2.Zero, Color.White);
        }
    }
}
