﻿using GK_polygon_draw.Model.Drawings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Relations
{
    public abstract class Relation
    {
        public Line firstLine { get; set; }

        protected Relation(Line firstLine)
        {
            this.firstLine = firstLine;
        }

        public virtual bool CheckIfContainsEdge(Line edge) { return edge == firstLine ? true : false; }

    }
}
