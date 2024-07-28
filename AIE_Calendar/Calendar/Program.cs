using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
                        SharedContext.AutomationLog.Enqueue("Could not self register capabilities with the AI broker.");
                        Console.WriteLine("Could not self register capabilities with the AI broker.");
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
            
            //var content = new ApplicationCapability()
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
            //var applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapability>(content);
            //message.Content = new StringContent(applicationContentAsJson);
            //sender.Send(message);

            var capability = new ApplicationCapability()
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

            var url = "capability";
            var json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await sender.PostAsync(url, content);

            capability = new ApplicationCapability()
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

            json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capability = new ApplicationCapability()
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

            json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capability = new ApplicationCapability()
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

            json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            url = "example";

            var example = new ApplicationExample()
            {
                AppClass = Constants.APP_CLASS,
                Question = "Current Date = 7/7/2024 1:02:03 AM\r\n" +
                "User's Name = Robert Henry\r\n" +
                "\r\n" +
                "add a calendar event to remind me i have a dentist appointment for cleaning july 12th at 2:00 pm\r\nthe address is: 13 Carver Rd in Memphis",
                Answers = new[]
                {
                    "start calendar application",
                    "set calendar event date and time to [7/12/2024 2:00 PM]",
                    "set calendar event title to [Dentist Appointment - Cleaning]",
                    "append calendar event description with [Robert,]",
                    "append calendar event description with [You have a dentist appointment scheduled for a cleaning on July 12th at 2:00 PM.]",
                    "append calendar event description with [The address is 13 Carver Rd in Memphis]"
                }
            };

            json = JsonSerializer.Serialize<ApplicationExample>(example);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);
        }
    }
}