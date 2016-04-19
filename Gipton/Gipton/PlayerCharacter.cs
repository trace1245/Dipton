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

        public PlayerCharacter(MapGenerator gmap)
        {
            speed = 5;
            this.gmap = gmap;
        }
        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
                gmap.Move(directions.up);
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
                gmap.Move(directions.right);
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
                gmap.Move(directions.down);
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
                gmap.Move(directions.left);
        }
    }
}
