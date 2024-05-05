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

namespace Email
{
    
    public class WebServer
    {
        public void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

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
   
            var subjectApi = app.MapGroup("/" + Constants.SUBJECT_KEY);
            subjectApi.MapGet("/", () =>
            {
                var val = new SingleText() { Text = Program.SharedContext.GetValue(Constants.SUBJECT_KEY) };
                Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
                return Results.Ok(val);
            });

            subjectApi.MapPost("/", (SingleText newSubject) =>
                {
                    Program.SharedContext.SetPair(Constants.SUBJECT_KEY, newSubject.Text);
                    Program.SharedContext.AutomationLog.Enqueue("subjectApi POST: " + newSubject.ToString());
                    return Results.Ok(newSubject);
                });

            app.Urls.Add("http://localhost:7775");
            app.Run();
        }
    }

    public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

    [JsonSerializable(typeof(Todo[]))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}

