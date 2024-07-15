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
   
            var registerApi = app.MapGroup("/" + Constants.CAPABILITY_KEY);
            registerApi.MapGet("/", () =>
            {                
                Program.SharedContext.AutomationLog.Enqueue($"registerApi GET: {Program.Capabilities.Count} Capabilities");
                return Results.Ok(Program.Capabilities.Where(c => c.ActionType != ActionType.LAUNCH).Select(c => new ApplicationCapability()
                {
                    Action = c.Action,
                    ActionType = c.ActionType,
                    AppClass = c.AppClass,
                    ContentType = c.ContentType,
                    Contract = c.Contract,
                    Description = c.Description,
                    Method = c.Method,
                    Route = c.Route,
                }));
            });

            registerApi.MapPost("/", async (ApplicationCapability newCapability) =>
            {
                if (newCapability.ActionType == ActionType.LAUNCH)
                {
                    //we are installing a new app class
                    //remove all existing Capabilities for the app class
                    var appclass = newCapability.AppClass;
                    var existingCapabilitiesForAppClass = Program.Capabilities.Where(c => c.AppClass == appclass).ToList();
                    foreach(var CapabilityToRemove in existingCapabilitiesForAppClass)
                    {
                        Program.Capabilities.Remove(CapabilityToRemove);
                    }
                    //remove all existing examples for the app class
                    var existingExamplesForAppClass = Program.Examples.Where(c => c.AppClass == appclass).ToList();
                    foreach (var toRemove in existingExamplesForAppClass)
                    {
                        Program.Examples.Remove(toRemove);
                    }
                    await Program.SaveExamplesAsync();
                }

                Program.Capabilities.Add(newCapability);
                await Program.SaveCapabilitiesAsync();
                Program.SharedContext.AutomationLog.Enqueue(Constants.CAPABILITY_KEY + "Api POST: " + 
                    newCapability.Action);

                return Results.Ok();
            });

            var exampleApi = app.MapGroup("/" + Constants.EXAMPLE_KEY);

            exampleApi.MapPost("/", async (ApplicationExample newExample) =>
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

