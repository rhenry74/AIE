using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {            
            Program.SharedContext.SetPair("subject", tbSubject.Text);            
        }

        private void UI_UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.SUBJECT_KEY))
            {
                tbSubject.Text = Program.SharedContext.GetValue(Constants.SUBJECT_KEY);
                Program.SharedContext.SetAltered(Constants.SUBJECT_KEY, false);
            }

            while(Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }
        }
    }
}
