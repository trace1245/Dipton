using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class PlayerCharacter : EverySingleObject
    {


        public PlayerCharacter(Texture2D texture, MapGenerator gmap, Vector2 posi)
        {
            player = true; // это игрок
            isplayer = true; // это точно игрок
            speed = 5; // это скорость игрока
            this.gmap = gmap; // это карта, по которой ходит игрок
            this.texture = texture; // это текстура, на которой отрисован игрок
            xcount = 0;// для прогрузки больших блоков
            ycount = 0;
            LoadMap(gmap.parts[0, 0].GetLocation(), posi); // даем игроку квадрат и положение
            gmap.AddPlayer(this); // даем карте ссылку на игрока
            MoveTo(posi);// именно этот метод задает настоящий position игрока. вызывать в конструкторе обязательно. а вообще это телепортатор, можно вызывать где душа пожелает

        }

        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))// если тык кнопка вверх
            {
                if(CheckPosition().Y <= 5)//проверяем чтоб не в край карты
                {
                    speed = -50;
                }
                gmap.Move(directions.up, speed);// двигаем всю карту. что забавно, вниз. В gmap'e карта и обьекты вызовут everyobject'a move
                ChangePosition(position + new Vector2(0, -speed)); // тут же говорим, что положение игрока поменялось. важно вызывать во всех перемещающих игрока методах
                ycount -= speed;
                speed = 5;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if(CheckPosition().X >= gmap.size*80 -5)
                {
                    speed = -50;
                }
                gmap.Move(directions.right, speed);
                ChangePosition(position + new Vector2(speed, 0));
                xcount += speed;
                speed = 5;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if(CheckPosition().Y >= gmap.size * 80 - 5)
                {
                    speed = -50;
                }
                gmap.Move(directions.down, speed);
                ChangePosition(position + new Vector2(0, speed));
                ycount += speed;
                speed = 5;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if(CheckPosition().X <= 5)
                {
                    speed = -50;
                }
                gmap.Move(directions.left, speed);
                ChangePosition(position + new Vector2(-speed, 0));
                xcount -= speed;
                speed = 5;

            }


        }

        public void MoveTo(Vector2 v) // перемещает в точку. меняет position/
        {
            gmap.Move(directions.right, v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2);
            ChangePosition(position + new Vector2(v.X, 0));
            xcount += v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            gmap.Move(directions.down, v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            ChangePosition(position + new Vector2(0, v.Y));
            ycount += v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
        }
        public void CountToZero()//обнуляет счетчик для подгрузки блоков. нигде кроме mapgen не вызывать. ну, на страх и риск
        {
            xcount = 0;
            ycount = 0;
        }

        public directions[] GetDirections()//бесполезный метод который нигде не вызывается и не нужен
        {
            directions[] dir = new directions[2];
            if(ycount >= 0)
            {
                dir[0] = directions.down;
            }
            else
            {
                dir[0] = directions.up;
            }
            if(xcount >= 0)
            {
                dir[1] = directions.right;
            }
            else
            {
                dir[1] = directions.left;
            }
            return dir;
        }

    }
}
