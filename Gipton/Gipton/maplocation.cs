using System;
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

        public void LoadMap(Vector2 point, Vector2 position)
        {
            this.point = point;
            this.position = position;
            location = new Vector2(point.X + position.X, point.Y + position.Y);
        }
        public void ChangePosition(Vector2 position)
        {
            this.position = position;
            location = new Vector2(point.X + position.X, point.Y + position.Y);
        }

    }
}
