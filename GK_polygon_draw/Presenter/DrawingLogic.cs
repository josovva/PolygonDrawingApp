using GK_polygon_draw.Model;
using GK_polygon_draw.Model.Drawings;
using GK_polygon_draw.Model.Relations;
using GK_polygon_draw.View;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int ModyfingState;

        private IShape MovingObject;
        private Point MovPoint;
        private Line EdgeF = null;
        private Line modifyConstraintsLine = null;

        public DrawingLogic(Polygs polygons, Drawer draw)
        {
            Polygons = polygons;
            Draw = draw;
            State = Bresenham = ModyfingState = 0;
            MovingObject = null;
            InitScene();
            Draw.DrawPolygons(Polygons.Polygons);

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
            Draw.SetLength.CheckedChanged += new System.EventHandler(this.SetLgth_CheckedChanged);
            Draw.DelLength.CheckedChanged += new System.EventHandler(this.ModifyConstraints_CheckedChanged);
            Draw.Perpendicular.CheckedChanged += new System.EventHandler(this.MakePerpendicular_CheckedChanged);
            Draw.ModifyLength.CheckedChanged += new System.EventHandler(this.ModifyLength_CheckedChanged);
            Draw.ModifyPerp.CheckedChanged += new System.EventHandler(this.ModifyPerp_CheckedChanged);
            Draw.DeleteConstraint.Click += new System.EventHandler(this.DeleteConstraint_Click);
            #endregion
        }

         void InitScene()
        {
            Polygon polygon1 = new Polygon();
            polygon1.AddPoint(new Point(339, 76));
            polygon1.AddPoint(new Point(266, 391));
            polygon1.AddPoint(new Point(593, 362));
            polygon1.AddPoint(new Point(570, 96));
            polygon1.AddPoint(polygon1.Points[0]);

            polygon1.Edges[2].AddLength(267);
            polygon1.Edges[2].AddPerpendicular(polygon1.Edges[1]);
            polygon1.Edges[1].AddPerpendicular(polygon1.Edges[2]);

            Polygon polygon2 = new Polygon();
            polygon2.AddPoint(new Point(700, 310));
            polygon2.AddPoint(new Point(833, 155));
            polygon2.AddPoint(new Point(944, 367));
            polygon2.AddPoint(polygon2.Points[0]);

            polygon2.Edges[1].AddLength(239);
            polygon2.Edges[2].AddPerpendicular(polygon1.Edges[0]);
            polygon1.Edges[0].AddPerpendicular(polygon2.Edges[2]);


            Polygons.AddPolygon(polygon1);
            Polygons.AddPolygon(polygon2);
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
                                        foreach (var pt in polyg.Points)
                                        {
                                            Point ret = (Point)pt.Collision(new Point(e.X, e.Y));
                                            if (ret != null)
                                            {
                                                polyg.RemovePoint(ret);
                                                Polygons.RemovePolygon();
                                                Draw.DrawPolygons(Polygons.Polygons);
                                                Draw.RefreshCanvas();
                                                return;
                                            }
                                        }
                                    }
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
                                            poly.InsertPoint(ed);
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
                                            var ret = (Line)ed.Collision(new Point(e.X, e.Y));
                                            if (ret != null)
                                            {
                                                float initLgth = (float)Math.Sqrt(Math.Pow(ed.StartPoint.X - ed.EndPoint.X, 2) + Math.Pow(ed.StartPoint.Y - ed.EndPoint.Y, 2));
                                                SetLengthWin newForm = new SetLengthWin(initLgth);
                                                Draw.DrawLine(ret, Pens.Red);
                                                Draw.DrawPoint(ret.StartPoint, Brushes.Red);
                                                Draw.DrawPoint(ret.EndPoint, Brushes.Red);
                                                Draw.RefreshCanvas();
                                                newForm.ShowDialog();
                                                float newLgth = newForm.setLgthVal;
                                                if (newLgth > 0)
                                                {
                                                    ed.AddLength(newLgth);

                                                    Vector2 vec = new Vector2(ed.EndPoint.X - ed.StartPoint.X, ed.EndPoint.Y - ed.StartPoint.Y);
                                                    Vector2 vecMultiplied = Vector2.Multiply(vec, newLgth / initLgth);
                                                    vec = Vector2.Subtract(vecMultiplied, vec);
                                                    MoveWithConstraints(ed.EndPoint, vec);

                                                }
                                                Draw.DrawPolygons(Polygons.Polygons);
                                                Draw.RefreshCanvas();
                                                return;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 5: //ModyfingConstraintsMode
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var poly in Polygons.Polygons)
                                    {
                                        foreach (var ed in poly.Edges)
                                        {
                                            Line ret = (Line)ed.Collision(new Point(e.X, e.Y));
                                            if (ret != null)
                                            {
                                                modifyConstraintsLine = ret;
                                                Draw.DrawPolygons(Polygons.Polygons);
                                                if (ModyfingState == 0)
                                                {
                                                    var list = new List<FixedLength>();
                                                    list.Add(ret.FixedLgth);
                                                    Draw.ConstraintList.DataSource = list;
                                                }
                                                else
                                                {
                                                    Draw.ConstraintList.DataSource = ret.PerpEdges;
                                                    foreach (var item in ret.PerpEdges)
                                                    {
                                                        Draw.DrawLine(item.Constraint, Pens.PaleVioletRed);
                                                        Draw.DrawPoint(item.Constraint.StartPoint, Brushes.PaleVioletRed);
                                                        Draw.DrawPoint(item.Constraint.EndPoint, Brushes.PaleVioletRed);
                                                    }

                                                }
                                                Draw.DrawLine(ret, Pens.Red);
                                                Draw.DrawPoint(ret.StartPoint, Brushes.Red);
                                                Draw.DrawPoint(ret.EndPoint, Brushes.Red);
                                                Draw.RefreshCanvas();
                                                return;
                                            }
                                        }
                                    }
                                    Draw.DrawPolygons(Polygons.Polygons);
                                    Draw.RefreshCanvas();
                                    Draw.ConstraintList.DataSource = null;
                                    modifyConstraintsLine = null;
                                }
                                break;
                            }
                        case 6: //MakePerpendicular
                            {
                                if (e.Button == MouseButtons.Left)
                                {
                                    foreach (var poly in Polygons.Polygons)
                                    {
                                        foreach (var ed in poly.Edges)
                                        {
                                            var ret = (Line)ed.Collision(new Point(e.X, e.Y));
                                            if (ret != null)
                                            {
                                                Draw.DrawLine(ret, Pens.Red);
                                                Draw.DrawPoint(ret.StartPoint, Brushes.Red);
                                                Draw.DrawPoint(ret.EndPoint, Brushes.Red);

                                                if (EdgeF == null)
                                                    EdgeF = ret;
                                                else
                                                {
                                                    EdgeF.AddPerpendicular(ret);
                                                    ret.AddPerpendicular(EdgeF);
                                                    //MakePerpendicular(EdgeF, ret);
                                                    MoveWithConstraints(EdgeF, Vector2.Zero);
                                                    EdgeF = null;
                                                    Draw.DrawPolygons(Polygons.Polygons);
                                                    Draw.RefreshCanvas();
                                                }
                                                Draw.RefreshCanvas();
                                                return;
                                            }
                                        }
                                    }
                                    Draw.DrawPolygons(Polygons.Polygons);
                                    Draw.RefreshCanvas();
                                    EdgeF = null;
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
                            {
                                MoveWithConstraints(p, movingVec);
                            }
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
                            foreach (var polygon in Polygons.Polygons)
                            {
                                Draw.DrawCenter(polygon.movingPoint);
                            }
                            Draw.RefreshCanvas();
                        }
                        break;
                    }
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

        private void MoveWithConstraints(Point point, Vector2 vector)
        {
            Queue<(Point point, Vector2 vector)> queue = new Queue<(Point, Vector2)>();
            HashSet<Point> processed = new HashSet<Point>();

            Queue<Line> queuePerpendicular = new Queue<Line>();
            HashSet<Line> processedPerpendicular = new HashSet<Line>();

            Polygon poly = Polygons.GetPolygonWithPoint(point);

            queue.Enqueue((point, vector));

            while (queue.Count > 0)
            {
                var currValues = queue.Dequeue();
                Line FirstEdge = poly.GetLineWithStartPoint(currValues.point);
                Line SecEdge = poly.GetLineWithEndPoint(currValues.point);

                if (!queuePerpendicular.Contains(FirstEdge))
                    queuePerpendicular.Enqueue(FirstEdge);
                if (!queuePerpendicular.Contains(SecEdge))
                    queuePerpendicular.Enqueue(SecEdge);

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

            while (queuePerpendicular.Count > 0)
            {
                var edge = queuePerpendicular.Dequeue();
                processedPerpendicular.Add(edge);
                if (edge != null)
                {
                    foreach (var item in edge.PerpEdges)
                    {
                        if (!processedPerpendicular.Contains(item.Constraint))
                        {
                            if (item.Constraint.StartPoint == edge.EndPoint || item.Constraint.EndPoint == edge.StartPoint)
                            {
                                MakePerpendicularMoveSide(item.Constraint, edge);
                            }
                            else
                            {
                                MakePerpendicular(item.Constraint, edge);
                            }

                            queuePerpendicular.Enqueue(item.Constraint);
                            processedPerpendicular.Add(item.Constraint);

                            
                        }
                        Line FirstEdge = poly.GetLineWithStartPoint(item.Constraint.EndPoint);
                        Line SecEdge = poly.GetLineWithEndPoint(item.Constraint.StartPoint);
                        if (!queuePerpendicular.Contains(FirstEdge) && !processedPerpendicular.Contains(FirstEdge))
                            queuePerpendicular.Enqueue(FirstEdge);
                        if (!queuePerpendicular.Contains(SecEdge) && !processedPerpendicular.Contains(SecEdge))
                            queuePerpendicular.Enqueue(SecEdge);
                    }
                }

            }
        }

        private void MoveWithSetLength(Point point, Vector2 vector)
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

            Queue<Line> queuePerpendicular = new Queue<Line>();
            HashSet<Line> processedPerpendicular = new HashSet<Line>();

            Polygon poly = Polygons.GetPolygonWithPoint(line.StartPoint);

            queue.Enqueue((line.StartPoint, vector));
            queue.Enqueue((line.EndPoint, vector));
            processed.Add(line.EndPoint);
            queuePerpendicular.Enqueue(line);

            while (queue.Count > 0)
            {
                var currValues = queue.Dequeue();
                Line FirstEdge = poly.GetLineWithStartPoint(currValues.point);
                Line SecEdge = poly.GetLineWithEndPoint(currValues.point);

                if (!queuePerpendicular.Contains(FirstEdge))
                    queuePerpendicular.Enqueue(FirstEdge);
                if (!queuePerpendicular.Contains(SecEdge))
                    queuePerpendicular.Enqueue(SecEdge);

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

                while (queuePerpendicular.Count > 0)
                {
                    var edge = queuePerpendicular.Dequeue();
                    processedPerpendicular.Add(edge);
                    foreach (var item in edge.PerpEdges)
                    {
                        if (!processedPerpendicular.Contains(item.Constraint))
                        {
                            if (item.Constraint.StartPoint == edge.EndPoint || item.Constraint.EndPoint == edge.StartPoint || (item.Constraint.FixedLgth == null))
                            {
                                var cloneItem = new Line(item.Constraint.StartPoint, item.Constraint.EndPoint);
                                cloneItem.AddLength((float)Math.Sqrt(Math.Pow(cloneItem.StartPoint.X - cloneItem.EndPoint.X, 2) + Math.Pow(cloneItem.StartPoint.Y - cloneItem.EndPoint.Y, 2)));
                                MakePerpendicularMoveSide(cloneItem, edge);
                                item.Constraint.StartPoint.X = cloneItem.StartPoint.X;
                                item.Constraint.EndPoint.X = cloneItem.EndPoint.X;
                                item.Constraint.StartPoint.Y = cloneItem.StartPoint.Y;
                                item.Constraint.EndPoint.Y = cloneItem.EndPoint.Y;
                            }
                            else
                                MakePerpendicular(item.Constraint, edge);
                            queuePerpendicular.Enqueue(item.Constraint);
                            processedPerpendicular.Add(item.Constraint);
                        }
                    }
                }
            }
        }

        private void MakePerpendicularMoveMiddle(Line edgeF, Line edgeS)
        {
            Point u, v, w;

            if (edgeF.EndPoint == edgeS.StartPoint)
            {
                v = edgeS.StartPoint;
                u = edgeS.EndPoint;
                w = edgeF.StartPoint;
            }
            else
            {
                v = edgeS.EndPoint;
                u = edgeF.EndPoint;
                w = edgeS.StartPoint;
            }
            Point middlePoint = new((u.X + w.X) / 2, (u.Y + w.Y) / 2);

            Vector2 vecA = new(w.X - middlePoint.X, w.Y - middlePoint.Y);
            Vector2 vecV = new(v.X - middlePoint.X, v.Y - middlePoint.Y);

            Vector2 vecR = v.X == middlePoint.X && v.Y == middlePoint.Y ? new Vector2(-vecA.Y, vecA.X) : Vector2.Normalize(new(v.X - middlePoint.X, v.Y - middlePoint.Y)) * vecA.Length();
            v.Move(vecR - vecV);
        }

        private void MakePerpendicularMoveSide(Line edgeF, Line edgeS)
        {
            if (edgeF.StartPoint != edgeS.EndPoint)
            {
                Point u = edgeF.StartPoint, v = edgeF.EndPoint, w = edgeS.StartPoint, x = edgeS.EndPoint;
                var firstVector = new Vector2(v.X - u.X, v.Y - u.Y);
                var secondVector = new Vector2(x.X - w.X, x.Y - w.Y);

                var Perpendicular = new Vector2(-secondVector.Y, secondVector.X);
                Perpendicular = Vector2.Normalize(Perpendicular) * firstVector.Length();

                float cos = Vector2.Dot(firstVector, Perpendicular) / (firstVector.Length() * Perpendicular.Length());

                if (cos >= 0)
                    Perpendicular = -Perpendicular;

                //ToMove.Move(Perpendicular + firstVector);
                MoveWithSetLength(u, Perpendicular + firstVector);
            }
            else
            {
                Point v = edgeF.StartPoint, u = edgeF.EndPoint, x = edgeS.StartPoint, w = edgeS.EndPoint;
                var firstVector = new Vector2(v.X - u.X, v.Y - u.Y);
                var secondVector = new Vector2(x.X - w.X, x.Y - w.Y);
                var Perpendicular = new Vector2(-secondVector.Y, secondVector.X);
                Perpendicular = Vector2.Normalize(Perpendicular) * firstVector.Length();
                float cos = Vector2.Dot(firstVector, Perpendicular) / (firstVector.Length() * Perpendicular.Length());
                if (cos >= 0)
                    Perpendicular = -Perpendicular;
                MoveWithSetLength(u, Perpendicular + firstVector);
            }

        }

        private void MakePerpendicular(Line edgeF, Line edgeS)
        {
            if ((edgeF.StartPoint == edgeS.EndPoint || edgeF.EndPoint == edgeS.StartPoint) && edgeF.FixedLgth == null && edgeS.FixedLgth == null)
            {
                MakePerpendicularMoveMiddle(edgeF, edgeS);
            }
            else
            {
                MakePerpendicularMoveSide(edgeF, edgeS);
            }
        }
        #region CHANGE OF MODE
        private void CreatingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 0;
            Draw.DrawingAlgo.Enabled = true;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void DeletingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 1;
            Draw.DrawingAlgo.Enabled = false;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void MovingMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 2;
            MovingObject = null;
            Draw.DrawingAlgo.Enabled = false;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;

            foreach (var polyg in Polygons.Polygons)
            {
                Draw.DrawCenter(polyg.movingPoint);
                Draw.RefreshCanvas();
            }
        }
        private void InsertMode_CheckedChanged(object sender, EventArgs e)
        {
            State = 3;
            Draw.DrawingAlgo.Enabled = false;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;

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
            Draw.DrawingAlgo.Enabled = false;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void ModifyConstraints_CheckedChanged(object sender, EventArgs e)
        {
            State = 5;
            Draw.ModifyingConstraints.Enabled = true;
            Draw.DrawingAlgo.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = true;
            modifyConstraintsLine = null;
            EdgeF = null;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void MakePerpendicular_CheckedChanged(object sender, EventArgs e)
        {
            State = 6;
            Draw.DrawingAlgo.Enabled = false;
            Draw.ModifyingConstraints.Enabled = false;
            Draw.ConstraintList.DataSource = null;
            Draw.DeleteConstraint.Enabled = false;
            EdgeF = null;
            Draw.DrawPolygons(Polygons.Polygons);
            Draw.RefreshCanvas();
        }
        private void ModifyLength_CheckedChanged(object sender, EventArgs e)
        {

            Draw.DrawPolygons(Polygons.Polygons);
            if (modifyConstraintsLine != null)
            {

                var list = new List<FixedLength>();
                list.Add(modifyConstraintsLine.FixedLgth);
                Draw.ConstraintList.DataSource = list;

                Draw.DrawLine(modifyConstraintsLine, Pens.Red);
                Draw.DrawPoint(modifyConstraintsLine.StartPoint, Brushes.Red);
                Draw.DrawPoint(modifyConstraintsLine.EndPoint, Brushes.Red);
            }
            Draw.RefreshCanvas();

            ModyfingState = 0;
            Draw.DrawingAlgo.Enabled = false;
        }
        private void ModifyPerp_CheckedChanged(object sender, EventArgs e)
        {
            Draw.DrawPolygons(Polygons.Polygons);
            if (modifyConstraintsLine != null)
            {
                Draw.ConstraintList.DataSource = null;
                Draw.ConstraintList.DataSource = modifyConstraintsLine.PerpEdges;
                foreach (var ed in modifyConstraintsLine.PerpEdges)
                {
                    Draw.DrawLine(ed.Constraint, Pens.PaleVioletRed);
                    Draw.DrawPoint(ed.Constraint.StartPoint, Brushes.PaleVioletRed);
                    Draw.DrawPoint(ed.Constraint.EndPoint, Brushes.PaleVioletRed);
                }

                Draw.DrawLine(modifyConstraintsLine, Pens.Red);
                Draw.DrawPoint(modifyConstraintsLine.StartPoint, Brushes.Red);
                Draw.DrawPoint(modifyConstraintsLine.EndPoint, Brushes.Red);

            }
            Draw.RefreshCanvas();
            ModyfingState = 1;
            Draw.DrawingAlgo.Enabled = false;
        }
        private void DeleteConstraint_Click(object sender, EventArgs e)
        {
            if (modifyConstraintsLine != null)
            {
                var item = Draw.ConstraintList.SelectedItem;
                if (ModyfingState == 0 && item != null)
                {
                    modifyConstraintsLine.DeleteLength();
                    Draw.ConstraintList.DataSource = null;
                    var list = new List<FixedLength>();
                    list.Add(modifyConstraintsLine.FixedLgth);
                    Draw.ConstraintList.DataSource = list;
                }
                else
                {
                    foreach (var constr in modifyConstraintsLine.PerpEdges)
                    {
                        constr.Constraint.DeletePerpendicular((Perpendicular)item);
                    }
                    modifyConstraintsLine.DeletePerpendicular((Perpendicular)item);
                    Draw.ConstraintList.DataSource = null;
                    Draw.ConstraintList.DataSource = modifyConstraintsLine.PerpEdges;
                }

                Draw.DrawPolygons(Polygons.Polygons);
                if (ModyfingState == 0)
                {
                    var list = new List<FixedLength>();
                    list.Add(modifyConstraintsLine.FixedLgth);
                    Draw.ConstraintList.DataSource = list;
                }
                else
                {
                    Draw.ConstraintList.DataSource = modifyConstraintsLine.PerpEdges;
                    foreach (var ed in modifyConstraintsLine.PerpEdges)
                    {
                        Draw.DrawLine(ed.Constraint, Pens.PaleVioletRed);
                        Draw.DrawPoint(ed.Constraint.StartPoint, Brushes.PaleVioletRed);
                        Draw.DrawPoint(ed.Constraint.EndPoint, Brushes.PaleVioletRed);
                    }

                }
                Draw.DrawLine(modifyConstraintsLine, Pens.Red);
                Draw.DrawPoint(modifyConstraintsLine.StartPoint, Brushes.Red);
                Draw.DrawPoint(modifyConstraintsLine.EndPoint, Brushes.Red);
                Draw.RefreshCanvas();
            }
        }

        #endregion
    }
}
