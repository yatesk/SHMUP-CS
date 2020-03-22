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