using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsUI
{
    internal class ActionCompiler
    {
        private string ActionText;

        public ActionCompiler(string actionText)
        {
            this.ActionText = actionText;
        }

        public bool Compiled { get; internal set; } = false;

        public void Compile()
        {
            Task.Run(() =>
            {
                HttpClient client = new HttpClient();

                //do lots of stuff

                Compiled = true;
            });
        }
    }
}
