using System;
using System.Windows.Forms;

namespace GK_polygon_draw.View
{
    public partial class SetLengthWin : Form
    {
        public Button accButton => acceptLengthButton;
        public float setLgthVal => (float)lengthUpDown.Value;
        public SetLengthWin(float initVal)
        {
            InitializeComponent();
            lengthUpDown.Value = (decimal)initVal;
        }

        private void acceptLengthButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
