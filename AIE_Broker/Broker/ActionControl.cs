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
    public partial class ActionControl : UserControl
    {
        public enum Status
        {
            Ready,
            Executing,
            Success,
            Failure
        };

        public ActionCompiler Action { get; set; }
        public ActionExecutor Executor { get; set; }

        public ActionControl()
        {
            InitializeComponent();
        }

        public void Initialize(ActionCompiler action)
        {
            this.Action = action;
            lbActionText.Text = this.Action.TopChoice?.Capibility.Action;
            lbLikeness.Text = this.Action.TopChoice?.Likeness.ToString();
            lbTopChoice.Text = this.Action.ActionText;
            lbState.Text = this.Action.Error == null ? (this.Action.Success ? "Success" : "Unknown") :
                this.Action.Error;
            lbParmsEx.Text = this.Action.TopChoice?.Capibility.Action.ToArray().Where(c => c == '[').Count().ToString();
            lbParmsParsed.Text = this.Action.Parameter == null ? "0" : "1"; //someday maybe we can have more that 1 parameter per action
        }

        public void MakeStatus(Status status)
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
                case Status.Executing:
                    btStatus.BackColor= Color.LightYellow;
                    btStatus.Text = status.ToString();
                    break;
                default:
                    btStatus.BackColor = Color.LightSteelBlue;
                    btStatus.Text = "Unknown";
                    break;
            }
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            var dialog = new InfoDia();
            if (Executor.Error != null)
            {
                Executor.Log.Add("");
                Executor.Log.Add(Executor.Error);
            }
            dialog.tbInfo.Lines = Executor.Log.ToArray();
            
            dialog.ShowDialog();
        }
    }
}
