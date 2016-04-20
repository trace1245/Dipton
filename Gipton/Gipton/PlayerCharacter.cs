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

        public PlayerCharacter(Texture2D texture, MapGenerator gmap)
        {
            speed = 5;
            this.gmap = gmap;
            this.texture = texture;
            location = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2 - texture.Width/2, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/ 2 - texture.Height / 2);
            gmap.Move(new Vector2(600,600));
            
        }
        public void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
                gmap.Move(directions.up, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Right))
                gmap.Move(directions.right, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Down))
                gmap.Move(directions.down, speed);
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
                gmap.Move(directions.left, speed);


        }

    }
}
