using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GK_polygon_draw.Model.Drawings;
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

        public Drawer()
        {
            InitializeComponent();
            creatingMode.Checked = true;
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
                g.DrawLine(Pens.Black, line.StartPoint.X, line.StartPoint.Y, line.EndPoint.X, line.EndPoint.Y);
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
            foreach(var item in polygon.Points)
            {
                if(prevP == null)
                {
                    DrawPoint(item);
                }
                else
                {
                    DrawPoint(item);
                    DrawLine(new Line(prevP, item));
                }
                prevP = item;
            }
            return prevP;
        }

        public void DrawPolygons(List<Polygon> polygons)
        {
            CleanCanvas();
            foreach(var item in polygons)
            {
                var prev = DrawPolygon(item);
                DrawLine(new Line(item.Points[0], prev));
            }
        }
    }
}
