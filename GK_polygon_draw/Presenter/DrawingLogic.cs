using GK_polygon_draw.Model;
using GK_polygon_draw.Model.Drawings;
using GK_polygon_draw.View;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Point = GK_polygon_draw.Model.Drawings.Point;

namespace GK_polygon_draw.Presenter
{
    class DrawingLogic
    {
        public Polygs Polygons { get; set; }
        public Drawer Draw { get; set; }
        private int State;
        private int Bresenham;
        private IShape MovingObject;
        private Point MovPoint;

        public DrawingLogic(Polygs polygons, Drawer draw)
        {
            Polygons = polygons;
            Draw = draw;
            State = Bresenham = 0;
            MovingObject = null;

            #region EVENT HANDLERS
            Draw.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            Draw.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            Draw.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            Draw.CreatingMode.CheckedChanged += new System.EventHandler(this.CreatingMode_CheckedChanged);
            Draw.DeletingMode.CheckedChanged += new System.EventHandler(this.DeletingMode_CheckedChanged);
            Draw.MovingMode.CheckedChanged += new System.EventHandler(this.MovingMode_CheckedChanged);
            Draw.BresY.CheckedChanged += new System.EventHandler(this.BresenhamYes_CheckedChanged);
            Draw.BresN.CheckedChanged += new System.EventHandler(this.BresenhamNo_CheckedChanged);
            Draw.InsertMode.CheckedChanged += new System.EventHandler(this.InsertMode_CheckedChanged);
            Draw.setLength.CheckedChanged += new System.EventHandler(this.SetLgth_CheckedChanged);
            #endregion
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (State)
                    {
                        case 0: //DrawingMode
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
                                    if (Math.Abs(Polygons.CreatingPolygon.Points[0].X - point.X) < Point.R / 2 && Math.Abs(Polygons.CreatingPolygon.Points[0].Y - point.Y) < Point.R / 2)
                                    {
                                        if (Polygons.CreatingPolygon.Points.Count < 3)
                                        {
                                            return;
                                        }
                                        Polygons.CreatingPolygon.AddPoint(Polygons.CreatingPolygon.Points[0]);
                                        Polygons.AddPolygon(Polygons.CreatingPolygon);
                                        Draw.DrawPolygons(Polygons.Polygons);
                                        Polygons.CreatingPolygon = null;
                                        Draw.RefreshCanvas();
                                        return;
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
                        case 1: //DeletingMode
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
                        case 2: //MovingMode
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var poly in Polygons.Polygons)
                                    {
                                        MovingObject = poly.Collision(new Point(e.X, e.Y));
                                        if (MovingObject != null)
                                        {
                                            MovPoint = MovingObject.MovingPoint(new Point(e.X, e.Y));
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        case 3: //InsertMode
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
                        case 4: //SetLengthMode
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
                                                float initLgth = (float)Math.Sqrt(Math.Pow(ed.StartPoint.X - ed.EndPoint.X, 2) + Math.Pow(ed.StartPoint.Y - ed.EndPoint.Y, 2));
                                                SetLengthWin newForm = new SetLengthWin(initLgth);
                                                newForm.ShowDialog();
                                                float newLgth = newForm.setLgthVal;
                                                ed.AddLength(newLgth);

                                                Vector2 vec = new Vector2(ed.EndPoint.X - ed.StartPoint.X, ed.EndPoint.Y - ed.StartPoint.Y);
                                                Vector2 vecMultiplied = Vector2.Multiply(vec, newLgth / initLgth);
                                                vec = Vector2.Subtract(vecMultiplied, vec);
                                                ed.EndPoint.Move(vec);

                                                Draw.DrawPolygons(Polygons.Polygons);
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
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (State)
            {
                case 0: //Creating Mode
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
                        break;
                    }
                case 2: //Moving Mode
                    {
                        if (MovingObject != null)
                        {
                            var movingVec = MovingObject.MovingVector(new Point(e.X, e.Y), MovPoint);
                            if (MovingObject is Point p)
                                MoveWithConstraints(p, movingVec);
                            else if (MovingObject is Line l)
                            {
                                MoveWithConstraints(l, movingVec);
                                MovPoint.Move(movingVec);
                            }
                            else
                            {
                                MovingObject.Move(movingVec);
                                MovPoint.Move(movingVec);
                            }

                            Draw.DrawPolygons(Polygons.Polygons);
                            foreach (var poly in Polygons.Polygons)
                            {
                                Draw.DrawCenter(poly.movingPoint);
                            }
                            Draw.RefreshCanvas();
                        }
                        break;
                    }
            }
        }
        private void MoveWithConstraints(Point point, Vector2 vector)
        {
            Queue<(Point point, Vector2 vector)> queue = new Queue<(Point, Vector2)>();
            HashSet<Point> processed = new HashSet<Point>();

            Polygon poly = Polygons.GetPolygonWithPoint(point);

            queue.Enqueue((point, vector));

            while (queue.Count > 0)
            {
                var currValues = queue.Dequeue();
                Line FirstEdge = poly.GetLineWithStartPoint(currValues.point);
                Line SecEdge = poly.GetLineWithEndPoint(currValues.point);

                if (FirstEdge.FixedLgth != null && !processed.Contains(FirstEdge.EndPoint))
                {
                    var u = new Vector2(currValues.point.X - FirstEdge.EndPoint.X, currValues.point.Y - FirstEdge.EndPoint.Y) + currValues.vector;
                    var v = Vector2.Normalize(u) * FirstEdge.FixedLgth.GetLength();
                    var movingVec = u - v;
                    queue.Enqueue((FirstEdge.EndPoint, movingVec));
                }
                if (SecEdge.FixedLgth != null && !processed.Contains(SecEdge.StartPoint))
                {
                    var u = new Vector2(currValues.point.X - SecEdge.StartPoint.X, currValues.point.Y - SecEdge.StartPoint.Y) + currValues.vector;
                    var v = Vector2.Normalize(u) * SecEdge.FixedLgth.GetLength();
                    var movingVec = u - v;
                    queue.Enqueue((SecEdge.StartPoint, movingVec));
                }
                currValues.point.Move(currValues.vector);
                processed.Add(currValues.point);
            }
        }

        private void MoveWithConstraints(Line line, Vector2 vector)
        {
            Queue<(Point point, Vector2 vector)> queue = new Queue<(Point, Vector2)>();
            HashSet<Point> processed = new HashSet<Point>();

            Polygon poly = Polygons.GetPolygonWithPoint(line.StartPoint);

            queue.Enqueue((line.StartPoint, vector));
            queue.Enqueue((line.EndPoint, vector));
            processed.Add(line.EndPoint);

            while (queue.Count > 0)
            {
                var currValues = queue.Dequeue();
                Line FirstEdge = poly.GetLineWithStartPoint(currValues.point);
                Line SecEdge = poly.GetLineWithEndPoint(currValues.point);

                if (FirstEdge.FixedLgth != null && !processed.Contains(FirstEdge.EndPoint))
                {
                    var u = new Vector2(currValues.point.X - FirstEdge.EndPoint.X, currValues.point.Y - FirstEdge.EndPoint.Y) + currValues.vector;
                    var v = Vector2.Normalize(u) * FirstEdge.FixedLgth.GetLength();
                    var movingVec = u - v;
                    queue.Enqueue((FirstEdge.EndPoint, movingVec));
                }
                if (SecEdge.FixedLgth != null && !processed.Contains(SecEdge.StartPoint))
                {
                    var u = new Vector2(currValues.point.X - SecEdge.StartPoint.X, currValues.point.Y - SecEdge.StartPoint.Y) + currValues.vector;
                    var v = Vector2.Normalize(u) * SecEdge.FixedLgth.GetLength();
                    var movingVec = u - v;
                    queue.Enqueue((SecEdge.StartPoint, movingVec));
                }
                currValues.point.Move(currValues.vector);
                processed.Add(currValues.point);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (State == 2)
            {
                MovingObject = null;
                MovPoint = null;
            }
        }

        #region CHANGE OF MODE
        private void CreatingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 0;
            Draw.drawingAlgo.Enabled = true;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void DeletingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 1;
            Draw.drawingAlgo.Enabled = false;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void MovingMode_CheckedChanged(object sender, EventArgs e)
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
        private void InsertMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 3;
            Draw.drawingAlgo.Enabled = false;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void BresenhamYes_CheckedChanged(object sender, EventArgs e)
        {
            Bresenham = 1;
        }
        private void BresenhamNo_CheckedChanged(object sender, EventArgs e)
        {
            Bresenham = 0;
        }
        private void SetLgth_CheckedChanged(object sender, EventArgs e)
        {
            State = 4;
            Draw.drawingAlgo.Enabled = false;
        }
        #endregion
    }
}
