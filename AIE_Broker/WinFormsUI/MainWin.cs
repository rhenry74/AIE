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

        private void UI_UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.RESPONSE_KEY))
            {
                tbResponse.Text = Program.SharedContext.GetValue(Constants.RESPONSE_KEY);
                Program.SharedContext.SetAltered(Constants.RESPONSE_KEY, false);
            }

            if (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }

            if (Program.CompileQueue.Count > 0)
            {
                var actionCompiler = Program.CompileQueue.Peek();
                if (actionCompiler.Compiled)
                {
                    Program.ExecuteQueue.Enqueue(new ActionExecutor(Program.CompileQueue.Dequeue()));
                }
                if (!actionCompiler.Compiling)
                { 
                    actionCompiler.Compile();
                }
            }
        }

        private void tbPrompt_TextChanged(object sender, EventArgs e)
        {
            Program.SharedContext.SetPair(Constants.PROMPT_KEY, tbPrompt.Text);
        }

        private void bt_EditResponse_Click(object sender, EventArgs e)
        {
            tbResponse.ReadOnly = !tbResponse.ReadOnly;
        }

        private void tbCompile_Click(object sender, EventArgs e)
        {
            foreach (var action in tbResponse.Lines)
            {
                Program.CompileQueue.Enqueue(new ActionCompiler(action));
            }
        }

        private void tbResponse_TextChanged(object sender, EventArgs e)
        {
            tbCompile.Visible = true;
        }
    }
}
