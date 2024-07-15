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

        public static List<ApplicationCapability> Capabilities = new List<ApplicationCapability>();

        public static List<ApplicationExample> Examples = new List<ApplicationExample>();

        public static Dictionary<string, List<KeyValuePair<string, string>>> ContextParameters =
            new Dictionary<string, List<KeyValuePair<string, string>>>();

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
            var capabilitiesFilePath = Path.Combine(root, Context, "Capabilities.json");
            try
            {
                Capabilities = JsonSerializer.Deserialize<List<ApplicationCapability>>(File.ReadAllText(capabilitiesFilePath));
                SharedContext.AutomationLog.Enqueue("Capabilities Loaded");
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Capabilities: " + ex.ToString());
            }

            if (Capabilities.Where(c => c.AppClass == "built in").Count() == 0)
            {
                Capabilities.Add(new ApplicationCapability()
                {
                    Action = "respond to user with []",
                    ActionType = ActionType.UI,
                    AppClass = "built in",
                    AppPath = null,
                    ContentType = "text/plain",
                    Contract = "SingleText",
                    Description = "",
                    Method = MethodType.NA,
                    Route = ""
                });
                //Capabilities.Add(new ApplicationCapability()
                //{
                //    Action = "save clipboard to file []",
                //    ActionType = ActionType.UI,
                //    AppClass = "built in",
                //    AppPath = null,
                //    ContentType = "text/plain",
                //    Contract = "SingleText",
                //    Description = "",
                //    Method = MethodType.NA,
                //    Route = null
                //});

                await SaveCapabilitiesAsync();
                SharedContext.AutomationLog.Enqueue("Default Capabilities Saved");
            }            

            //examples
            var examplesFilePath = Path.Combine(root, Context, "Examples.json");
            try
            {
                Examples = JsonSerializer.Deserialize<List<ApplicationExample>>(File.ReadAllText(examplesFilePath));
                SharedContext.AutomationLog.Enqueue("Examples Loaded");
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("Error Loading examples: " + ex.ToString());
            }

            if (Examples.Where(c => c.AppClass == "built in").Count() == 0)
            {
                Examples.Add(new ApplicationExample()
                {
                    AppClass = "built in",
                    Question = "Who was George Washington?",
                    Answers = new[] { "respond to user with [George Washington was the first President of the United States, serving from 1789 to 1797. He was a military leader during the American Revolutionary War and is considered one of the founding fathers of the United States.]" }
                });

                await SaveExamplesAsync();
                SharedContext.AutomationLog.Enqueue("Default Examples Saved");
            }

            //port map
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

            //context parameters
            var contextFilePath = Path.Combine(root, Context, "Parameters.json");
            try
            {
                var baseParameters = JsonSerializer.Deserialize<List<KeyValuePair<string, string>>>(
                    File.ReadAllText(contextFilePath));
                ContextParameters.Add(Context, baseParameters);
                SharedContext.AutomationLog.Enqueue("Parameters for " + Context + " Loaded");
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Parameters: " + ex.ToString());
            }
            if (ContextParameters.Count == 0)
            {
                List<KeyValuePair<string, string>> baseContextParameters;
                ContextParameters.TryGetValue(Context, out baseContextParameters);
                if (baseContextParameters == null)
                {
                    baseContextParameters = new List<KeyValuePair<string, string>>();
                    ContextParameters.Add(Context, baseContextParameters);
                }
                baseContextParameters.Add(new KeyValuePair<string, string>("User's Name", "Robert Henry"));
                baseContextParameters.Add(new KeyValuePair<string, string>("Current Date", DateTime.Now.ToString()));
                await SaveContextParametersAsync(Context);
                SharedContext.AutomationLog.Enqueue("Parameters Initalized");
            }
        }

        public async static Task InitializeCapabilityVectorsAsync()
        {
            SharedContext.AutomationLog.Enqueue("Initializing Capability Vectors");
            foreach (var capability in Capabilities)
            {
                if (capability.Vector == null)
                {
                    SharedContext.AutomationLog.Enqueue("Getting Embedding for: " + capability.Action);
                    capability.Vector = (await Embedding.GetForAsync(capability.Action)).Vector;
                }
            }

            await SaveCapabilitiesAsync();
            SharedContext.AutomationLog.Enqueue("Capability Vectors Saved");
        }

        public async static Task SaveCapabilitiesAsync()
        {
            try
            {
                string root = ConfigurationManager.AppSettings["rootPath"];
                var capabilitiesFilePath = Path.Combine(root, Context, "Capabilities.json");
                if (!Directory.Exists(Path.GetDirectoryName(capabilitiesFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(capabilitiesFilePath));
                }
                await File.WriteAllTextAsync(capabilitiesFilePath, JsonSerializer.Serialize(Capabilities));
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("SaveCapabilitiesAsync: " + ex.ToString());
            }
        }

        public async static Task SaveContextParametersAsync(string context)
        {
            string root = ConfigurationManager.AppSettings["rootPath"];
            var filePath = Path.Combine(root, context, "Parameters.json");
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(ContextParameters[context]));
        }

        public static string[] PreviewPrompt(string[] lines)
        {
            string userPrompt = "";
            foreach (var line in lines)
            {
                userPrompt += line;
                userPrompt += "\r\n";
            }

            LLM.AssemblePrompt(Capabilities.ToArray(), Examples.ToArray(),
                ContextParameters[Context].ToArray(), userPrompt);
            return LLM.Prompt.Split("\r\n");
        }

        public static void PromptLLM(string[] lines)
        {
            LLMRunning = true;
            System.Threading.Tasks.Task.Run(() =>
            {
                string userPrompt = "";
                foreach (var line in lines)
                {
                    userPrompt += line;
                    userPrompt += "\r\n";
                }

                LLM.AssemblePrompt(Capabilities.ToArray(), Examples.ToArray(),
                    ContextParameters[Context].ToArray(), userPrompt);
                LLM.Generate();
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

        public static void ClearCapabilities()
        {
            foreach (var capability in Capabilities)
            {
                capability.Vector = null;
            }
            Task.Run(() => SaveCapabilitiesAsync()).Wait();
        }

        public static void ExecuteCommands(bool justOne = false)
        {
            Executing = true;
            System.Threading.Tasks.Task.Run(async () =>
            {
                while (ExecuteQueue.Count > 0)
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

        public static async Task SaveExamplesAsync()
        {
            string root = ConfigurationManager.AppSettings["rootPath"];
            var exampleFilePath = Path.Combine(root, Context, "Examples.json");
            if (!Directory.Exists(Path.GetDirectoryName(exampleFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(exampleFilePath));
            }
            await File.WriteAllTextAsync(exampleFilePath, JsonSerializer.Serialize(Examples));
        }


    }
}