using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsUI
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();

        public static List<ApplicationCapibility> Capabilities = new List<ApplicationCapibility>();

        public static List<PortMapping> PortMappings = new List<PortMapping>();

        public static Queue<ActionCompiler> CompileQueue = new Queue<ActionCompiler>();

        public static Queue<ActionExecutor> ExecuteQueue = new Queue<ActionExecutor>();

        private static WebServer server;

        public static string Context = "Base";


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Context = args.Count() == 1 ? args[0] : "Base";

            await InitializeBrokerage();

            //start the api
            System.Threading.Tasks.Task.Run(() =>
            {
                server = new WebServer();
                server.Main(args);
            });

            //bring up the ui
            Application.Run(new MainWin());
        }

        private async static Task InitializeBrokerage()
        {
            string root = ConfigurationManager.AppSettings["rootPath"];
            var capibilitiesFilePath = Path.Combine(root, Context, "Capibilities.json");
            try
            {
                Capabilities = JsonSerializer.Deserialize<List<ApplicationCapibility>>(File.ReadAllText(capibilitiesFilePath));
                SharedContext.AutomationLog.Enqueue("Capibilities Loaded");
            }
            catch(Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Capibilities: " + ex.ToString());
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
                if (!Directory.Exists(Path.GetDirectoryName(capibilitiesFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(capibilitiesFilePath));
                }

                await File.WriteAllTextAsync(capibilitiesFilePath, JsonSerializer.Serialize(Capabilities));
                SharedContext.AutomationLog.Enqueue("Default Capibilities Saved");
            }

            var porMapFilePath = Path.Combine(root, "PortMap.json");
            try
            {
                PortMappings = JsonSerializer.Deserialize<List<PortMapping>>(File.ReadAllText(porMapFilePath));
                SharedContext.AutomationLog.Enqueue("Port Mappings Loaded");
            }
            catch
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Port Mappings");
            }
            if (PortMappings.Count == 0)
            {
                PortMappings.Add(new PortMapping()
                {
                    Port = 7771,
                    Server = "localhost",
                    Name = "Broker"
                });
                PortMappings.Add(new PortMapping()
                {
                    Port = 7770,
                    Server = "basement",
                    Name = "Embeddings"
                });
                await File.WriteAllTextAsync(porMapFilePath, JsonSerializer.Serialize(PortMappings));
                SharedContext.AutomationLog.Enqueue("Default Port Map Saved");
            }
        }

        public async static Task InitializeCapibilityVectorsAsync()
        {
            SharedContext.AutomationLog.Enqueue("Initializing Capibility Vectors");
            foreach(var capibility in Capabilities)
            {
                if (capibility.Vector == null)
                {
                    SharedContext.AutomationLog.Enqueue("Getting Embedding for: " + capibility.Action);
                    capibility.Vector = (await Embedding.GetForAsync(capibility.Action)).Vector;
                }
            }

            string root = ConfigurationManager.AppSettings["rootPath"];
            var capibilitiesFilePath = Path.Combine(root, Context, "Capibilities.json");
            await File.WriteAllTextAsync(capibilitiesFilePath, JsonSerializer.Serialize(Capabilities));
            SharedContext.AutomationLog.Enqueue("Capibility Vectors Saved");
        }

        public static string[] GeneratePrompt(string[] question)
        {
            var lines = new List<string>();
            lines.Add(ConfigurationManager.AppSettings["automationPrompt"]);
            lines.Add("");
            foreach (var capibility in Capabilities)
            {
                lines.Add(capibility.Action.Replace("[]", "[?]"));
            }
            lines.Add("");
            lines.Add("The human's request is:");
            lines.Add("");
            foreach (var questionLine in question)
            {
                lines.Add(questionLine);
            }
            return lines.ToArray();
        }
    }
}