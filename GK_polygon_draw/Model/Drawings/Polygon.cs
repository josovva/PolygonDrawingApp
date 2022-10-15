using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public class Polygon : IShape
    {
        public List<Point> Points { get; set; }
        public List<Line> Edges { get; set; }
        public int NumberOfPoints { get; set; }
        public Point movingPoint { get; set; }

        public Polygon()
        {
            Points = new List<Point>();
            Edges = new List<Line>();
            NumberOfPoints = 0;
            movingPoint = new Point(0, 0);
        }

        public void Move(float MoveX, float MoveY)
        {
            foreach(var point in Points)
            {
                point.Move(MoveX - movingPoint.X + point.X, MoveY - movingPoint.Y + point.Y);
            }
            CountMovingPoint();
        }

        public IShape Collision(Point point)
        {
            IShape ret = movingPoint.Collision(point);
            if(ret != null)
                return this;
            foreach (var pt in Points)
            {
                ret = pt.Collision(point);
                if (ret != null) return ret;
    }

            foreach(var edge in Edges)
            {
                ret = edge.Collision(point);
                if (ret != null)
                    return edge;
            }
            return null;
        }
        public void AddPoint(Point point)
        {
            Points.Add(point);
            NumberOfPoints++;
            CountMovingPoint();
            if (NumberOfPoints > 1)
                Edges.Add(new Line(Points[NumberOfPoints - 2], point));
        }

        public bool RemovePoint(Point point)
        {
            var item = Points.Find(p => Math.Abs(p.X - point.X) <= 10 && Math.Abs(p.Y - point.Y) <= 10);
            if(item != null)
            {
                Points.Remove(item);
                NumberOfPoints--;
                if(NumberOfPoints > 0)
                {
                    CountMovingPoint();
                }
                return true;
            }
            return false;
        }

        public void CountMovingPoint()
        {
            movingPoint = new Point(0, 0);
            foreach (var pt in Points)
            {
                movingPoint.X += pt.X;
                movingPoint.Y += pt.Y;
            }
            movingPoint.X = movingPoint.X / NumberOfPoints;
            movingPoint.Y = movingPoint.Y / NumberOfPoints;
        }

        public void AddPointOnEdge(Point endP, Point newP)
        {
           // var i = Points.FindIndex(p => p.X == endP.X && p.Y == endP.Y);
        }
    }
}
