using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SHMUP_CS
{
    class Projectile
    {
        public int width = 4;
        public int height = 4;
        public Vector2 position;
        public Vector2 velocity;

        public float velocityMultiplier;

        public double angle;

        Texture2D image;

        public Projectile(ContentManager content, Vector2 _position, double _angle, float _velocityMultiplier = 8f)
        {
            image = content.Load<Texture2D>("bullet1");
            velocityMultiplier = _velocityMultiplier;
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