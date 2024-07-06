using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.LinkLabel;

namespace Broker
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();

        public static List<ApplicationCapibility> Capabilities = new List<ApplicationCapibility>();

        public static List<PortMapping> PortMappings = new List<PortMapping>();

        public static Queue<ActionCompiler> CompileQueue = new Queue<ActionCompiler>();

        public static Queue<ActionExecutor> ExecuteQueue = new Queue<ActionExecutor>();

        public static LargeLanguageModel LLM = null;

        public static string LLMStatus = "";

        private static WebServer server;

        public static string Context = "Base";

        public static bool LLMRunning = false;

        public static bool Executing = false;

        public static Queue<ActionExecutor> ExecutedQueue = new Queue<ActionExecutor>();


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

            await InitializeBrokerageAsync();

            //start the api
            System.Threading.Tasks.Task.Run(() =>
            {
                LLM = new LargeLanguageModel();

                server = new WebServer();
                server.Main(args);

            });

            //bring up the ui
            Application.Run(new MainWin());
        }

        private async static Task InitializeBrokerageAsync()
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
                    AppPath = "C:\\Users\\rhenry74\\source\\repos\\AIE\\AIE_Email\\Email\\bin\\Debug\\net8.0-windows\\Email.exe",
                    ContentType = null,
                    Contract = "SingleText",
                    Description = "Launch EMail",
                    Method = MethodType.NA,
                    Route = null
                });

                await SaveCapibilitiesAsync();

                SharedContext.AutomationLog.Enqueue("Default Capibilities Saved");
            }

            var portMapFilePath = Path.Combine(root, "PortMap.json");
            try
            {
                PortMappings = JsonSerializer.Deserialize<List<PortMapping>>(File.ReadAllText(portMapFilePath));
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
                    Server = "localhost",
                    Name = "Embeddings"
                });
                await File.WriteAllTextAsync(portMapFilePath, JsonSerializer.Serialize(PortMappings));
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

            await SaveCapibilitiesAsync();
            SharedContext.AutomationLog.Enqueue("Capibility Vectors Saved");
        }

        public async static Task SaveCapibilitiesAsync()
        {
            try
            {
                string root = ConfigurationManager.AppSettings["rootPath"];
                var capibilitiesFilePath = Path.Combine(root, Context, "Capibilities.json");
                if (!Directory.Exists(Path.GetDirectoryName(capibilitiesFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(capibilitiesFilePath));
                }
                await File.WriteAllTextAsync(capibilitiesFilePath, JsonSerializer.Serialize(Capabilities));
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("SaveCapibilitiesAsync: " + ex.ToString());
            }
        }

        public static string[] GenerateSystemPrompt()
        {
            var lines = new List<string>();
            lines.Add(ConfigurationManager.AppSettings["systemPrompt"]);
            lines.Add("");
            //lines.Add("");
            foreach (var capibility in Capabilities)
            {
                lines.Add(capibility.Action.Replace("[]", "[?]"));
            }
            return lines.ToArray();
        }

        public static void PromptLLM(string[] lines)
        {
            LLMRunning = true;
            System.Threading.Tasks.Task.Run(() =>
            {
                var systemPromptArray = GenerateSystemPrompt();
                string systemPrompt = "";
                foreach (var line in systemPromptArray)
                {
                    systemPrompt += line;
                    systemPrompt += "\r\n";
                }
                string userPrompt = "";
                foreach (var line in lines)
                {
                    userPrompt += line;
                    userPrompt += "\r\n";
                }
                LLM.Generate(systemPrompt, userPrompt, "");
                LLMRunning = false;
            });

            System.Threading.Tasks.Task.Run(() =>
            {
                DateTime now = DateTime.Now;
                while (LLMRunning)
                {
                    Task.Delay(100);
                    LLMStatus = "Running: " + DateTime.Now.Subtract(now);
                }
                LLMStatus = "Done";
            });
        }

        public static void ClearCapibilities()
        {
            foreach (var capibility in Capabilities)
            {
                capibility.Vector = null;
            }
            Task.Run(() => SaveCapibilitiesAsync()).Wait();
        }

        public static void ExecuteCommands(bool justOne=false)
        {
            Executing = true;
            System.Threading.Tasks.Task.Run(async () =>
            {
                while(ExecuteQueue.Count > 0)
                {
                    var executor = ExecuteQueue.Dequeue();
                    await executor.ExecuteAsync();
                    ExecutedQueue.Enqueue(executor);
                    if (justOne)
                    {
                        break;
                    }
                }
            });
        }
    }
}