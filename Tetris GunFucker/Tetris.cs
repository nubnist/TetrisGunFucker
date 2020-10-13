using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Emit;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TetrisGunFucker
{
    public class Tetris : Game
    {
        private GraphicsDeviceManager _graphics;
        public BetterSpriteBatch spriteBatch;

        public int _windowWidth = 1280;
        public int _windowHeight = 720;

        public Tetris()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteBatch = new BetterSpriteBatch(GraphicsDevice);
            CloudsComponent clouds = new CloudsComponent(this);
            LevelComponent level = new LevelComponent(this);
            Components.Add(clouds);
            Components.Add(level);

            #region Настройки окна

            _graphics.PreferredBackBufferWidth = _windowWidth;
            _graphics.PreferredBackBufferHeight = _windowHeight;
            _graphics.IsFullScreen = false;
            IsMouseVisible = false;
            _graphics.ApplyChanges();

            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        public void ChangeMusic(Song song)
        {
            if (MediaPlayer.Queue.ActiveSong != song)
                MediaPlayer.Play(song);
        }

        //public bool NewKey(Keys key) => keyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }
}
