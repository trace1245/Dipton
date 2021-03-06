﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class Maplocation
    {
        public float xcount { get; protected set; }
        public float ycount { get; protected set; }


        public Texture2D texture { get; set; }
        public bool player { get; protected set; }
        public bool map { get; protected set; }
        public Rectangle spr { get; private set; }
        public Point sprsize { get; set; }
        public Point sprlocation { get; set; }
        protected MapGenerator gmap { get; set; }
        Vector2 point { get; set; } // точка от которой мы сё считаем (0,0)
        protected Vector2 location { get; set; } // положение относительно экрана
        private Vector2 _position; // положение относительно точки
        protected Vector2 position 
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

        public void LoadMap(Vector2 point, Vector2 position) // задаем крипочку положение на карте относительно карты
        {

            if(this.player)
            {
                location = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - this.texture.Width / 2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - texture.Height / 2);
                this.position = point;//new Vector2(location.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, location.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);            
                sprsize = new Point(2);
                sprlocation = new Point((int)location.X + texture.Bounds.Height/2, (int)location.Y + texture.Bounds.Width/2);
                spr = new Rectangle(sprlocation, sprsize);
            }
            else
            {
                this.point = point;
                this.position = position; //new Vector2(position.X,position.Y);
                location = new Vector2(point.X + position.X, point.Y + position.Y);
                spr = new Rectangle(location.ToPoint(), new Point(this.texture.Width, this.texture.Height));
            }

        }
        public void ChangePosition(Vector2 position) // меняет положение относительно карты, 0 0 - левый верхн угол карты
        {
            if(!map)
            {
                if(player)
                {
                    this.position = position;
                    spr = new Rectangle(sprlocation, sprsize);
                }
                if(!player)
                {
                    this.position = position;
                    location = new Vector2(point.X + position.X, point.Y + position.Y);
                    spr = new Rectangle(location.ToPoint(), new Point(this.texture.Width, this.texture.Height));
                }
            }
            else
            {
                location = position;
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
