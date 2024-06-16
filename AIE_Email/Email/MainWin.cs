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

            if (Program.SharedContext.Altered(Constants.BODY_KEY))
            {
                var text = Program.SharedContext.GetValue(Constants.BODY_KEY);
                tbBody.Lines.Append(text); 
                Program.SharedContext.SetAltered(Constants.BODY_KEY, false);
            }

            if (Program.SharedContext.Altered(Constants.RECIPIENT_KEY))
            {
                var text = Program.SharedContext.GetValue(Constants.RECIPIENT_KEY);
                tbRecipients.Text = String.IsNullOrEmpty(tbRecipients.Text) ? text : ", " + text;
                Program.SharedContext.SetAltered(Constants.RECIPIENT_KEY, false);
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }
        }
    }
}
