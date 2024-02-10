using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsUI
{
    static class Program
    {
        public static InterThread SharedContext = new InterThread();

        private static WebServer server;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                if (args[1] == "-install")
                {
                    SelfRegister();
                    return;
                }
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

        private static void SelfRegister()
        {
            HttpClient sender = new HttpClient();
            sender.BaseAddress = new Uri("localhost:7770");

            var message = new HttpRequestMessage(HttpMethod.Post, "register");
            message.Headers.Add("content-type", "application/json");

            var content = new ApplicationCapibility()
            {
                Action = "get email subject",
                ActionType = ActionType.HTTP,
                AppClass = "email",
                AppPath = Application.ExecutablePath,
                ContentType = "application/json",
                Description = "get the subject of the email from the text box",
                Contract = "SingleText",
                Method = MethodType.GET,
                Route = "/subject"
            };
            var applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapibility>(content);
            message.Content = new StringContent(applicationContentAsJson);
            sender.Send(message);

            content = new ApplicationCapibility()
            {
                Action = "launch email",
                ActionType = ActionType.LAUNCH,
                AppClass = "email",
                AppPath = Application.ExecutablePath,
                ContentType = "",
                Description = "launch email app empty",
                Contract = "",
                Method = MethodType.NA,
                Route = ""
            };
            applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapibility>(content);
            message.Content = new StringContent(applicationContentAsJson);
            sender.Send(message);

            content = new ApplicationCapibility()
            {
                Action = "set email subject",
                ActionType = ActionType.HTTP,
                AppClass = "email",
                AppPath = Application.ExecutablePath,
                ContentType = "application/json",
                Description = "set the subject of the email in the text box",
                Contract = "SingleText",
                Method = MethodType.POST,
                Route = "/subject"
            };
            applicationContentAsJson = JsonSerializer.Serialize<ApplicationCapibility>(content);
            message.Content = new StringContent(applicationContentAsJson);
            sender.Send(message);
        }
    }
}