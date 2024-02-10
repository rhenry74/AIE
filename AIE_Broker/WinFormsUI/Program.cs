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

    }
}