using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisGunFucker
{
    public class LevelComponent : DrawableGameComponent
    {
        private Tetris tetris;
        private Texture2D background;

        public LevelComponent(Tetris tetris) : base(tetris)
        {
            this.tetris = tetris;
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = tetris.Content.Load<Texture2D>(@"Sprites\background_level");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            tetris.spriteBatch.Begin();
            tetris.spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            tetris.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
