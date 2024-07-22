using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIE_Draw
{
    public partial class DrawElement : Form
    {
        public DrawElement()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
                case "Line":
                    LineElement lineElement = new LineElement();

                    break;
                case "Text":
                    break;
                default:
                    break;
            }
        }
    }
}
