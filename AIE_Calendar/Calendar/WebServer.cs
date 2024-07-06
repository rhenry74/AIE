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

namespace Calendar
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

            var sampleTodos = new Todo[] {
                new(1, "Walk the dog"),
                new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
                new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
                new(4, "Clean the bathroom"),
                new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            };

            var todosApi = app.MapGroup("/todos");
            todosApi.MapGet("/", () => sampleTodos);
            todosApi.MapGet("/{id}", (int id) =>
                sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                    ? Results.Ok(todo)
                    : Results.NotFound());
   
            var subjectApi = app.MapGroup("/");
            subjectApi.MapGet("/", () =>
            {
                //var val = new SingleText() { Text = Program.SharedContext.Dequeue(Constants.SUBJECT_KEY) };
                var val = "hmmm, not sure how to do this... don't need it right now";
                Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
                return Results.Ok(val);
            });

            subjectApi.MapPost("/" + Constants.TITLE_KEY, (SingleText newTitle) =>
                {
                    Program.SharedContext.Enqueue(Constants.TITLE_KEY, newTitle.Text);
                    Program.SharedContext.AutomationLog.Enqueue(Constants.TITLE_KEY + "Api POST: " + newTitle.ToString());
                    return Results.Ok();
                });

            subjectApi.MapPost("/" + Constants.DESCRIPTION_KEY, (SingleText bodyText) =>
            {
                Program.SharedContext.Enqueue(Constants.DESCRIPTION_KEY, bodyText.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.DESCRIPTION_KEY + "Api POST: " + bodyText.ToString());
                return Results.Ok();
            });

            subjectApi.MapPost("/" + Constants.FROM_KEY, (SingleText fromDateTimeText) =>
            {
                Program.SharedContext.Enqueue(Constants.FROM_KEY, fromDateTimeText.Text);
                Program.SharedContext.AutomationLog.Enqueue(Constants.FROM_KEY + "Api POST: " + fromDateTimeText.ToString());
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

