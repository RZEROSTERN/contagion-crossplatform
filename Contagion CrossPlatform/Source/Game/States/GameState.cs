﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contagion_CrossPlatform
{
    public class GameState : State
    {
        Map map;
        Hero hero;
        List<Enemy> enemies = new List<Enemy>();
        private const String PATH = "Content\\Misc\\Levels\\";

        public static TimeSpan timer;
        public static int score = 0;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {
            map = new Map();
            hero = new Hero();

            for (int i = 0; i < 3; i++)
            {
                Enemy enemy = new Enemy();
                enemies.Add(enemy);
                enemy.Initialize();
            }

            hero.Initialize();

            int[,] jsonLevel = loadJSON(PATH + "level1.json");

            map.Generate(jsonLevel, 32);

            hero.Load(contentManager);

            for(int i = 0; i < enemies.Count; i++) 
            { 
                enemies[i].Load(contentManager);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _game.camera.Transform);
            map.Draw(spriteBatch);
            hero.Draw(spriteBatch);

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime);
                enemies[i].CollisionWithHero(hero);
            }
                

            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                hero.Collision(tile, map.Width, map.Height);

                for (int i = 0; i < enemies.Count; i++)
                    enemies[i].Collision(tile, map.Width, map.Height);

                _game.camera.Update(hero.Position, map.Width, map.Height);
            }

            foreach (Bullet bullet in hero.bullets)
            {
                if (bullet.active == true)
                {
                    for (int i = 0; i < enemies.Count; i++)
                        bullet.Collision(map, enemies[i]);
                }
            }

            timer += gameTime.ElapsedGameTime;
        }

        public int[,] loadJSON(string path)
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();

                int[,] items = JsonConvert.DeserializeObject<int[,]>(json);

                return items;
            }
        }
    }
}
