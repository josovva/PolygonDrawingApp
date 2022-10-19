using GK_polygon_draw.Model;
using GK_polygon_draw.Model.Drawings;
using GK_polygon_draw.Model.Relations;
using GK_polygon_draw.Model.Repos;
using GK_polygon_draw.View;
using System;
using System.Drawing;
using System.Windows.Forms;
using Point = GK_polygon_draw.Model.Drawings.Point;

namespace GK_polygon_draw.Presenter
{
    class DrawingLogic
    {
        public Polygs Polygons { get; set; }
        public Drawer Draw { get; set; }
        public Relations Rels { get; set; }
        private int State;
        private int Bresenham;
        private IShape MovingObject;

        public DrawingLogic(Polygs polygons, Drawer draw)
        {
            Polygons = polygons;
            Draw = draw;
            State = Bresenham = 0;
            MovingObject = null;
            Rels = new Relations();

            Draw.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            Draw.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            Draw.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            Draw.CreatingMode.CheckedChanged += new System.EventHandler(this.creatingMode_CheckedChanged);
            Draw.DeletingMode.CheckedChanged += new System.EventHandler(this.deletingMode_CheckedChanged);
            Draw.MovingMode.CheckedChanged += new System.EventHandler(this.movingMode_CheckedChanged);
            Draw.BresY.CheckedChanged += new System.EventHandler(this.bresenhamYes_CheckedChanged);
            Draw.BresN.CheckedChanged += new System.EventHandler(this.bresenhamNo_CheckedChanged);
            Draw.InsertMode.CheckedChanged += new System.EventHandler(this.insertMode_CheckedChanged);
            Draw.setLength.CheckedChanged += new System.EventHandler(this.setLgth_CheckedChanged);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (State)
                    {
                        case 0:
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
                                    if (Polygons.CreatingPolygon.Collision(point) == Polygons.CreatingPolygon.Points[0])
                                    {
                                        if (Polygons.CreatingPolygon.Points.Count < 3)
                                        {
                                            return;
                                        }
                                        Polygons.CreatingPolygon.Edges.Add(new Line(Polygons.CreatingPolygon.Points[Polygons.CreatingPolygon.NumberOfPoints - 1], Polygons.CreatingPolygon.Points[0]));
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
                                break;
                            }
                        case 1:
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var polyg in Polygons.Polygons)
                                    {
                                        var ret = polyg.RemovePoint(new Point(e.X, e.Y));
                                        if (ret == true)
                                            break;
                                    }
                                    Polygons.RemovePolygon();
                                    Draw.DrawPolygons(Polygons.Polygons);
                                    Draw.RefreshCanvas();
                                }
                                break;
                            }
                        case 2:
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var poly in Polygons.Polygons)
                                    {
                                        MovingObject = poly.Collision(new Point(e.X, e.Y));
                                        if (MovingObject != null)
                                            break;
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                foreach (var poly in Polygons.Polygons)
                                {
                                    foreach (var ed in poly.Edges)
                                    {
                                        var ret = ed.Collision(new Point(e.X, e.Y));
                                        if (ret != null)
                                        {
                                            poly.AddPointOnEdge(ed);
                                            Draw.DrawPolygons(Polygons.Polygons);
                                            Draw.RefreshCanvas();
                                            return;
                                        }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var poly in Polygons.Polygons)
                                    {
                                        foreach (var ed in poly.Edges)
                                        {
                                            var ret = ed.Collision(new Point(e.X, e.Y));
                                            if (ret != null)
                                            {
                                                SetLengthWin newForm = new SetLengthWin((float)Math.Sqrt(Math.Pow(ed.StartPoint.X - ed.EndPoint.X, 2) + Math.Pow(ed.StartPoint.Y - ed.EndPoint.Y, 2)));
                                                newForm.ShowDialog();
                                                Rels.AddRelation(new FixedLength(ed, newForm.setLgthVal));
                                                Draw.DrawPolygons(Polygons.Polygons);
                                                Draw.DrawLine(ed, Pens.Red);
                                                Draw.RefreshCanvas();
                                                return;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                    }
                    break;
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
                    if (Bresenham == 1)
                        Draw.DrawLineBresenham(new Line(prev, new Point(e.X, e.Y)));
                    else
                        Draw.DrawLine(new Line(prev, new Point(e.X, e.Y)));
                    Draw.RefreshCanvas();
                }
            }
            else if (State == 2 && MovingObject != null)
            {
                MovingObject.Move(e.X, e.Y);

                foreach (var poly in Polygons.Polygons)
                    poly.CountMovingPoint();
                Draw.DrawPolygons(Polygons.Polygons);
                foreach (var poly in Polygons.Polygons)
                {
                    Draw.DrawCenter(poly.movingPoint);
                }
                Draw.RefreshCanvas();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (State == 2)
            {
                MovingObject = null;
            }
        }

        private void creatingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 0;
            Draw.drawingAlgo.Enabled = true;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void deletingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 1;
            Draw.drawingAlgo.Enabled = false;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void movingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 2;
            MovingObject = null;
            Draw.drawingAlgo.Enabled = false;
            foreach (var polyg in Polygons.Polygons)
            {
                Draw.DrawCenter(polyg.movingPoint);
                Draw.RefreshCanvas();
            }
        }
        private void insertMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 3;
            Draw.drawingAlgo.Enabled = false;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void bresenhamYes_CheckedChanged(object sender, EventArgs e)
        {
            Bresenham = 1;
        }
        private void bresenhamNo_CheckedChanged(object sender, EventArgs e)
        {
            Bresenham = 0;
        }

        private void setLgth_CheckedChanged(object sender, EventArgs e)
        {
            State = 4;
            Draw.drawingAlgo.Enabled = false;
        }

    }
}
