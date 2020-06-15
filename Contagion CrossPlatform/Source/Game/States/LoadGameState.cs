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
    public class LoadGameState : State
    {
        private List<Component> _gameComponents;
        private Color _backgroundColour = Color.CornflowerBlue;
        Texture2D mainTitleImage;

        public LoadGameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            mainTitleImage = TextureLoader.Load("Misc\\MainMenu\\titlescreen", _content);

            spriteBatch.Draw(mainTitleImage, Vector2.Zero, Color.White);

            foreach (var component in _gameComponents)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // Remove sprites if not needed.
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _gameComponents)
            {
                component.Update(gameTime);
            }
        }
    }
}
