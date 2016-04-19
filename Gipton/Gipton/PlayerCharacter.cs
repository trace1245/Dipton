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
        MapGenerator gmap;

        public PlayerCharacter(Texture2D texture, MapGenerator gmap)
        {
            speed = 5;
            this.gmap = gmap;
        }
        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
                gmap.Move(directions.up, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Up) && (Keyboard.GetState().IsKeyDown(Keys.Right)))
                gmap.Move(directions.ur, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
                gmap.Move(directions.right, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Right) && (Keyboard.GetState().IsKeyDown(Keys.Down)))
                gmap.Move(directions.rd, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
                gmap.Move(directions.down, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Down) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                gmap.Move(directions.dl, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
                gmap.Move(directions.left, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Left) && (Keyboard.GetState().IsKeyDown(Keys.Up)))
                gmap.Move(directions.lu, speed);

        }
    }
}
