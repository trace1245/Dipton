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
        public TerrainPart[,] parts { get; private set; }
        public TerrainPart[,,] bparts { get; set; }
        List<Human> allguys { get; set; }
        Vector2 firstcoo { get; set; } // левая верхняя точка в системе координат (0,0)
        Vector2 lastcoo { get; set; } // правая нижняя
        int blocksize { get; set; }
        int blockamount { get; set; }



        public MapGenerator(Texture2D texture, int size)
        {
            this.size = size;
            this.textures = textures;
            blocksize = 5;
            blockamount = size / blocksize;
            allguys = new List<Human>();
            parts = new TerrainPart[size,size];
            bparts = new TerrainPart[blockamount, size, size];
            for(int k = 0; k < blockamount; k++) 
            {
                for(int i = 0, x = 0; i < size * 80; i += 80, x++)
                {
                    for(int j = 0, y = 0; j < size * 80; j += 80, y++)
                    {
                        parts[x, y] = new TerrainPart(texture, new Vector2(i, j));
                        bparts[k, x, y] = parts[x, y];
                    }
                }
            }

        }

        public void AddCreep(Human one, Vector2 position)
        {
            allguys.Add(one);
            one.LoadMap(parts[0, 0].GetLocation(), new Vector2(1000, 1000));

        }

        public void Move(directions dir, float speed = 5)
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    parts[i, j].Move(dir, speed);
                }
            }
            for(int i = 0; i < allguys.Count; i++)
            {
                allguys[i].Move(dir, speed);
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

        //void CreateCoordinateSystem()
        //{
        //    firstcoo = parts[0, 0].maplocation;
        //    lastcoo = parts[size, size].maplocation;
        //}

    }
}
