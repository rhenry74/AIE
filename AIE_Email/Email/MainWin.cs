using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void UI_UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.SUBJECT_KEY))
            {
                tbSubject.Text = Program.SharedContext.Dequeue(Constants.SUBJECT_KEY);
            }

            while (Program.SharedContext.Altered(Constants.BODY_KEY))
            {
                var text = Program.SharedContext.Dequeue(Constants.BODY_KEY);
                tbBody.AppendText(text);
                tbBody.AppendText(Environment.NewLine);
                tbBody.AppendText(Environment.NewLine);
            }

            if (Program.SharedContext.Altered(Constants.RECIPIENT_KEY))
            {
                var text = Program.SharedContext.Dequeue(Constants.RECIPIENT_KEY);
                tbRecipients.Text = String.IsNullOrEmpty(tbRecipients.Text) ? text : ", " + text;
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            this.Text = "AIE Email on Port " + Program.PortText;
        }
    }
}
