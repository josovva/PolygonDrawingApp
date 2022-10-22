using GK_polygon_draw.Model.Drawings;

namespace GK_polygon_draw.Model.Relations
{
    public class Relation<T>
    {
        public T Constraint { get; set; }

        public Relation(T Constraint)
        {
            this.Constraint = Constraint;
        }

    }
}
