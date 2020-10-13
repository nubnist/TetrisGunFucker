using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisGunFucker
{
    public class Block
    {
        public int[,] Tiles { get; private set; }
        public Vector2 position;

        public Block(int[,] tiles)
        {
            Tiles = CopyTiles(tiles);

            position = new Vector2(0, 0);
        }

        public void Fall()
        {
            position.Y++;
        }

        public void Rotate()
        {
            int[,] a = CopyTiles(Tiles);
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                    Tiles[x, y] = a[y, 3 - x];
        }

        private int[,] CopyTiles(int[,] tiles)
        {
            int[,] newTiles = new int[4, 4];
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 4; j++)
                    newTiles[j, i] = tiles[j, i];

            return newTiles;
        }

        public void Draw(Vector2 border, BetterSpriteBatch spriteBatch, Texture2D sprite)
        {
            for (var j = 0; j < 4; j++)
                for (var i = 0; i < 4; i++)
                    if (Tiles[i, j] > 0)
                        spriteBatch.Draw(sprite, new Vector2(border.X + (i + position.X) * sprite.Width, 
                            border.Y + (j + position.Y) * sprite.Height), Color.White);
        }
    }
}
