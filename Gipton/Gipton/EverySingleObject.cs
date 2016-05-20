using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class EverySingleObject : Maplocation 
    {
        protected float speed { get; set; } // скорость обьекта

        public void Draw(SpriteBatch spriteBatch) // вот просто берешь и отрисовываешь любой обьект. просто как табуретка. рисует текстурку там где обьект
        {
            spriteBatch.Draw(texture, location, Color.White);
        }



        //public bool PlayerNear() // проверка на то, должен ли обьект находится на экране. работает, но фигово
        //{
        //    if((location.X >= 0 && location.Y >= 0) && (location.X <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width && location.Y <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height))
        //        return true;
        //    else
        //        return false;
        //}


        // движение игрока или крипа. я тут сотворил что-то громоздкое, как дурак, не перегрузив функцию а понаписав if'ов.
        //Эта функция есть у всего живого. она двигает обьект в направлении dir со скоростью speed. bool map вызывается только в mapgenerator'е и нужен для того чтоб перемещать крипов как часть карты когда двинается игрок
        //тоесть когда ты двигаешь крипа, задавая ему все 3 аргумента, он двигается относительно игрока. короче, игрок ходит, двигает карту, в mapgenerator'е передвигается вся карта и при передвижении обьектов мы даем им трушный map
        public void Move(directions dir, float speed = 5, bool map = false) 
        {
            float nspeed = speed; // сохраняем скорость для проверки столкновений с краем карты
            if(map)
            {
                //эти две строчки кода - какой-то бред. я не понимаю как они работают, они противоречят друг другу
                //если map true, то при вызове changepos оно даже не посмотрит на значение player
                //тем не менее если удалить хоть одну строчку оно перестает работать нормально и происходит что-то темномагическое
                //вообщем эти две строчки кода заставляют changepos относится к обьектам как к кускам карты. нужно при движении игрока, когда он двигает карту
                //пока писал комментарий кажется понял как оно работает
                this.map = true;
                this.player = true;
            }
            switch(dir)
            {
                case directions.up:
                    {
                        if(!this.map && !this.isplayer && CheckPosition().Y <= 5) //проверка на врезание в край карты. для всего кроме игрока и карты
                        {
                            speed = -50;
                        }
                        Vector2 NewLoc = new Vector2(location.X, location.Y + speed);// задаем новое положение обьекта на карте
                        if(!player)
                            NewLoc = new Vector2(position.X, position.Y - 2 * speed); // если движется крип(по своему желанию, а не из-за игрока), то меняем направление, т.к. карта при движении игрока движется в зеркальном направлении
                        ChangePosition(NewLoc); // получив новое положение, вызываем changepos из maplocation'a
                        speed = nspeed;

                        break;
                    }

                case directions.right:
                    {
                        if(!this.map && !this.isplayer && CheckPosition().X >= gmap.size * 80 - 5)
                        {
                            speed = -50;
                        }
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y);
                        if(!player)
                            NewLoc = new Vector2(position.X + 2 * speed, position.Y);
                        ChangePosition(NewLoc); //location = NewLoc;

                        speed = nspeed;
                        break;
                    }

                case directions.down:
                    {
                        if(!this.map && !this.isplayer && CheckPosition().Y >= gmap.size * 80 - 5)
                        {
                            speed = -50;
                        }
                        Vector2 NewLoc = new Vector2(location.X, location.Y - speed);
                        if(!player)
                            NewLoc = new Vector2(position.X, position.Y + (2 * speed));
                        ChangePosition(NewLoc); //location = NewLoc;

                        speed = nspeed;
                        break;
                    }

                case directions.left:
                    {
                        if(!this.map && !this.isplayer && CheckPosition().X <= 5)
                        {
                            speed = -50;
                        }
                        Vector2 NewLoc = new Vector2(location.X + speed, location.Y);
                        if(!player)
                            NewLoc = new Vector2(position.X - 2 * speed, position.Y);
                        ChangePosition(NewLoc); //location = NewLoc;

                        speed = nspeed;
                        break;
                    }

            }
            if(map)
            {
                this.player = false;
                this.map = false;
            }


        }
    }
}
