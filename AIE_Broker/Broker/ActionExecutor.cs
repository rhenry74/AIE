using AIE_InterThread;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        public bool SkipIt { get; set; }

        public ActionExecutor(ActionCompiler actionCompiler, ActionControl actionUI)
        {
            ActionCompiler = actionCompiler;
            ActionUI = actionUI;
            actionUI.Executor = this;//complex wiring here, so it can get the Log
        }

        public async Task ExecuteAsync()
        {
            Executing = true;
            LogMessage("Executing...");
            var capibility = ActionCompiler.TopChoice?.Capibility;
            if (capibility != null)
            {
                LogMessage(capibility.ToString());
                if (SkipIt)
                {
                    Executing = false;
                    LogMessage("Skiped");
                    return;
                }

                switch (capibility.ActionType)
                {
                    case AIE_InterThread.ActionType.LAUNCH:
                        LaunchApplication();
                        break;
                    case AIE_InterThread.ActionType.HTTP:
                        await CallApplicationAsync();
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
                var newPortMapping = new PortMapping()
                {
                    Name = Program.Context + ":" + capibility.AppClass,
                    Port = portNumber,
                    Server = "localhost",
                    Started = DateTime.Now,
                };
                Program.PortMappings.Add(newPortMapping);

                //start app
                var exe = Path.GetFileName(capibility.AppPath);
                var dir = Path.GetDirectoryName(capibility.AppPath);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    FileName = exe,
                    Arguments = portNumber.ToString(),
                    WorkingDirectory = dir
                };
                process.Start();
                newPortMapping.ProcessId = process.Id;

            }
            catch (Exception any)
            {
                Error = any.ToString();
                LogMessage("Launch App Failed");
                LogMessage(Error);
            }
        }

        private async Task CallApplicationAsync()
        {
            try
            {
                var capibility = ActionCompiler.TopChoice?.Capibility;
                LogMessage("Calling API " + capibility.Route);

                var portMap = Program.PortMappings.Where(pm => pm.Name == Program.Context + ":" + capibility.AppClass)
                    .OrderByDescending(pm => pm.Started).FirstOrDefault();
                if (portMap == null)
                {
                    LogMessage("Could not find the port of the app. capibility.AppClass=" + capibility.AppClass);
                    return;
                }

                LogMessage($"Using Port {portMap.Port} for AppClass {capibility.AppClass} that was started at {portMap.Started}");

                var url = "http://" + portMap.Server + ":" + portMap.Port;
                LogMessage("url = " + url + "/" + capibility.Route);

                //call api
                HttpClient sender = new HttpClient();
                sender.BaseAddress = new Uri(url);

                string json = null;
                if (capibility.Contract == "SingleText")
                {
                    var singleText = new SingleText()
                    {
                        Text = ActionCompiler.Parameter
                    };
                    json = JsonSerializer.Serialize<SingleText>(singleText);
                }

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (capibility.Method == MethodType.POST)
                {
                    response = await sender.PostAsync(capibility.Route, content);
                }

                LogMessage("response.StatusCode: " + response.StatusCode.ToString());
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Error = "API Call Failed";
                    LogMessage(Error);
                }
                
            }
            catch (Exception any)
            {
                Error = any.ToString();
                LogMessage("Call App Failed");
                LogMessage(Error); 
            }
        }
    }
}
