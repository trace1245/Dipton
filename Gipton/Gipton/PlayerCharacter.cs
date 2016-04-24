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
            player = true;
            speed = 5;
            this.gmap = gmap;
            this.texture = texture;
            xcount = 0;
            ycount = 0;
            LoadMap(gmap.parts[0, 0].GetLocation(), posi);
            gmap.AddPlayer(this);
            //MoveTo(posi);

        }

        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                gmap.Move(directions.up, speed);
                //ChangePosition(position + new Vector2(0, -speed));

                ycount -= speed;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                gmap.Move(directions.right, speed);
                //ChangePosition(position + new Vector2(speed, 0));

                xcount += speed;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                gmap.Move(directions.down, speed);
                //ChangePosition(position + new Vector2(0, speed));
                
                ycount += speed;

            }
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                gmap.Move(directions.left, speed);
                //ChangePosition(position + new Vector2(-speed, 0));
                
                xcount -= speed;

            }


        }

        public void MoveTo(Vector2 v)
        {
            gmap.Move(directions.right, v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2);
            xcount += v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            gmap.Move(directions.down, v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            ycount += v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
        }
        public void CountToZero()
        {
            xcount = 0;
            ycount = 0;
        }

        public directions[] GetDirections()
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
