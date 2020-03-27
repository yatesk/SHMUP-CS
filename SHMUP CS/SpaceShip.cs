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

        enum Weapons { Single, Spread, FullSpread, Mine};
            enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
        // later enum
        private Weapons weaponSelected;

        public Spaceship(int x, int y, ContentManager _content)
        {
            content = _content;
            projectiles = new List<Projectile>();

            position = new Vector2(x, y);
            velocity = 5.0f;
            rotation = 0;
            weaponSelected = Weapons.Single;

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

            // refactor so spaceship moves more smoothly
            if (Math.Abs(distanceBetween.Y) > 32 || Math.Abs(distanceBetween.X) > 16)
            {
                rotation = (float)Math.Atan2(distanceBetween.Y, distanceBetween.X);

                Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

                position += direction * velocity;
            }

            foreach (var projectile in projectiles)
            {
                projectile.Update();
            }
        }

        public void ShootWeapon(int mouseX, int mouseY)
        {

            switch (weaponSelected)
            {
                case Weapons.Single:
                {
                    double angle = Math.Atan2(mouseY - position.Y, mouseX - position.X);

                    projectiles.Add(new Projectile(content, position, angle));
                        break;
                }

                case Weapons.Spread:
                {
                    double angle = Math.Atan2(mouseY - position.Y, mouseX - position.X);

                    projectiles.Add(new Projectile(content, position, angle));
                    projectiles.Add(new Projectile(content, position, angle + .25));
                    projectiles.Add(new Projectile(content, position, angle - .25));
                    break;
                }

                case Weapons.FullSpread:
                {
                    double angle = Math.Atan2(mouseY - position.Y, mouseX - position.X);

                    projectiles.Add(new Projectile(content, position, 3));
                    projectiles.Add(new Projectile(content, position, 2));
                    projectiles.Add(new Projectile(content, position, 1));
                    projectiles.Add(new Projectile(content, position, 0));
                    projectiles.Add(new Projectile(content, position, -1));
                    projectiles.Add(new Projectile(content, position, -2));
                    break;
                }
                case Weapons.Mine:
                {
                    projectiles.Add(new Projectile(content, position, 0, 0));
                        break;
                }
            }
        }

        // refactor
        public void SwitchWeapon()
        {
            if (weaponSelected == Weapons.Single)
                weaponSelected = Weapons.Spread;
            else if (weaponSelected == Weapons.Spread)
                weaponSelected = Weapons.FullSpread;
            else if (weaponSelected == Weapons.FullSpread)
                weaponSelected = Weapons.Mine;
            else if (weaponSelected == Weapons.Mine)
                weaponSelected = Weapons.Single;
        }
    }
}