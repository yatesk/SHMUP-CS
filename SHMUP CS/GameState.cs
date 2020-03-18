using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;

namespace SHMUP_CS
{
    class GameState : State
    {
        private MouseInput mouseInput;
        private Level level;

        public GameState(Game1 game, ContentManager content) : base(game, content)
        {
            mouseInput = new MouseInput(Mouse.GetState());


            level = new Level(content);

            LoadContent();
        }

        public override void LoadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
        }
    }
}