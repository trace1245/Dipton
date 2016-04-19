using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class MapGenerator
    {
        int size { get; set; } //кол-во клеток
        Texture2D[] textures { get; set; }
        TerrainPart[,] parts { get; set; }

        public MapGenerator(Texture2D texture, int size)
        {
            this.size = size;
            this.textures = textures;
            parts = new TerrainPart[size,size];
            for(int i = 0, x = 0; i < size * 80; i += 80, x++) 
            {
                for(int j = 0, y = 0; j < size * 80; j += 80, y++)
                {
                    parts[x, y] = new TerrainPart(texture, new Vector2(i,j));
                }
            }

        }

        public void Move(directions dir)
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    parts[i, j].Move(dir);
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            for(int i = 0; i<size;i++)
            {
                for(int j = 0; j < size; j++)
                {
                    parts[i, j].Draw(spritebatch);
                }
            }

        }

    }
}
