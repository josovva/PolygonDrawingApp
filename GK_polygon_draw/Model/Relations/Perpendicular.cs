using GK_polygon_draw.Model.Drawings;
using System.Collections.Generic;

namespace GK_polygon_draw.Model.Relations
{
    public class Perpendicular
    {
        public List<Relation<Line>> PerpEdges { get; set; }
        public void AddRelation(Line perpRel)
        {
            PerpEdges.Add(new Relation<Line>(perpRel));
        }
        public void DeleteRelation(Line line)
        {
            PerpEdges.RemoveAll(e => e.Constraint.StartPoint == line.StartPoint && e.Constraint.EndPoint == line.EndPoint);
        }
    }
}
