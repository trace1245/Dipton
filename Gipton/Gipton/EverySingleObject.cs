using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class EverySingleObject
    {
        protected Vector2 location { get; set; }

        //protected EverySingleObject(Vector2 location)
        //{
        //    this.location = location;
        //}

        public void Move(directions dir, int speed = 5)
        {
            switch(dir)
            {
                case directions.up:
                    {
                        Vector2 NewLoc = new Vector2(location.X, location.Y + speed);
                        location = NewLoc;
                        break;
                    }
                case directions.ur:
                    {
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y + speed);
                        location = NewLoc;
                        break;
                    }
                case directions.right:
                    {
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y);
                        location = NewLoc;
                        break;
                    }
                case directions.rd:
                    {
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y - speed);
                        location = NewLoc;
                        break;
                    }
                case directions.down:
                    {
                        Vector2 NewLoc = new Vector2(location.X, location.Y - speed);
                        location = NewLoc;
                        break;
                    }
                case directions.dl:
                    {
                        Vector2 NewLoc = new Vector2(location.X + speed, location.Y - speed);
                        location = NewLoc;
                        break;
                    }
                case directions.left:
                    {
                        Vector2 NewLoc = new Vector2(location.X + speed, location.Y);
                        location = NewLoc;
                        break;
                    }
                case directions.lu:
                    {
                        Vector2 NewLoc = new Vector2(location.X + speed, location.Y + speed);
                        location = NewLoc;
                        break;
                    }
            }


        }
    }
}
