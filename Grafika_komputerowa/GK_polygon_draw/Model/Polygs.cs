using GK_polygon_draw.Model.Drawings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model
{
    class Polygs
    {
        public List<Polygon> Polygons { get; set; }

        public Polygon CreatingPolygon { get; set; }

        public Polygs()
        {
            Polygons = new List<Polygon>();
            CreatingPolygon = null;
        }

        public void AddPolygon(Polygon poly)
        {
            Polygons.Add(poly);
        }

        public void RemovePolygon()
        {
            var item = Polygons.Find(p => p.NumberOfPoints < 3);
            if(item != null)
                Polygons.Remove(item);
        }
    }
}
