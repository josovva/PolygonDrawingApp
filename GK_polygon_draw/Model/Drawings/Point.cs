using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public class Point: IShape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public static float R => 10;

        public void Move(Vector2 vector)
        {
            X += vector.X;
            Y += vector.Y;
        }

        public IShape Collision(Point point)
        {
            if (Math.Abs(X - point.X) < Point.R && Math.Abs(Y - point.Y) < Point.R)
                return this;
            else return null;
        }

        public Vector2 MovingVector(Point point, Point movingPoint)
        {
            return new Vector2(point.X - X, point.Y - Y);
        }

        public Point MovingPoint(Point point)
        {
            return new Point(point.X, point.Y);
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
