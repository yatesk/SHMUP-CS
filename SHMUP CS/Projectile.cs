using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SHMUP_CS
{
    class Projectile
    {
        public int width = 64;
        public int height = 64;
        public Vector2 position;
        public Vector2 velocity;

        public float velocityMultiplier = 5f;

        public double angle;

        Texture2D image;

        public Projectile(ContentManager content, Vector2 _position, double _angle = 0)
        {
            image = content.Load<Texture2D>("bullet1");

            position = _position;
            angle = _angle;
        }

        public void Update()
        {
            velocity.X = velocityMultiplier * (float)Math.Cos(angle);
            velocity.Y = velocityMultiplier * (float)Math.Sin(angle);

            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position);
        }
    }
}