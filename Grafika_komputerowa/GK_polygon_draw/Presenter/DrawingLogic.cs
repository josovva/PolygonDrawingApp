using GK_polygon_draw.Model;
using GK_polygon_draw.Model.Drawings;
using GK_polygon_draw.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = GK_polygon_draw.Model.Drawings.Point;

namespace GK_polygon_draw.Presenter
{
    class DrawingLogic
    {
        public Polygs Polygons { get; set; }
        public Drawer Draw { get; set; }
        private int State;
        private IShape MovingObject;

        public DrawingLogic(Polygs polygons, Drawer draw)
        {
            Polygons = polygons;
            Draw = draw;
            State = 0;
            MovingObject = null;

            Draw.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            Draw.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            Draw.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            Draw.CreatingMode.CheckedChanged += new System.EventHandler(this.creatingMode_CheckedChanged);
            Draw.DeletingMode.CheckedChanged += new System.EventHandler(this.deletingMode_CheckedChanged);
            Draw.MovingMode.CheckedChanged += new System.EventHandler(this.movingMode_CheckedChanged);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(State == 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point point = new Point(e.X, e.Y);
                    if (Polygons.CreatingPolygon == null)
                    {
                        Polygons.CreatingPolygon = new Polygon();
                        Draw.DrawPoint(point);
                        Polygons.CreatingPolygon.AddPoint(point);
                    }
                    else
                    {
                        if (Math.Abs(point.X - Polygons.CreatingPolygon.Points[0].X) < Point.R && Math.Abs(point.Y - Polygons.CreatingPolygon.Points[0].Y) < Point.R)
                        {
                            if (Polygons.CreatingPolygon.Points.Count < 3)
                            {
                                return;
                            }
                            Polygons.CreatingPolygon.Edges.Add(new Line(point, Polygons.CreatingPolygon.Points[0]));
                            Polygons.AddPolygon(Polygons.CreatingPolygon);
                            Draw.DrawPolygons(Polygons.Polygons);
                            Polygons.CreatingPolygon = null;
                            Draw.RefreshCanvas();
                        }
                        else
                        {
                            Draw.DrawPoint(point);
                            Draw.DrawLine(new Line(Polygons.CreatingPolygon.Points[Polygons.CreatingPolygon.NumberOfPoints - 1], point));
                            Polygons.CreatingPolygon.AddPoint(point);
                        }
                    }
                }
            }
            else if(State == 1)
            {
                if(e.Button == MouseButtons.Left)
                {
                    foreach(var polyg in Polygons.Polygons)
                    {
                        var ret = polyg.RemovePoint(new Point(e.X,e.Y));
                        if (ret == true)
                            break;
                    }
                    Polygons.RemovePolygon();
                    Draw.DrawPolygons(Polygons.Polygons);
                    Draw.RefreshCanvas();
                }
            }
            else if(State == 2)
            {
                if(e.Button == MouseButtons.Left)
                {             
                    foreach(var poly in Polygons.Polygons)
                    {
                        MovingObject = poly.Collision(new Point(e.X,e.Y));
                        if (MovingObject != null)
                            break;
                    }           
                }
            }           
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (State == 0)
            {
                Draw.DrawPolygons(Polygons.Polygons);
                if (Polygons.CreatingPolygon != null)
                {
                    Point prev = Draw.DrawPolygon(Polygons.CreatingPolygon);
                    Draw.DrawLine(new Line(prev, new Point(e.X, e.Y)));
                    Draw.RefreshCanvas();
                }
            }
            else if(State == 2 && MovingObject != null)
            {
                MovingObject.Move(e.X, e.Y);

                foreach (var poly in Polygons.Polygons)
                    poly.CountMovingPoint();
                Draw.DrawPolygons(Polygons.Polygons);
                foreach(var poly in Polygons.Polygons)
                {
                    Draw.DrawCenter(poly.movingPoint);
                }
                Draw.RefreshCanvas();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(State == 2)
            {

                MovingObject = null;
            }
        }

        private void creatingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 0;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void deletingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 1;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void movingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 2;
            MovingObject = null;
            foreach(var polyg in Polygons.Polygons)
            {
                Draw.DrawCenter(polyg.movingPoint);
                Draw.RefreshCanvas();
            }
        }
    }
}
