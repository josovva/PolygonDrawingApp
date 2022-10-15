using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public class Point: IShape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public static float R => 10;

        public void Move(float MoveX, float MoveY)
        {
            X += (MoveX - X);
            Y += (MoveY - Y);
        }

        public IShape Collision(Point point)
        {
            if (Math.Abs(X - point.X) < Point.R && Math.Abs(Y - point.Y) < Point.R)
                return this;
            else return null;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
