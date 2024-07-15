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

namespace AIE_Chart
{    
    public class WebServer
    {
        public void Main(int port)
        {
            var builder = WebApplication.CreateSlimBuilder();

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });

            var app = builder.Build();
                           
            var api = app.MapGroup("/");
            //api.MapGet("/", () =>
            //{
            //    //var val = new SingleText() { Text = Program.SharedContext.Dequeue(Constants.SUBJECT_KEY) };
            //    var val = "hmmm, not sure how to do this... don't need it right now";
            //    Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
            //    return Results.Ok(val);
            //});

            api.MapPost("/" + Constants.TITLE_KEY, (SingleText newTitle) =>
            {
                Program.SharedContext.Enqueue(Constants.TITLE_KEY, newTitle.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.TITLE_KEY + "Api POST: " + newTitle.ToString());
                return Results.Ok();
            });

            api.MapPost("/" + Constants.SERIES_KEY, (SingleText seriesText) =>
            {
                Program.SharedContext.Enqueue(Constants.SERIES_KEY, seriesText.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.SERIES_KEY + "Api POST: " + seriesText.ToString());
                return Results.Ok();
            });            

            Program.SharedContext.AutomationLog.Enqueue("url: " + "http://localhost:" + port);
            app.Urls.Add("http://localhost:" + port);
            app.Run();
        }
    }

    public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

    [JsonSerializable(typeof(Todo[]))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}

