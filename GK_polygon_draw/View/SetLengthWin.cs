using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_polygon_draw.View
{
    public partial class SetLengthWin : Form
    {
        public SetLengthWin(float initVal)
        {
            InitializeComponent();
            lengthUpDown.Value = (decimal)initVal;
        }
    }
}
