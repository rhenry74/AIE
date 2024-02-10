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

namespace WinFormsUI
{
    
    public class WebServer
    {
        public void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            //not sure why this was needed
            //builder.Services.ConfigureHttpJsonOptions(options =>
            //{
            //    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            //});

            var app = builder.Build();
   
            var registerApi = app.MapGroup("/" + Constants.REGISTER_KEY);
            //subjectApi.MapGet("/", () =>
            //{
            //    var val = new SingleText() { Text = Program.SharedContext.GetValue(Constants.SUBJECT_KEY) };
            //    Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
            //    return Results.Ok(val);
            //});

            registerApi.MapPost("/", (ApplicationCapibility newCapibility) =>
            {
                //check app class
                //create reg
                Program.SharedContext.AutomationLog.Enqueue("registerApi POST: " + newCapibility.Action);
                return Results.Ok(newCapibility.Action);
            });

            app.Urls.Add("http://localhost:7770");
            app.Run();
        }
    }

}

