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
        protected float speed { get; set; }

        public void Draw(SpriteBatch spriteBatch)
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

        public void Move(directions dir, float speed = 5, bool map = false)
        {
            float nspeed = speed;
            if(map)
            {
                this.map = true;
                this.player = true;
            }
            switch(dir) // TODO врезатся в карту
            {
                case directions.up:
                    {
                        if(!this.map && !this.isplayer && CheckPosition().Y <= 5)
                        {
                            speed = -50;
                        }
                        Vector2 NewLoc = new Vector2(location.X, location.Y + speed);
                        if(!player)
                            NewLoc = new Vector2(position.X, position.Y - 2 * speed);
                        ChangePosition(NewLoc); //location = NewLoc;
                        speed = nspeed;

                        break;
                    }

                case directions.right:
                    {
                        Vector2 NewLoc = new Vector2(location.X - speed, location.Y);
                        if(!player)
                            NewLoc = new Vector2(position.X + 2 * speed, position.Y);
                        ChangePosition(NewLoc); //location = NewLoc;

                        speed = nspeed;
                        break;
                    }

                case directions.down:
                    {
                        Vector2 NewLoc = new Vector2(location.X, location.Y - speed);
                        if(!player)
                            NewLoc = new Vector2(position.X, position.Y + (2 * speed));
                        ChangePosition(NewLoc); //location = NewLoc;

                        speed = nspeed;
                        break;
                    }

                case directions.left:
                    {
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
