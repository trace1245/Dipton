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


        public PlayerCharacter(Texture2D texture, MapGenerator gmap, Vector2 posi)
        {
            speed = 5;
            this.gmap = gmap;
            this.texture = texture;
            upcount = 0;
            rightcount = 0;
            downcount = 0;
            leftcount = 0;
            bpixels = 0;
            location = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2 - texture.Width/2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/ 2 - texture.Height / 2);
            position = new Vector2(location.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, location.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2);
            MoveTo(posi);
            
        }

        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                gmap.Move(directions.up, speed, true);
                ChangePosition(position + new Vector2(0, -speed), true);
                if(upcount < bpixels)
                {
                    upcount += speed;
                    downcount -= speed;
                }
                else
                {
                    upcount = -bpixels;
                    downcount = bpixels;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                gmap.Move(directions.right, speed, true);
                ChangePosition(position + new Vector2(speed, 0), true);
                if(rightcount < bpixels)
                {
                    rightcount += speed;
                    leftcount -= speed;
                }
                else
                {
                    leftcount = bpixels;
                    rightcount = -bpixels;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                gmap.Move(directions.down, speed, true);
                ChangePosition(position + new Vector2(0, speed), true);
                if(downcount < bpixels)
                {
                    downcount += speed;
                    upcount -= speed;
                }
                else
                {
                    upcount = bpixels;
                    downcount = -bpixels;
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                gmap.Move(directions.left, speed, true);
                ChangePosition(position + new Vector2(-speed, 0), true);
                if(leftcount < bpixels)
                {
                    leftcount += speed;
                    rightcount -= speed;
                }
                else
                {
                    leftcount = -bpixels;
                    rightcount = bpixels;
                }

            }


        }

        public void MoveTo(Vector2 v)
        {
            gmap.Move(directions.right, v.X - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2, true);
            gmap.Move(directions.down, v.Y - GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2, true);
        }

    }
}
