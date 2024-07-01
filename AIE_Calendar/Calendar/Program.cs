using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calendar
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();

        private static WebServer server;

        public static string PortText = "Not Set";

        public static List<CalendarEvent> Events = new List<CalendarEvent>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            PortText = args[0];

            if (args.Length > 1)
            {
                if (args[1] == "-install")
                {
                    try
                    {
                        await SelfRegisterAsync();
                        return;
                    }
                    catch (Exception ex)
                    {
                        SharedContext.AutomationLog.Enqueue("Could not self register capibilities with the AI broker.");
                        Console.WriteLine("Could not self register capibilities with the AI broker.");
                        SharedContext.AutomationLog.Enqueue(ex.ToString());
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            string root = ConfigurationManager.AppSettings["rootPath"];
            var filePath = Path.Combine(root, "CalendarEvents.json");
            try
            {
                Events = JsonSerializer.Deserialize<List<CalendarEvent>>(File.ReadAllText(filePath));
                SharedContext.AutomationLog.Enqueue("Calendar Events Loaded");
            }
            catch (Exception ex)
            {
                SharedContext.AutomationLog.Enqueue("Error Loading Calendar Events: " + ex.ToString());
            }

            var serverTask = System.Threading.Tasks.Task.Run( () => 
            {
                server = new WebServer();
                server.Main(int.Parse(PortText));
            });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWin());
            
        }

        public async static Task SaveEventsAsync()
        {
            string root = ConfigurationManager.AppSettings["rootPath"];
            var filePath = Path.Combine(root, "CalendarEvents.json");
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(Events));
        }

        private static async Task SelfRegisterAsync()
        {
            HttpClient sender = new HttpClient();
            sender.BaseAddress = new Uri("http://localhost:7771/");
            
            //var content = new ApplicationCapibility()
            //{
            //    Action = "get email subject",
            //    ActionType = ActionType.HTTP,
            //    AppClass = "email",
            //    AppPath = Application.ExecutablePath,
            //    ContentType = "application/json",
            //    Description = "get the subject of the email from the text box",
            //    Contract = "SingleText",
            //    Method = MethodType.GET,
            //    Route = "/subject"
            //};
            //var applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapibility>(content);
            //message.Content = new StringContent(applicationContentAsJson);
            //sender.Send(message);

            var capibility = new ApplicationCapibility()
            {
                Action = "start calendar application",
                ActionType = ActionType.LAUNCH,
                AppClass = Constants.APP_CLASS,
                AppPath = Application.ExecutablePath,
                ContentType = "",
                Description = "launch an empty calendar event",
                Contract = "",
                Method = MethodType.NA,
                Route = ""
            };

            var url = "register";
            var json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "set calendar event title to []",
                ActionType = ActionType.HTTP,
                AppClass = Constants.APP_CLASS,
                ContentType = "application/json",
                Description = "set the title of the calendar event",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.TITLE_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "append calendar event description with []",
                ActionType = ActionType.HTTP,
                AppClass = Constants.APP_CLASS,
                ContentType = "application/json",
                Description = "append a line of text to the calendar event description",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.DESCRIPTION_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "set calendar event date and time to []",
                ActionType = ActionType.HTTP,
                AppClass = Constants.APP_CLASS,
                ContentType = "application/json",
                Description = "add a recipient email address to the email",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.FROM_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

        }
    }
}