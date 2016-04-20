using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gipton
{
    struct maplocation
    {
        float X { get; set; }
        float Y { get; set; }
        float iX { get; set; }
        float iY { get; set; }
        Vector2 point1 { get; set; }
        public Vector2 location { get; set; } // для отрисовки на карте
        public void LoadMap(Vector2 point)
        {
            point1 = point;
            iX = point.X;
            iY = point.Y;
            X = iX - point.X;
            Y = iY - point.Y;
            location = new Vector2();
        }
    }
}
