using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broker
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void UI_UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
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
                        var actionUI = new ActionControl();
                        flCommands.Controls.Add(actionUI);
                        actionUI.Initialize(actionCompiler);
                        actionUI.Width = flCommands.Width - SystemInformation.VerticalScrollBarWidth - 6;
                    }
                    if (!actionCompiler.Compiling)
                    {
                        actionCompiler.Compile();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.SharedContext.AutomationLog.Enqueue("Catostrophic in timer tick: " + ex.ToString());
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
            Program.CompileQueue.Clear();
            Program.ExecuteQueue.Clear();
            flCommands.Controls.Clear();
            tbAutomationStatus.Clear();

            foreach (var action in tbResponse.Lines)
            {
                Program.CompileQueue.Enqueue(new ActionCompiler(action));
            }
        }

        private void tbResponse_TextChanged(object sender, EventArgs e)
        {
            tbCompile.Visible = true;
        }

        private void tbPrompt_TextChanged_1(object sender, EventArgs e)
        {
            btSeePrompt.Visible = true;
        }

        private void btSeePrompt_Click(object sender, EventArgs e)
        {
            var dialog = new InfoDia();
            dialog.tbInfo.Lines = Program.GeneratePrompt(tbPrompt.Lines);
            dialog.ShowDialog();
        }
    }
}
