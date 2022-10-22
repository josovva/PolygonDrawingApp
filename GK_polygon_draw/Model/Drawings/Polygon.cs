using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GK_polygon_draw.Model.Drawings
{
    public class Polygon : IShape
    {
        public List<Point> Points => Edges.Select(e => e.StartPoint).ToList();
        public List<Line> Edges { get; set; }
        public int NumberOfPoints => Edges.Count;
        public Point movingPoint
        {
            get
            {
                var p = new Point(0, 0);
                foreach (var pt in Points)
                {
                    p.X += pt.X;
                    p.Y += pt.Y;
                }
                p.X = p.X / NumberOfPoints;
                p.Y = p.Y / NumberOfPoints;

                return p;
            }
        }

        public Polygon()
        {
            Edges = new List<Line>();
        }
        public IShape Collision(Point point)
        {
            IShape ret = movingPoint.Collision(point);
            if (ret != null)
                return this;
            foreach (var pt in Points)
            {
                ret = pt.Collision(point);
                if (ret != null) return ret;
            }

            foreach (var edge in Edges)
            {
                ret = edge.Collision(point);
                if (ret != null)
                    return ret;
            }
            return null;
        }
        public Point MovingPoint(Point point)
        {
            return movingPoint;
        }
        public Vector2 MovingVector(Point point, Point movingPoint)
        {
            return new Vector2(point.X - movingPoint.X, point.Y - movingPoint.Y);
        }
        public void Move(Vector2 vector)
        {
            foreach (var point in Points)
            {
                point.Move(vector);
            }
        }
        public void AddPoint(Point point)
        {
            if (NumberOfPoints == 0)
            {
                Edges.Add(new Line(point, null));
            }
            else
            {
                if (point != Edges[0].StartPoint)
                {
                    Edges.Last().EndPoint = point;
                    Edges.Add(new Line(point, null));
                }
                else
                {
                    Edges.Last().EndPoint = Edges[0].StartPoint;
                }
            }
        }
        public bool RemovePoint(Point point)
        {
            var item = Points.Find(p => Math.Abs(p.X - point.X) <= Point.R && Math.Abs(p.Y - point.Y) <= Point.R);
            if (item != null)
            {
                var edge1 = Edges.Find(e => e.StartPoint.X == item.X && e.StartPoint.Y == item.Y);
                var edge2 = Edges.Find(e => e.EndPoint.X == item.X && e.EndPoint.Y == item.Y);
                if (edge1 != null && edge2 != null)
                {
                    int index = Edges.FindIndex(e => e.StartPoint.X == item.X && item.Y == e.StartPoint.Y);
                    Edges.Insert(index, new Line(edge2.StartPoint, edge1.EndPoint));
                    foreach(var e in edge1.PerpEdges)
                    {
                        e.Constraint.DeletePerpendicular(edge1);
                    }
                    foreach (var e in edge2.PerpEdges)
                    {
                        e.Constraint.DeletePerpendicular(edge2);
                    }

                    Edges.Remove(edge1);
                    Edges.Remove(edge2);
                }
                return true;
            }
            return false;
        }
        public bool InsertPoint(Line edge)
        {
            foreach (var e in Edges)
            {
                if (e == edge)
                {
                    Point newP = new Point((edge.StartPoint.X + edge.EndPoint.X) / 2, (edge.StartPoint.Y + edge.EndPoint.Y) / 2);
                    int index = Edges.IndexOf(edge);
                    Edges.Insert(index, new Line(newP, edge.EndPoint));
                    Edges.Insert(index, new Line(edge.StartPoint, newP));

                    foreach (var item in edge.PerpEdges)
                    {
                        item.Constraint.DeletePerpendicular(edge);
                    }
                    Edges.Remove(edge);
                    return true;
                }
            }
            return false;

        }
        public Line GetLineWithStartPoint(Point point)
        {
            foreach (var e in Edges)
                if (point == e.StartPoint)
                    return e;
            return null;
        }
        public Line GetLineWithEndPoint(Point point)
        {
            foreach (var e in Edges)
                if (point == e.EndPoint)
                    return e;
            return null;
        }
    }
}
