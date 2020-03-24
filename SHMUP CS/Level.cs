using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace SHMUP_CS
{
    class Level
    {
        public Spaceship spaceship;
        ContentManager content;

        public List<Enemy> enemies;

        private Texture2D backgroundImage;

        Random rnd = new Random();

        int enemyCount = 5;

        public Level(ContentManager _content)
        {
            content = _content;
            spaceship = new Spaceship(200, 200, _content);

            enemies = new List<Enemy>();

            enemies.Add(new Enemy(50, -5f, content, "spaceship1"));

            LoadContent();
        }

        public void Update(GameTime gameTime, MouseInput mouseInput)
        {
            spaceship.Update(gameTime, mouseInput);

            foreach (var enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            // remove enemies that go off screen
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].position.X < -100 || enemies[i].position.X > Game1.screenWidth + 100 || enemies[i].position.Y < -100 || enemies[i].position.Y > Game1.screenHeight + 100)
                {
                    enemies.RemoveAt(i);
                }
            }

            while (enemies.Count <= enemyCount)
            {
                int y = rnd.Next(50, Game1.screenHeight - 50);
                int velocity = rnd.Next(1, 6);

                // if random number is 0 then go right to left
                if (rnd.Next(0, 2) == 0)
                    velocity *= -1;

                enemies.Add(new Enemy(y, velocity, content, "spaceship1"));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundImage, new Vector2(0, 0));

            spaceship.Draw(spriteBatch);

            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        public void LoadContent()
        {
            backgroundImage = content.Load<Texture2D>("background");
        }
    }
}