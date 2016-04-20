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
        public Creep(Texture2D texture, MapGenerator gmap)
        {
            this.gmap = gmap;
            this.texture = texture;
            location = new Vector2(200,200);
            gmap.AddCreep(this);
            speed = 2;
        }

        public void Move()
        {
            location = new Vector2(location.X + 1, location.Y + 1);
        }

    }
}
