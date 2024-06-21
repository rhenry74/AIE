using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    public class ActionExecutor
    {
        public ActionCompiler ActionCompiler { get; }
        public ActionControl ActionUI { get; }

        public ActionExecutor(ActionCompiler actionCompiler, ActionControl actionUI)
        {
            ActionCompiler = actionCompiler;
            ActionUI = actionUI;
        }       
    }
}
