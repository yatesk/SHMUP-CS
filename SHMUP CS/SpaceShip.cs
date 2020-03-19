using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace SHMUP_CS
{
    class Spaceship
    {
        public Vector2 position;
        public Vector2 origin;

        public float velocity;
        public double rotation;

        public Texture2D image;
        public ContentManager content;

        public List<Projectile> projectiles;

        public Spaceship(int x, int y, ContentManager _content)
        {
            content = _content;
            projectiles = new List<Projectile>();

            position = new Vector2(x, y);
            velocity = 3.0f;
            rotation = 0;

            image = this.content.Load<Texture2D>("spaceship1");
            origin = new Vector2(image.Width / 2f, image.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, null, Color.White, (float)rotation, origin, 1.0f, SpriteEffects.None, 1.0f);

            foreach (var projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime, MouseInput mouseInput)
        {
            Vector2 distanceBetween = new Vector2(mouseInput.getMouseX() - position.X, mouseInput.getMouseY() - position.Y);

            // refactor so there are no 180 degree turns
            if (Math.Abs(distanceBetween.Y) > 33 || Math.Abs(distanceBetween.X) > 65)
            {
                rotation = (float)Math.Atan2(distanceBetween.Y, distanceBetween.X);
            }

            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            position += direction * velocity;

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