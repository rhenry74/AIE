using AIE_InterThread;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    public class ActionExecutor: BrokerWorker
    {
        public ActionCompiler ActionCompiler { get; }

        //this is a very counter intuitive situation in OO programing where a member of a class should not be accessed from within the class
        //we keep the ui control here to identify which control goes with this executor
        //it's very likely that the methods of this class will not be executed on the UI thread
        //so accessing the ui control could cause problems
        public ActionControl ActionUI { get; }

        public bool Executing { get; internal set; }

        public string Error { get; internal set; } = null;


        public ActionExecutor(ActionCompiler actionCompiler, ActionControl actionUI)
        {
            ActionCompiler = actionCompiler;
            ActionUI = actionUI;
            actionUI.Executor = this;//complex wiring here, so it can get the Log
        }

        internal void Execute()
        {
            Executing = true;
            LogMessage(" Starting...");
            var capibility = ActionCompiler.TopChoice?.Capibility;
            if (capibility != null)
            {
                LogMessage(capibility.ToString());
                switch (capibility.ActionType)
                {
                    case AIE_InterThread.ActionType.LAUNCH:
                        LaunchApplication();
                        break;
                    case AIE_InterThread.ActionType.HTTP:
                        CallApplication();
                        break;
                    case AIE_InterThread.ActionType.UI:
                        MessageBox.Show(ActionCompiler.Parameter,
                            "The LLM says...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        Error = "Action Type Unknown";
                        LogMessage(Error);
                        break;
                }
            }
            else
            {
                Error = "Unable to determin top capibility.";
                LogMessage(Error);
            }
            Executing = false;
        }

        private void LaunchApplication()
        {
            try
            {
                var capibility = ActionCompiler.TopChoice?.Capibility;
                LogMessage("Launching Application " + capibility.AppPath);
                var portNumber = Program.PortMappings.Max(x => x.Port) + 1;
                Program.PortMappings.Add(new PortMapping()
                {
                    Name = Program.Context + ":" + capibility.AppClass,
                    Port = portNumber,
                    Server = "localhost"
                });

                //start app

            }
            catch (Exception any)
            {
                Error = any.ToString();
                LogMessage("Call App Failed");
            }
        }

        private void CallApplication()
        {
            try
            {
                var capibility = ActionCompiler.TopChoice?.Capibility;
                LogMessage("Calling API " + capibility.Route);

                var portMap = Program.PortMappings.Find(pm => pm.Name == Program.Context + ":" + capibility.AppClass);
                LogMessage("Port = " + portMap.Port);

                var url = portMap.Server + ":" + portMap.Port + capibility.Route;
                LogMessage("url = " + url);

                //call api

            }
            catch (Exception any)
            {
                Error = any.ToString();
                LogMessage("Launch App Failed");
            }
        }
    }
}
