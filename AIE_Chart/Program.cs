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

            //url = "example";

            //var example = new ApplicationExample()
            //{
            //    AppClass = "column chart",
            //    Question = "send an column chart to ryker@nphs.com\r\nin the column chart summarize the early life of George Washington for his research paper\r\nlist 3 impacts Washington had on us history with a paragraph for each\r\nbe sure to include that George was a slave owner\r\n",
            //    Answers = new[]
            //    {
            //        "start column chart application",
            //        "add recipient column chart address [ryker@nphs.com]",
            //        "set column chart subject to [George Washington's Early Life and Impact on US History]",
            //        "append column chart body with [George Washington, the first President of the United States, was born on February 22, 1732, in Westmoreland County, Virginia. He was the eldest of six children to Augustine Washington and his second wife, Mary Ball Washington. Washington's early life was marked by his love for the outdoors, hunting, and surveying, which would later influence his military career.]",
            //        "append column chart body with [Washington's early life was also marked by his involvement in the French and Indian War, where he served as a major in the Virginia militia. He was appointed as the commander-in-chief of the Continental Army in 1775, leading the country to victory in the American Revolutionary War.]",
            //        "append column chart body with [Here are five significant impacts Washington had on US history:]",
            //        "append column chart body with [1. Washington's leadership during the American Revolutionary War led to the country's independence from British rule, setting a precedent for future presidents to lead the country through times of war and peace.]",
            //        "append column chart body with [2. Washington's decision to step down as president after two terms set the precedent for the two-term limit, which has been followed by most presidents since.]",
            //        "append column chart body with [3. Washington's leadership during the Whiskey Rebellion, a tax protest in western Pennsylvania, demonstrated his commitment to upholding federal authority and established the principle of federal supremacy.]",
            //        "append column chart body with [Good luck with your paper, Robert Henry]"
            //    }
            //};

            //json = JsonSerializer.Serialize<ApplicationExample>(example);
            //content = new StringContent(json, Encoding.UTF8, "application/json");
            //response = await sender.PostAsync(url, content);
        }
    }
}