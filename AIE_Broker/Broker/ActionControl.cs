using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Broker.BrokerWorker;

namespace Broker
{
    public partial class ActionControl : UserControl
    {
        public ActionCompiler Action { get; set; }
        public ActionExecutor Executor { get; set; }

        public ActionControl()
        {
            InitializeComponent();
        }

        public void Initialize(ActionCompiler action)
        {
            this.Action = action;
            lbActionText.Text = this.Action.TopChoice?.Capability.Action;
            lbLikeness.Text = this.Action.TopChoice?.Likeness.ToString();
            lbTopChoice.Text = this.Action.ActionText;
            UpdateCompileStatus();
            lbParmsEx.Text = this.Action.TopChoice?.Capability.Action.ToArray().Where(c => c == '[').Count().ToString();
            btParsed.Text = this.Action.Parameter == null ? "0" : "1"; //someday maybe we can have more that 1 parameter per action
            if (action.Status == Status.Failure)
            {
                this.cbExecute.Checked = false;
            }
        }

        public void MakeExecuteStatus(Status status)
        {
            switch (status)
            {
                case Status.Success:
                    btStatus.BackColor = Color.LightGreen;
                    btStatus.Text = status.ToString();
                    break;
                case Status.Failure:
                    btStatus.BackColor = Color.LightSalmon;
                    btStatus.Text = status.ToString();
                    break;
                case Status.Compiling:
                    btStatus.BackColor = Color.LightGoldenrodYellow;
                    btStatus.Text = status.ToString();
                    break;
                case Status.Skipped:
                    btStatus.BackColor = Color.LightYellow;
                    btStatus.Text = status.ToString();
                    break;
                default:
                    btStatus.BackColor = Color.LightSteelBlue;
                    btStatus.Text = "Unknown";
                    break;
            }
        }

        public void UpdateCompileStatus()
        {
            //var status = this.Action.Error == null ? (this.Action.Success ? "Success" : "Unknown") :
            //    this.Action.Error;

            btState.Text = Action.Status.ToString();

            switch (Action.Status)
            {
                case Status.Success:
                    btState.BackColor = Color.LightGreen;
                    break;
                case Status.Failure:
                    btState.BackColor = Color.LightSalmon;
                    break;
                case Status.Ambigous:
                case Status.Weak:
                    btState.BackColor = Color.LightYellow;
                    break;
                case Status.Compiling:
                    btState.BackColor = Color.LightGoldenrodYellow;
                    break;
                default:
                    btState.BackColor = Color.LightSteelBlue;
                    btState.Text = "Unknown";
                    break;
            }
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            if (btStatus.Text == "Ready")
            {
                Program.ExecuteCommands(true);
                return;
            }
            var dialog = new InfoDia();
            dialog.tbInfo.Lines = Executor.Logs.ToArray();
            dialog.ShowDialog();
        }

        private void btParsed_Click(object sender, EventArgs e)
        {
            var dialog = new InfoDia();
            dialog.tbInfo.Text = Action.Parameter;
            dialog.ShowDialog();
        }

        private void btState_Click(object sender, EventArgs e)
        {
            var dialog = new InfoDia();
            dialog.tbInfo.Lines = Action.Logs.ToArray();
            dialog.ShowDialog();
        }

        private void cbExecute_CheckedChanged(object sender, EventArgs e)
        {
            Executor.SkipIt = !cbExecute.Checked;
        }
    }
}
