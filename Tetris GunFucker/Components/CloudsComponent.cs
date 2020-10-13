using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisGunFucker
{
    public class CloudsComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Tetris tetris;
        private int change;
        private int direction;
        private Texture2D clouds;
        private Vector2 position;

        public CloudsComponent(Tetris tetris) : base(tetris)
        {
            this.tetris = tetris;
        }

        public override void Initialize()
        {
            position = new Vector2(0, 0);
            change = 0;
            direction = 1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            clouds = tetris.Content.Load<Texture2D>(@"Sprites\spr_clouds");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            position.X--;
            if (position.X < -(clouds.Width))
                position.X = 0;

            change += direction;
            if (change >= 96)
                direction = -1;
            if (change <= 0)
                direction = 1;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            tetris.spriteBatch.Begin();

            Color color = new Color(128 + change, 255 - change, 128 + change);
            for (int i = 0; i < 6; i++)
                tetris.spriteBatch.Draw(clouds, new Vector2(position.X + i * clouds.Width, 0), color * 0.8f);

            tetris.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
