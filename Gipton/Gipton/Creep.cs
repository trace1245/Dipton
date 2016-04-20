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
        public Creep(Texture2D texture, MapGenerator gmap, Vector2 location)
        {
            this.gmap = gmap;
            this.texture = texture;
            mlocation.location = location; // new Vector2(200,200);
            gmap.AddCreep(this);
            speed = 2;
        }

        public void Move()
        {
            mlocation.location = new Vector2(mlocation.location.X + 1, mlocation.location.Y + 1);
        }

    }
}
