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
        protected MapGenerator gmap { get; set; }
        protected Vector2 maplocation { get; set; } // для системы отсчета относительно карты
        protected Texture2D texture { get; set; }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }

        public void MapLocation(Vector2 v)
        {

        }

        public bool PlayerNear() // проверка на то, должен ли обьект находится на экране. работает, но фигово
        {
            if((location.X >= -150 && location.Y >= -150) && (location.X <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width && location.Y <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height))
                return true;
                    else
                return false;
        }

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

                case directions.right:
                    {
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y);
                        location = NewLoc;
                        break;
                    }

                case directions.down:
                    {
                        Vector2 NewLoc = new Vector2(location.X, location.Y - speed);
                        location = NewLoc;
                        break;
                    }

                case directions.left:
                    {
                        Vector2 NewLoc = new Vector2(location.X + speed, location.Y);
                        location = NewLoc;
                        break;
                    }

            }


        }
    }
}
