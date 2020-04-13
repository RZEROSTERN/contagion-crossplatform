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
    public class SplashScreenState : State
    {
        public static Texture2D Background { get; set; }
        static int TimeCounter = 256;
        static Color color;

        public SplashScreenState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {
            Background = contentManager.Load<Texture2D>("Misc\\SplashScreen\\dev1logo");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, Vector2.Zero, color);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Do nothing.
        }

        public override void Update(GameTime gameTime)
        {
            color = Color.FromNonPremultiplied(255, 255, 255, TimeCounter % 256);

            Console.WriteLine(TimeCounter % 256);

            TimeCounter -= 2;

            if(TimeCounter.Equals(0))
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
    }
}
