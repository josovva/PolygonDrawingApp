using GK_polygon_draw.Model.Drawings;
using GK_polygon_draw.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Repos
{
    internal class Relations
    {
        public List<Relation> RelationsRepo { get; set; }

        public Relations()
        {
            RelationsRepo = new List<Relation>();
        }

        public void AddRelation(Relation relation)
        {
            RelationsRepo.Add(relation);
        }

        public void DeleteRelation(Line edge)
        {
            RelationsRepo.RemoveAll(r => r.CheckIfContainsEdge(edge));
        }
    }
}
