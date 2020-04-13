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
    public class GameState : State
    {
        Map map;
        Hero hero;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {
            map = new Map();
            hero = new Hero();

            map.Generate(new int[,]
            {
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
                {2,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
                {2,2,1,1,1,0,0,0,0,1,1,2,2,2,1,0,0,0,0,2,2,},
                {2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,1,0,0,0,2,2,},
                {2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,1,1,1,2,2,},
                {2,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
            }, 64);

            hero.Load(contentManager);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);

            foreach (CollisionTiles tile in map.CollisionTiles)
                hero.Collision(tile.Rectangle, map.Width, map.Height);
        }
    }
}
