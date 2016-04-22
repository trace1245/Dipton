using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    class Creep : Human
    {
        
        public Creep(Texture2D texture, MapGenerator gmap, Vector2 position)
        {
            player = false;
            this.gmap = gmap;
            this.texture = texture;
            //this.location = location; // new Vector2(200,200);
            gmap.AddCreep(this, position);

            speed = 2;
        }

        //public void Move()
        //{
        //    this.ChangePosition(new Vector2(position.X + 1, position.Y + 1));
        //}

    }
}
