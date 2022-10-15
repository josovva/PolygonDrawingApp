using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public class Line : IShape
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public void Move(float MoveX, float MoveY)
        {
            float A = (StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X);
            float B = (StartPoint.Y - A * StartPoint.X);
            float newA = -1 / A;
            float newB = MoveY - newA * MoveX;
            float diffX = (newB - B) / (A - newA);
            float diffY = diffX * A + B; 

            StartPoint.Move(MoveX - diffX + StartPoint.X, MoveY - diffY + StartPoint.Y);
            EndPoint.Move(MoveX - diffX + EndPoint.X, MoveY - diffY + StartPoint.Y);
        }

        public IShape Collision(Point point)
        {
            float A = (StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X);
            float B = (StartPoint.Y - A * StartPoint.X);
            var dist = Math.Abs(A * point.X + point.Y + B) / Math.Sqrt(Math.Pow(A, 2) + 1);
            if (dist < Point.R)
                return this;
            else return null;
        }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
