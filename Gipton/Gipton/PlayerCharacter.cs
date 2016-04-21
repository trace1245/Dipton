using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class PlayerCharacter : Human // и это тоже
    {
        float upcount { get; set; }
        float rightcount { get; set; }
        float downcount { get; set; }
        float leftcount { get; set; }


        public PlayerCharacter(Texture2D texture, MapGenerator gmap)
        {
            speed = 5;
            this.gmap = gmap;
            this.texture = texture;
            upcount = 0;
            rightcount = 0;
            downcount = 0;
            leftcount = 0;
            location = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2 - texture.Width/2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/ 2 - texture.Height / 2);

            //gmap.Move(new Vector2(600,600));
            
        }
        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                gmap.Move(directions.up, speed);
                if(upcount < 2000)
                {
                    upcount += speed;
                    downcount -= speed;
                }
                else
                {
                    //
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                gmap.Move(directions.right, speed);
                if(rightcount < 2000)
                {
                    rightcount += speed;
                    leftcount -= speed;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                gmap.Move(directions.down, speed);
                if(downcount < 2000)
                {
                    downcount += speed;
                    upcount -= speed;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                gmap.Move(directions.left, speed);
                if(leftcount < 2000)
                {
                    leftcount += speed;
                    rightcount -= speed;
                }
            }


        }

        public void MoveTo(Vector2 v)
        {
            gmap.Move(directions.right, v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2);
            gmap.Move(directions.down, v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
        }

    }
}
