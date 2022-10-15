using GK_polygon_draw.Model;
using GK_polygon_draw.Presenter;
using GK_polygon_draw.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_polygon_draw
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Drawer drawer = new Drawer();
            DrawingLogic logic = new DrawingLogic(new Polygs(), drawer);
            Application.Run(drawer);
        }
    }
}
