using GK_polygon_draw.Model.Drawings;
using System.Collections.Generic;

namespace GK_polygon_draw.Model.Relations
{
    public class Perpendicular : Relation<Line>
    {
        private static int GlobalId = 1;
        private static int Counter = 1;
        public int Id { get; }
        public Perpendicular(Line Constraint) : base(Constraint)
        {
            if (Counter % 2 == 0)
            {
                Id = GlobalId++;
            }
            else
            {
                Id = GlobalId;
            }
            Counter++;
        }
        public override string ToString()
        {
            return "Perpendicular relation no: " + Id.ToString();
        }

    }
}
