using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public interface IShape
    {
        public void Move(Vector2 vector);
        public Point MovingPoint(Point point);
        public Vector2 MovingVector(Point point, Point movingPoint);
        public IShape Collision(Point point);
    }

}
