using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Email
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();

        private static WebServer server;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            var portText = args[0];

            if (args.Length > 1)
            {
                if (args[1] == "-install")
                {
                    try
                    {
                        await SelfRegisterAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not self register capibilities with the AI broker.");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            System.Threading.Tasks.Task.Run(() =>
            {
                server = new WebServer();
                server.Main(int.Parse(portText));
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
                Action = "start email application",
                ActionType = ActionType.LAUNCH,
                AppClass = "email",
                AppPath = Application.ExecutablePath,
                ContentType = "",
                Description = "launch an empty email in the email app",
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
                Action = "set email subject to []",
                ActionType = ActionType.HTTP,
                AppClass = "email",
                ContentType = "application/json",
                Description = "set the subject of the email",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = "/" + Constants.SUBJECT_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "append email body with []",
                ActionType = ActionType.HTTP,
                AppClass = "email",
                ContentType = "application/json",
                Description = "append a line of the body of the eamil",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = "/" + Constants.BODY_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

            capibility = new ApplicationCapibility()
            {
                Action = "add recipient email address []",
                ActionType = ActionType.HTTP,
                AppClass = "email",
                ContentType = "application/json",
                Description = "add a recipient email address to the email",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = "/" + Constants.RECIPIENT_KEY
            };

            json = JsonSerializer.Serialize<ApplicationCapibility>(capibility);
            content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await sender.PostAsync(url, content);

        }
    }
}