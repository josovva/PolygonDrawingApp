using GK_polygon_draw.Model.Relations;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace GK_polygon_draw.Model.Drawings
{
    public class Line : IShape
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public FixedLength FixedLgth { get; private set; }
        public List<Perpendicular> PerpEdges { get; private set; }
        public Line()
        {
            PerpEdges = new List<Perpendicular>();
        }
        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            PerpEdges = new List<Perpendicular>();
        }
        public IShape Collision(Point point)
        {
            double dist = Point.R;
            if (StartPoint.X - EndPoint.X == 0)
            {
                dist = Math.Abs(point.X - StartPoint.X);
            }
            else if (StartPoint.Y - EndPoint.Y == 0)
            {
                dist = Math.Abs(point.Y - StartPoint.Y); ;
            }
            else
            {
                float A = (StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X);
                float B = (StartPoint.Y - A * StartPoint.X);
                dist = Math.Abs(A * point.X - point.Y + B) / Math.Sqrt(Math.Pow(A, 2) + 1);

            }
            if (dist < Point.R / 2 && ((point.Y <= Math.Max(StartPoint.Y, EndPoint.Y) + Point.R / 2 && point.Y >= Math.Min(StartPoint.Y, EndPoint.Y) - Point.R / 2)
                && ((point.X <= Math.Max(StartPoint.X, EndPoint.X) + Point.R / 2 && point.X >= Math.Min(StartPoint.X, EndPoint.X) - Point.R / 2))))
                return this;
            return null;
        }
        public Point MovingPoint(Point point)
        {
            Point closePoint = new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
            if (StartPoint.X == EndPoint.X)
                return new Point(StartPoint.X, point.Y);
            else if (StartPoint.Y == EndPoint.Y)
                return new Point(point.X, StartPoint.Y);
            else
            {
                float A = (StartPoint.Y - EndPoint.Y) / (StartPoint.X - EndPoint.X);
                float B = (StartPoint.Y - A * StartPoint.X);
                float newA = -1 / A;
                float newB = 1 / A * point.X + point.Y;
                float x = (newB - B) / (A - newA);
                float y = A * x + B;
                return new Point(x, y);

            }
        }
        public Vector2 MovingVector(Point point, Point movingPoint)
        {
            return new Vector2(point.X - movingPoint.X, point.Y - movingPoint.Y);
        }
        public void Move(Vector2 vector)
        {
            StartPoint.Move(vector);
            EndPoint.Move(vector);
        }
        public void AddLength(float length)
        {
            FixedLgth = new FixedLength(length);
        }
        public void DeleteLength()
        {
            FixedLgth = null;
        }
        public void AddPerpendicular(Line edge)
        {
            PerpEdges.Add(new Perpendicular(edge));
        }
        public void DeletePerpendicular(Line edge)
        {
            PerpEdges.RemoveAll(e => e.Constraint.StartPoint == edge.StartPoint && e.Constraint.EndPoint == edge.EndPoint);
        }
        public void DeletePerpendicular(Perpendicular rel)
        {
            PerpEdges.RemoveAll(e => e.Id == rel.Id);
        }
    }
}
