using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_polygon_draw.Model.Drawings
{
    public interface IShape
    {
        public void Move(float MoveX, float MoveY);
        public IShape Collision(Point point);
    }

}
