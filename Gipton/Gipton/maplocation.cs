using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class Maplocation // класс отвечающий за координаты и систему отсчета. Меняет и считает координаты обьектов, которые от него наследуются
    {
        public float xcount { get; protected set; }
        public float ycount { get; protected set; }


        public Texture2D texture { get; set; } // текстурка обьекта
        public bool player { get; protected set; } // true у игрока и тех вещей, которые двигаются из-за игрока. Когда игрок двигается - он двигает карту и обьекты. У них тогда player true. У крипа, когда он движется, false
        public bool map { get; protected set; } //true у блоков. 
        public bool isplayer { get; protected set; } // используется при проверке на столкновение с краем карты. какая разница между player и isplayer? player - значит действия игрока вызвали происходящее. может быть у крипов. isplayer только у игрока
        public Rectangle spr { get; private set; } // квадрат для проверки столкновений
        public Point sprsize { get; set; } //размер квадрата
        public Point sprlocation { get; set; } //положение квадрата. все это инициализируется при вызове loadmap
        protected MapGenerator gmap { get; set; }
        Vector2 point { get; set; } // точка от которой мы сё считаем (0,0)
        protected Vector2 location { get; set; } // положение относительно экрана
        private Vector2 _position; // положение относительно точки. само по себе приватно. доступом управляет аксессор
        protected Vector2 position // аксессор. нужен для того чтоб при каждой проверке значения position, оно сверялось с положением начального блока и обновляло его
        {
            get
            {
                this.point = gmap.parts[0, 0].GetLocation();
                return _position;
            }
            set
            {
                this.point = gmap.parts[0, 0].GetLocation();
                _position = value;
            }
        }

        public void LoadMap(Vector2 point, Vector2 position) // тут происходит выдача квадратов и положений на карте
        {

            if(this.player) // если мы делаем это с игроком, то локация его - центр экрана. положение - 0.0. Обязательно в конструкторе игрока использовать moveto. иначе его position похерится, т.к. тут он изначально 0 и меняется в игроке
            {
                location = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - this.texture.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - texture.Height / 2);
                this.position = point;//new Vector2(location.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, location.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);            
                sprsize = new Point(2);
                sprlocation = new Point((int)location.X + texture.Bounds.Height/2, (int)location.Y + texture.Bounds.Width/2); // квадрат в центр текстурки
                spr = new Rectangle(sprlocation, sprsize);
            }
            else // для крипов и обьектов вообще. корме блоков карты. наверно. 
            {
                this.point = point;
                this.position = position; //new Vector2(position.X,position.Y);
                location = new Vector2(point.X + position.X, point.Y + position.Y); // вычислятор положения относительно экрана при наличии координат точки и координат относительно точки
                spr = new Rectangle(location.ToPoint(), new Point(this.texture.Width, this.texture.Height));
            }

        }
        public void ChangePosition(Vector2 position) // меняет положение относительно карты, 0 0 - левый верхн угол карты
        {
            if(!map)
            {
                if(player) // вызывается в классе playercharacter. просто меняет position плеера. он сам стоит в центре экрана, так что мы должны просто задать его новое положение
                {
                    this.position = position;
                    spr = new Rectangle(sprlocation, sprsize);
                }
                if(!player) // если хочется поменять положение крипа или любого обьекта на карте. можно вызывать откуда душе угодно(наверно). меняет и локацию и положение
                {
                    this.position = position;
                    location = new Vector2(point.X + position.X, point.Y + position.Y);
                    spr = new Rectangle(location.ToPoint(), new Point(this.texture.Width, this.texture.Height));
                }
            }
            else // если двигаем блоки карты
            {
                location = position; // у блоков location и position это одно и тоже. важно вызывать это только из метода move, который в everyobject. боюсь представить что будет если вызвать это из другого места
                spr = new Rectangle(location.ToPoint(), new Point(this.texture.Width,this.texture.Height));
            }
                
                


        }

        public Vector2 CheckPosition()
        {
            return new Vector2(position.X,position.Y);
        }
        //public void ChangeLocation(Vector2 position) // 
        //{
        //    //this.position = position;
        //    location = position;
        //}

    }
}
