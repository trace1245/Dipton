using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gipton
{
    class EverySingleObject
    {
        protected Vector2 location { get; set; }

        //protected EverySingleObject(Vector2 location)
        //{
        //    this.location = location;
        //}

        public void Move()
        {
            Vector2 NewLoc = new Vector2(location.X + 1,location.Y);
            location = NewLoc;
        }
    }
}
