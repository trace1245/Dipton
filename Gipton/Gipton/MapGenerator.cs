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
        List<Vector2> MiddlePoints { get; set; }
        List<EverySingleObject> allguys { get; set; }
        PlayerCharacter player { get; set; }
        Vector2 firstcoo { get; set; } // левая верхняя точка в системе координат (0,0)
        Vector2 lastcoo { get; set; } // правая нижняя
        int blocksize { get; set; }
        int blockamount { get; set; }




        public MapGenerator(Texture2D texture, int size)
        {
            this.size = size;
            this.textures = textures;
            blocksize = 2;
            blockamount = size / blocksize;
            allguys = new List<EverySingleObject>();
            MiddlePoints = new List<Vector2>();
            parts = new TerrainPart[size,size];
            bparts = new TerrainPart[blockamount * blockamount, blocksize, blocksize];

            for(int i = 0, x = 0; i < size * 80; i += 80, x++)
            {
                for(int j = 0, y = 0; j < size * 80; j += 80, y++)
                {
                    parts[x, y] = new TerrainPart(texture, new Vector2(i, j));
                }
            }

            for(int k = 0, ii = 0, jj = 0; k < blockamount * blockamount; k++)
            {
                if((k % blockamount == 0) && (k!= 0))
                {
                    jj = 0;
                    ii += blocksize;
                }

                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                            bparts[k, i, j] = parts[i + ii, j + jj];
                    }
                }

                jj += blocksize;

            }

            int fds = 3;
            //blocksize * (k+1) + (i-blocksize)
            //
            //for(int i = 0; i < size; i++)
            //{
            //    for(int j = 0; j < size; j++)
            //    {
            //        //parts[i, j]
            //    }
            //}
        }

        void CheckPosition()
        {
            int blocknumber;

            //for(int k = 0; k < blockamount; k++)
            //{
            //    for(int i = 0, x = 0; i < size * 80; i += 80, x++)
            //    {
            //        for(int j = 0, y = 0; j < size * 80; j += 80, y++)
            //        {
            //            if(player.spr.Intersects(bparts[k,i,j].spr))
            //            {
            //                blocknumber = k;
            //            }
            //        }
            //    }
            //}
        }

        public void AddCreep(EverySingleObject one, Vector2 position)
        {
            allguys.Add(one);
            one.LoadMap(parts[0, 0].GetLocation(), position);

        }
        public void AddPlayer(PlayerCharacter player)
        {
            this.player = player;
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
                allguys[i].Move(dir, speed, true);
            }
        }


        public void Draw(SpriteBatch spritebatch)
        {
            //for(int i = 0; i<size;i++)
            //{
            //    for(int j = 0; j < size; j++)
            //    {
            //        parts[i, j].Draw(spritebatch);
            //    }
            //}
            for(int k = 0; k < blockamount*blockamount; k++)
            {
                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                        bparts[k, i, j].Draw(spritebatch);
                    }
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
