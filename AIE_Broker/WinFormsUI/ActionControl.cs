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
    public partial class ActionControl : UserControl
    {
        public ActionCompiler Action { get; set; }
        public ActionControl()
        {
            InitializeComponent();
        }

        public void Initialize(ActionCompiler action)
        {
            this.Action = action;
            lbActionText.Text = this.Action.TopChoice.Capibility.Action;
            lbLikeness.Text = this.Action.TopChoice.Likeness.ToString();
            lbTopChoice.Text = this.Action.ActionText;
            lbState.Text = this.Action.Error == null ? (this.Action.Success ? "Success" : "Unknown") :
                this.Action.Error;
        }
    }
}
