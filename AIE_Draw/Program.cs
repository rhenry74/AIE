using AIE_InterThread;
using Microsoft.VisualBasic;
using System.Text;
using System.Text.Json;

namespace AIE_Draw
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
                        SharedContext.AutomationLog.Enqueue("Could not self register capabilities with the AI broker.");
                        Console.WriteLine("Could not self register capabilities with the AI broker.");
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
                        
            var capability = new ApplicationCapability()
            {
                Action = "start drawing application",
                ActionType = ActionType.LAUNCH,
                AppClass = "drawing",
                AppPath = Application.ExecutablePath,
                ContentType = "",
                Description = "launch an empty drawing in the drawing app",
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
                Action = "add text to drawing at []",
                ActionType = ActionType.HTTP,
                AppClass = "drawing",
                ContentType = "application/json",
                Description = "add text to a drawing at an x,y location",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.TEXT_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capability = new ApplicationCapability()
            {
                Action = "add line to drawing at []",
                ActionType = ActionType.HTTP,
                AppClass = "drawing",
                ContentType = "application/json",
                Description = "add a line to the drawing from a location to a location",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = Constants.LINE_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapability>(capability);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            url = "example";

            var example = new ApplicationExample()
            {
                AppClass = "drawing",
                Question = "draw a right triangle and lable the sides",
                Answers = new[]
                {
                    "start drawing application",
                    "add line to drawing at [X1=100, Y1=100, X2=100, Y2=300]",
                    "add line to drawing at [X1=100, Y1=100, X2=300, Y2=300]",
                    "add line to drawing at [X1=100, Y1=300, X2=300, Y2=300]",
                    "add text to drawing at [X=90, Y=200, Text=a]",
                    "add text to drawing at [X=200, Y=300, Text=b]",
                    "add text to drawing at [X=210, Y=200, Text=c]"
                }
            };

            json = JsonSerializer.Serialize<ApplicationExample>(example);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            //example = new ApplicationExample()
            //{
            //    AppClass = "column chart",
            //    Question = "create a chart that shows the planet's sizes",
            //    Answers = new[]
            //    {
            //        "start column chart application",
            //        "set column chart title to [Planets in Our Solar System - Size Comparison in km]",
            //        "add column chart series [Mercury=4879:Venus=12104:Earth=12742:Mars=6794:Jupiter=142984:Saturn=116464:Uranus=51118:Neptune=49528:Pluto=2374]"
            //    }
            //};

            //json = JsonSerializer.Serialize<ApplicationExample>(example);
            //content = new StringContent(json, Encoding.UTF8, "application/json");
            //response = await sender.PostAsync(url, content);
        }
    }
}