using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SHMUP_CS
{
    public class Spaceship
    {
        public Vector2 position;

        public float velocity = 0.0f;

        public Texture2D image;
        public ContentManager content;


        public Spaceship(int x, int y, ContentManager _content)
        {
            content = _content;

            position = new Vector2(x, y);

            image = this.content.Load<Texture2D>("spaceship1");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position);
        }

        public void Update(float deltaTime)
        {

        }
    }
}