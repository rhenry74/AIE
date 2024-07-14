using AIE_InterThread;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.Json;

namespace AIE_Chart
{
    internal static class Program
    {

        public static InterThread SharedContext = new InterThread();

        private static WebServer server;

        public static string PortText = "Not Set";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            PortText = args[0];

            if (args.Length > 1)
            {
                if (args[1] == "-install")
                {
                    try
                    {
                        Task.Run(() => SelfRegisterAsync()).Wait();
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

            var serverTask = Task.Run(() =>
            {
                server = new WebServer();
                server.Main(int.Parse(PortText));
            });

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWin());
        }


        private static async Task SelfRegisterAsync()
        {
            HttpClient sender = new HttpClient();
            sender.BaseAddress = new Uri("http://localhost:7771/");

            //var content = new ApplicationCapibility()
            //{
            //    Action = "get column chart subject",
            //    ActionType = ActionType.HTTP,
            //    AppClass = "column chart",
            //    AppPath = Application.ExecutablePath,
            //    ContentType = "application/json",
            //    Description = "get the subject of the column chart from the text box",
            //    Contract = "SingleText",
            //    Method = MethodType.GET,
            //    Route = "/subject"
            //};
            //var applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapibility>(content);
            //message.Content = new StringContent(applicationContentAsJson);
            //sender.Send(message);

            var capibility = new ApplicationCapibility()
            {
                Action = "start column chart application",
                ActionType = ActionType.LAUNCH,
                AppClass = "column chart",
                AppPath = Application.ExecutablePath,
                ContentType = "",
                Description = "launch an empty column chart in the column chart app",
                Contract = "",
                Method = MethodType.NA,
                Route = ""
            };

            var url = "capibility";
            var json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "set column chart title to []",
                ActionType = ActionType.HTTP,
                AppClass = "column chart",
                ContentType = "application/json",
                Description = "set the title of the column chart",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.TITLE_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "add column chart series []",
                ActionType = ActionType.HTTP,
                AppClass = "column chart",
                ContentType = "application/json",
                Description = "add a series to the chart",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.SERIES_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            url = "example";

            var example = new ApplicationExample()
            {
                AppClass = "column chart",
                Question = "create a chart that shows the number of days in each month of the year",
                Answers = new[]
                {
                    "start column chart application",
                    "set column chart title to [Days in Each Month of the Year]",
                    "add column chart series [January=31:February=28:March=31:April=30:May=31:June=30:July=31:August=31:September=30:October=31:November=30:December=31]"
                }
            };

            json = JsonSerializer.Serialize<ApplicationExample>(example);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            example = new ApplicationExample()
            {
                AppClass = "column chart",
                Question = "create a chart that shows the planet's sizes",
                Answers = new[]
                {
                    "start column chart application",
                    "set column chart title to [Planets in Our Solar System - Size Comparison in km]",
                    "add column chart series [Mercury=4879:Venus=12104:Earth=12742:Mars=6794:Jupiter=142984:Saturn=116464:Uranus=51118:Neptune=49528:Pluto=2374]"
                }
            };

            json = JsonSerializer.Serialize<ApplicationExample>(example);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);
        }
    }
}