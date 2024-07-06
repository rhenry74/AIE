using AIE_InterThread;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Broker
{
    
    public class WebServer
    {
        public async Task Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            //not sure why this was needed
            //builder.Services.ConfigureHttpJsonOptions(options =>
            //{
            //    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            //});

            var app = builder.Build();
   
            var registerApi = app.MapGroup("/" + Constants.CAPIBILITY_KEY);
            //subjectApi.MapGet("/", () =>
            //{
            //    var val = new SingleText() { Text = Program.SharedContext.GetValue(Constants.SUBJECT_KEY) };
            //    Program.SharedContext.AutomationLog.Enqueue("subjectApi GET: " + val);
            //    return Results.Ok(val);
            //});

            registerApi.MapPost("/", async (ApplicationCapibility newCapibility) =>
            {
                if (newCapibility.ActionType == ActionType.LAUNCH)
                {
                    //we are installing a new app class
                    //remove all existing capibilities for the app class
                    var appclass = newCapibility.AppClass;
                    var existingCapibilitiesForAppClass = Program.Capabilities.Where(c => c.AppClass == appclass).ToList();
                    foreach(var capibilityToRemove in existingCapibilitiesForAppClass)
                    {
                        Program.Capabilities.Remove(capibilityToRemove);
                    }
                    //remove all existing examples for the app class
                    var existingExamplesForAppClass = Program.Examples.Where(c => c.AppClass == appclass).ToList();
                    foreach (var toRemove in existingExamplesForAppClass)
                    {
                        Program.Examples.Remove(toRemove);
                    }
                    await Program.SaveExamplesAsync();
                }

                Program.Capabilities.Add(newCapibility);
                await Program.SaveCapibilitiesAsync();
                Program.SharedContext.AutomationLog.Enqueue(Constants.CAPIBILITY_KEY + "Api POST: " + 
                    newCapibility.Action);

                return Results.Ok();
            });

            var exampleApi = app.MapGroup("/" + Constants.EXAMPLE_KEY);
            
            registerApi.MapPost("/", async (ApplicationExample newExample) =>
            {                
                Program.Examples.Add(newExample);
                await Program.SaveExamplesAsync();
                Program.SharedContext.AutomationLog.Enqueue(Constants.EXAMPLE_KEY + "Api POST: " + newExample.Question);
                return Results.Ok();
            });

            var brokerServer = Program.PortMappings.First(pm => pm.Name == "Broker");
            var baseAddress = new Uri("http://" + brokerServer.Server + ":" + brokerServer.Port);

            app.Urls.Add(baseAddress.ToString());
            Program.SharedContext.AutomationLog.Enqueue("Starting API: " + baseAddress.ToString());
            app.Run();
        }
    }

}

