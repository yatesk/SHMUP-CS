using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace SHMUP_CS
{
    class Enemy
    {
        public Vector2 position;

        public float velocity;

        public Texture2D image;
        public ContentManager content;

        public List<Projectile> projectiles;

        public Enemy(int y, float _velocity, ContentManager _content, string shipType)
        {
            content = _content;
            projectiles = new List<Projectile>();

            // x position starts off screen
            if (_velocity > 0)
            {
                position = new Vector2(-50, y);
            }
            else
            {
                position = new Vector2(1250, y);
            }
            
            velocity = _velocity;

            image = this.content.Load<Texture2D>(shipType);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position);

            foreach (var projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            position.X += velocity;
            

            foreach (var projectile in projectiles)
            {
                projectile.Update();
            }
        }

        public void FireProjectile()
        {
        }
    }
}