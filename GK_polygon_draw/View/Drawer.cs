﻿using GK_polygon_draw.Model.Drawings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Point = GK_polygon_draw.Model.Drawings.Point;

namespace GK_polygon_draw.View
{
    public partial class Drawer : Form
    {
        Bitmap bitmap;
        public PictureBox Canvas => canvas;
        public RadioButton CreatingMode => creatingMode;
        public RadioButton DeletingMode => deletingMode;
        public RadioButton MovingMode => movingMode;
        public RadioButton InsertMode => insertMode;
        public RadioButton BresY => bresenhamYes;
        public RadioButton BresN => bresenhamNo;
        public GroupBox drawingAlgo => DrawingAlgorithm;
        public RadioButton setLength => setLgthButton;

        public Drawer()
        {
            InitializeComponent();
            creatingMode.Checked = true;
            bresenhamNo.Checked = true;
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = bitmap;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Pink);
            }

            canvas.Refresh();
        }

        public void DrawPoint(Point point)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Black, point.X - Point.R / 2, point.Y - Point.R / 2, Point.R, Point.R);
            }
        }

        public void DrawCenter(Point point)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(Brushes.Red, 3);
                g.DrawLine(pen, point.X - Point.R, point.Y - Point.R, point.X + Point.R, point.Y + Point.R);
                g.DrawLine(pen, point.X - Point.R, point.Y + Point.R, point.X + Point.R, point.Y - Point.R);
            }
        }

        public void DrawLine(Line line)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                if (line.FixedLgth != null)
                {
                    var length = line.FixedLgth.GetLength();
                    g.DrawString(length.ToString(), SystemFonts.MessageBoxFont, Brushes.Black, new System.Drawing.Point((int)(line.StartPoint.X + line.EndPoint.X) / 2, (int)(line.StartPoint.Y + line.EndPoint.Y) / 2));
                }
                g.DrawLine(Pens.Black, line.StartPoint.X, line.StartPoint.Y, line.EndPoint.X, line.EndPoint.Y);
            }
        }

        public void DrawLineBresenham(Line line)
        {
            float x = line.StartPoint.X;
            float y = line.StartPoint.Y;
            float diffX = line.EndPoint.X - line.StartPoint.X;
            float diffY = line.EndPoint.Y - line.StartPoint.Y;
            float dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (diffX < 0) dx1 = dx2 = -1; else if (diffX > 0) dx1 = dx2 = 1; // W or E
            if (diffY < 0) dy1 = -1; else if (diffY > 0) dy1 = 1; // S or N
            float absdistX = Math.Abs(diffX);
            float absdistY = Math.Abs(diffY);
            if (!(absdistX > absdistY)) // horizontal or vertical
            {
                absdistX = Math.Abs(diffY);
                absdistY = Math.Abs(diffX);
                if (diffY < 0) dy2 = -1;
                else if (diffY > 0) dy2 = 1;
                dx2 = 0;
            }
            float numerator = absdistX;
            for (int i = 0; i <= absdistX; i++)
            {
                try
                {
                    bitmap.SetPixel((int)x, (int)y, Color.Black);
                }
                catch (Exception)
                {
                    return;
                }
                numerator += absdistY;
                if (!(numerator < absdistX))
                {
                    numerator -= absdistX;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public void CleanCanvas()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Pink);
            }
        }

        public void RefreshCanvas()
        {
            canvas.Refresh();
        }

        public Point DrawPolygon(Polygon polygon)
        {
            Point prevP = null;
            
            foreach(var item in polygon.Edges)
            {
                if(item.EndPoint != null)
                {
                    DrawLine(item);
                }
            }
            foreach (var item in polygon.Points)
            {
                 DrawPoint(item);
                prevP = item;
            }
            return prevP;
        }

        public void DrawPolygons(List<Polygon> polygons)
        {
            CleanCanvas();
            foreach (var item in polygons)
            {
                var prev = DrawPolygon(item);
                DrawLine(new Line(item.Points[0], prev));
            }
        }
    }
}
