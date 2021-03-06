﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Gipton
{
    class MapGenerator
    {
        int size { get; set; } //кол-во клеток
        Texture2D[] textures { get; set; }
        public TerrainPart[,] parts { get; private set; }
        public TerrainPart[,,] bparts { get; set; }
        List<EverySingleObject> allguys { get; set; }
        PlayerCharacter player { get; set; }
        int blocksize { get; set; }
        int blockamount { get; set; }
        int playerposition { get; set; }
        int count;




        public MapGenerator(Texture2D texture, int size)
        {
            count = 0;
            this.size = size;
            this.textures = textures;
            blocksize = 20;
            blockamount = size / blocksize;
            allguys = new List<EverySingleObject>();
            parts = new TerrainPart[size,size];
            bparts = new TerrainPart[blockamount * blockamount, blocksize, blocksize];

            for(int i = 0, x = 0; i < size * 80; i += 80, x++) // заполняем карту блоками
            {
                for(int j = 0, y = 0; j < size * 80; j += 80, y++)
                {
                    parts[x, y] = new TerrainPart(texture, new Vector2(i, j));
                }
            }

            for(int k = 0, ii = 0, jj = 0; k < blockamount * blockamount; k++) // разбиваем карту на прогружаемые блоки
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
                        if(i == blocksize - 1 && j == blocksize - 1) // если достигнут крайний нижний блок
                        {
                            bparts[k, blocksize / 2, blocksize / 2].MakeMiddle(); // задаем центральный блок в прогружаемом блоке
                        }
                    }
                }

                jj += blocksize;

            }

        }

        public int CheckPositionOnMap(EverySingleObject someone) // проверяет, на каком из прогружаемых блоков стоит игрок
        {
            
            for(int k = 0; k < blockamount * blockamount; k++)
            {
                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                        if(someone.spr.Intersects(bparts[k, i, j].spr))
                            return k;
                    }
                }
            }
            return -1; // даем -1 если игрок не на карте
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

        public void Update()
        {
            if(count == 0)
            {
                ThreadStart updatePP0 = new ThreadStart(delegate() { UpdatePlayerPosition(0, (blockamount*blockamount)/5); });
                ThreadStart updatePP1 = new ThreadStart(delegate () { UpdatePlayerPosition((blockamount * blockamount) / 5, ((blockamount * blockamount) / 5) * 2); });
                ThreadStart updatePP2 = new ThreadStart(delegate () { UpdatePlayerPosition(((blockamount * blockamount) / 5) * 2, ((blockamount * blockamount) / 5) * 3); });
                ThreadStart updatePP3 = new ThreadStart(delegate () { UpdatePlayerPosition(((blockamount * blockamount) / 5) * 3, ((blockamount * blockamount) / 5) * 4); });
                ThreadStart updatePP4 = new ThreadStart(delegate () { UpdatePlayerPosition(((blockamount * blockamount) / 5) * 4, blockamount); });
                Thread newThread0 = new Thread(updatePP0);
                Thread newThread1 = new Thread(updatePP1);
                Thread newThread2 = new Thread(updatePP2);
                Thread newThread3 = new Thread(updatePP3);
                Thread newThread4 = new Thread(updatePP4);
                newThread0.Start();
                newThread1.Start();
                newThread2.Start();
                newThread3.Start();
                newThread4.Start();
                count = 180;
            }
            count--;
        }

        public void UpdatePlayerPosition(int kk, int bblockamount)
        {
            for(int k = kk; k < bblockamount; k++)
            {
                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                        if(!bparts[k, i, j].IsMoved)
                        {
                            bparts[k, i, j].Move(directions.down, player.ycount);
                            bparts[k, i, j].Move(directions.right, player.xcount);
                        }
                        if(bparts[k, i, j].IsMoved)
                            bparts[k, i, j].IsMoved = false;
                    }
                }
            }
            if(bblockamount == blockamount)
            {
            player.CountToZero();
            playerposition = CheckPositionOnMap(player);
            }
        }


        public void Move(directions dir, float speed = 5)
        {
            if(playerposition != -1) // если игрок вообще стоит на карте. nk - это элемент k трехмерного массива, на котором стоит игрок
            {
                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                        bparts[playerposition, i, j].Move(dir, speed); // центральный блок
                        bparts[playerposition, i, j].IsMoved = true;
                        if(playerposition + 1 < blockamount * blockamount)
                        {
                            bparts[playerposition + 1, i, j].Move(dir, speed); // нижний блок
                            bparts[playerposition + 1, i, j].IsMoved = true;
                        }
                        if(playerposition - 1 >= 0)
                        {
                            bparts[playerposition - 1, i, j].Move(dir, speed); // верхний блок
                            bparts[playerposition - 1, i, j].IsMoved = true;

                        }
                        if(playerposition - blockamount - 1 >= 0)
                        {
                            bparts[playerposition - blockamount - 1, i, j].Move(dir, speed); //левый  верхний блок
                            bparts[playerposition - blockamount - 1, i, j].IsMoved = true;
                        }
                        if(playerposition - blockamount + 1 > 0)
                        {
                            bparts[playerposition - blockamount + 1, i, j].Move(dir, speed);// левый нижний
                            bparts[playerposition - blockamount + 1, i, j].IsMoved = true;

                        }
                        if(playerposition - blockamount >= 0)
                        {
                            bparts[playerposition - blockamount, i, j].Move(dir, speed); // левый
                            bparts[playerposition - blockamount, i, j].IsMoved = true;

                        }
                        if(playerposition + blockamount < blockamount * blockamount)
                        {
                            bparts[playerposition + blockamount, i, j].Move(dir, speed); //правый блок
                            bparts[playerposition + blockamount, i, j].IsMoved = true;

                        }
                        if(playerposition + blockamount - 1 < blockamount * blockamount)
                        {
                            bparts[playerposition + blockamount - 1, i, j].Move(dir, speed); //правый верхний блок
                            bparts[playerposition + blockamount - 1, i, j].IsMoved = true;

                        }
                        if(playerposition + blockamount + 1 < blockamount * blockamount)
                        {
                            bparts[playerposition + blockamount + 1, i, j].Move(dir, speed); // правый нижний
                            bparts[playerposition + blockamount + 1, i, j].IsMoved = true;

                        }

                    }
                }
            }

            //for(int i = 0; i < size; i++)
            //{
            //    for(int j = 0; j < size; j++)
            //    {
            //        parts[i, j].Move(dir, speed);
            //    }
            //}
            for(int i = 0; i < allguys.Count; i++)
            {
                allguys[i].Move(dir, speed, true); // true сдесь значит, что это игрок двигает карту и заодно и все остальное
            }
        }


        public void Draw(SpriteBatch spritebatch)
        {
            if(playerposition!=-1) // если игрок вообще стоит на карте. nk - это элемент k трехмерного массива, на котором стоит игрок
            {                                       // дальше отрисовка 9 блоков возле игрока
                for(int i = 0; i < blocksize; i++)
                {
                    for(int j = 0; j < blocksize; j++)
                    {
                            bparts[playerposition, i, j].Draw(spritebatch); // центральный блок
                        if(playerposition + 1 < blockamount * blockamount)
                            bparts[playerposition + 1, i, j].Draw(spritebatch); // нижний блок
                        if(playerposition - 1 >= 0)
                            bparts[playerposition - 1, i, j].Draw(spritebatch); // верхний блок
                        if(playerposition - blockamount - 1 >= 0)
                            bparts[playerposition - blockamount - 1, i, j].Draw(spritebatch); //левый  верхний блок
                        if(playerposition - blockamount + 1 > 0)
                            bparts[playerposition - blockamount + 1, i, j].Draw(spritebatch);// левый нижний
                        if(playerposition - blockamount >= 0)
                            bparts[playerposition - blockamount, i, j].Draw(spritebatch); // левый
                        if(playerposition + blockamount < blockamount * blockamount)
                            bparts[playerposition + blockamount, i, j].Draw(spritebatch); //правый блок
                        if(playerposition + blockamount - 1 < blockamount*blockamount)
                            bparts[playerposition + blockamount - 1, i, j].Draw(spritebatch); //правый верхний блок
                        if(playerposition + blockamount + 1 < blockamount * blockamount)
                            bparts[playerposition + blockamount + 1, i, j].Draw(spritebatch); // правый нижний


                        //for(int i = 0; i<size;i++) // отрисовка всей карты
                        //{
                        //    for(int j = 0; j < size; j++)
                        //    {
                        //        parts[i, j].Draw(spritebatch);
                        //    }
                        //}


                        //for(int k = 0; k < blockamount*blockamount; k++) // отрисовка всей карты через bparts
                        //{
                        //    for(int i = 0; i < blocksize; i++)
                        //    {
                        //        for(int j = 0; j < blocksize; j++)
                        //        {
                        //            bparts[k, i, j].Draw(spritebatch);
                        //        }
                        //    }
                        //}
                    }
                }
            }


        }


    }
}
