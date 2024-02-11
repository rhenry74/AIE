using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsUI
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();
        public static List<ApplicationCapibility> Capabilities = new List<ApplicationCapibility>();

        public static Queue<ActionCompiler> CompileQueue = new Queue<ActionCompiler>();
       
        public static Queue<ActionExecutor> ExecuteQueue = new Queue<ActionExecutor>();
        private static WebServer server;
        

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Capabilities = JsonSerializer.Deserialize<List<ApplicationCapibility>>(File.ReadAllText("Capibilities.json"));
                SharedContext.AutomationLog.Enqueue("Capibilities Loaded");
            }
            catch
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Capibilities");
            }
            if (Capabilities.Count == 0)
            {
                Capabilities.Add(new ApplicationCapibility()
                {
                    Action = "set email subjet from clipboard",
                    ActionType = ActionType.HTTP,
                    AppClass = "email",
                    AppPath = null,
                    ContentType = "application/json",
                    Contract = "SingleText",
                    Description = "Set the Subject of an EMail",
                    Method = MethodType.POST,
                    Route = "subject"
                });
                Capabilities.Add(new ApplicationCapibility()
                {
                    Action = "launch email",
                    ActionType = ActionType.LAUNCH,
                    AppClass = "email",
                    AppPath = "C:\\Users\\rhenry74\\source\\repos\\AIE\\AIE_Email\\WinFormsUI\\bin\\Debug\\net8.0-windows\\WinFormsUI.exe",
                    ContentType = null,
                    Contract = "SingleText",
                    Description = "Launch EMail",
                    Method = MethodType.NA,
                    Route = null
                });
                File.WriteAllText("Capibilities.json", JsonSerializer.Serialize(Capabilities));
                SharedContext.AutomationLog.Enqueue("Default Capibilities Saved");
            }
            
            System.Threading.Tasks.Task.Run(() =>
            {
                server = new WebServer();
                server.Main(args);
            });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWin());
            
        }

    }
}