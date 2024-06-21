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
                llmStatus.Text = Program.LLMStatus;
                if (Program.LLMStatus == "Done")
                {
                    tbResponse.Lines = Program.LLM.Result;
                    Program.LLMStatus = "";
                }

                if (Program.SharedContext.Altered(Constants.RESPONSE_KEY))
                {
                    tbResponse.Text = Program.SharedContext.GetValue(Constants.RESPONSE_KEY);
                    Program.SharedContext.SetAltered(Constants.RESPONSE_KEY, false);
                }

                if (Program.SharedContext.AutomationLog.Count > 0)
                {
                    var toPump = Program.SharedContext.AutomationLog.Count;
                    while (toPump > 0)
                    {
                        tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
                        toPump--;
                    }
                }

                //as actions are compiled update the UI
                if (Program.CompileQueue.Count > 0)
                {
                    var actionCompiler = Program.CompileQueue.Peek();
                    if (actionCompiler.Compiled)
                    {
                        var actionUI = new ActionControl();
                        Program.ExecuteQueue.Enqueue(new ActionExecutor(
                            Program.CompileQueue.Dequeue(),
                            actionUI));
                        flCommands.Controls.Add(actionUI);
                        actionUI.Initialize(actionCompiler);
                        actionUI.Width = flCommands.Width - SystemInformation.VerticalScrollBarWidth - 6;

                    }
                    if (!actionCompiler.Compiling)
                    {
                        actionCompiler.Compile();
                    }
                }

                if (!btRun.Visible && Program.ExecuteQueue.Count > 0)
                {
                    btRun.Visible = true;
                }
                if (btRun.Visible && Program.ExecuteQueue.Count == 0)
                {
                    btRun.Visible = false;
                }

                //as commands execute update the UI
                if (Program.ExecuteQueue.Count > 0)
                {
                    var actionExecutor = Program.ExecuteQueue.Peek();
                    if (actionExecutor.Executing)
                    {
                        var actionUI = actionExecutor.ActionUI;
                        actionUI.MakeStatus(ActionControl.Status.Executing);
                    }
                }
                if (Program.ExecutedQueue.Count > 0)
                {
                    var actionExecutor = Program.ExecutedQueue.Dequeue();
                    var actionUI = actionExecutor.ActionUI;
                    actionUI.MakeStatus(actionExecutor.Error == null ? ActionControl.Status.Success : ActionControl.Status.Failure);
                }

            }
            catch (Exception ex)
            {
                Program.SharedContext.AutomationLog.Enqueue("Catastrophic in timer tick: " + ex.ToString());
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
            dialog.tbInfo.Lines = Program.GenerateSystemPrompt();
            dialog.ShowDialog();
        }

        private void btPromptLLM_Click(object sender, EventArgs e)
        {
            if (Program.LLMRunning)
            {
                MessageBox.Show(this, "The LLM is already running a prompt.", "Whoa there cowboy!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(tbPrompt.Text))
            {
                MessageBox.Show(this, "Sorry partner, there's no prompt.", "Hmmmmm....", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tbResponse.Clear();

            Program.CompileQueue.Clear();
            Program.ExecuteQueue.Clear();
            flCommands.Controls.Clear();
            tbAutomationStatus.Clear();

            Program.PromptLLM(tbPrompt.Lines);
        }

        private void bt_Settings_Click(object sender, EventArgs e)
        {
            var dialog = new Settings();

            dialog.ShowDialog();
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            Program.ExecuteCommands();
        }

        private void MainWin_Resize(object sender, EventArgs e)
        {
            foreach(var executor in Program.ExecuteQueue.ToList())
            {
                var executorUI = executor.ActionUI;
                executorUI.Width = this.Width - 40;
            }
        }
    }
}
