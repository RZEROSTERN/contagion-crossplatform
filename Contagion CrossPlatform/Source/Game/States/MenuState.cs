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
    public class MenuState : State
    {
        private List<Component> _gameComponents;
        private Color _backgroundColour = Color.CornflowerBlue;
        Texture2D mainTitleImage;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls\\Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts\\gamer");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((_game.GraphicsDevice.Viewport.Width / 2) - 65, (_game.GraphicsDevice.Viewport.Width / 3)),
                Text = "New Game",
            };

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((_game.GraphicsDevice.Viewport.Width / 2) - 65, (_game.GraphicsDevice.Viewport.Width / 3) + 50),
                Text = "Quit",
            };

            newGameButton.Click += NewGameButton_Click;
            quitGameButton.Click += QuitGameButton_Click;

            _gameComponents = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };
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

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
