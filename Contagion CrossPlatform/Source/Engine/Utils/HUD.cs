using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Contagion_CrossPlatform
{
    public class HUD
    {
        SpriteFont spriteFont;
        Texture2D heart;

        public HUD(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Fonts\\gamer");
            heart = content.Load<Texture2D>("Misc\\Tiles\\heart");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Resolution.getTransformationMatrix());
            spriteBatch.Draw(heart, Vector2.Zero, Color.White);
            spriteBatch.DrawString(spriteFont, Hero.lives.ToString(), new Vector2(60, 12), Color.White);
            spriteBatch.DrawString(spriteFont, "Ammo: " + ((Hero.hasSpecialAmmo) ? Hero.specialAmmo.ToString() : "Infinite"), new Vector2(24, 36), Color.White);
            spriteBatch.DrawString(spriteFont, GameState.timer.ToString(), new Vector2(spriteBatch.GraphicsDevice.Viewport.Width / 2 - 50, 12), Color.White);
            spriteBatch.DrawString(spriteFont, "Score: " + GameState.score.ToString(), new Vector2(spriteBatch.GraphicsDevice.Viewport.Width - 105, 12), Color.White);
            spriteBatch.End();
        }
    }
}
