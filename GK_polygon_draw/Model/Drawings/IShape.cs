using System.Numerics;

namespace GK_polygon_draw.Model.Drawings
{
    public interface IShape
    {
        public IShape Collision(Point point);
        public Point MovingPoint(Point point);
        public Vector2 MovingVector(Point point, Point movingPoint);
        public void Move(Vector2 vector);
    }

}
