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
            location = ;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}
