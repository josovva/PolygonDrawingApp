using GK_polygon_draw.Model.Drawings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Relations
{
    public class FixedLength : Relation
    {
        public float Length { get; set; }

        public FixedLength(Line edge, float length) : base(edge)
        {
            Length = length;
        }
    }
}
