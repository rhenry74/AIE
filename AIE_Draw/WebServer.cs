using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIE_Draw
{    
    public class WebServer
    {
        public void Main(int port)
        {
            var builder = WebApplication.CreateSlimBuilder();

            var app = builder.Build();
                           
            var api = app.MapGroup("/");
            //api.MapGet("/", () =>
            //{
            //    //var val = new SingleText() { Text = Program.SharedContext.Dequeue(Constants.SUBJECT_KEY) };
            //    var val = "hmmm, not sure how to do this... don't need it right now";
            //    Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
            //    return Results.Ok(val);
            //});

            api.MapPost("/" + Constants.TEXT_KEY, (SingleText newElement) =>
            {
                Program.SharedContext.Enqueue(Constants.TEXT_KEY, newElement.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.TEXT_KEY + "Api POST: " + newElement.ToString());
                return Results.Ok();
            });

            api.MapPost("/" + Constants.LINE_KEY, (SingleText newElement) =>
            {
                Program.SharedContext.Enqueue(Constants.LINE_KEY, newElement.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.LINE_KEY + "Api POST: " + newElement.ToString());
                return Results.Ok();
            });            

            Program.SharedContext.AutomationLog.Enqueue("url: " + "http://localhost:" + port);
            app.Urls.Add("http://localhost:" + port);
            app.Run();
        }
    }

}

