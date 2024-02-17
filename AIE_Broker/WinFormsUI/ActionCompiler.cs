using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsUI
{
    internal class ActionCompiler
    {
        private string ActionText;

        public ActionCompiler(string actionText)
        {
            this.ActionText = actionText;
        }

        public bool Compiled { get; set; } = false;
        public bool Compiling { get; set; } = false;

        

        public void Compile()
        {
            Compiling = true;

            Task.Run(async () =>
            {
                Program.SharedContext.AutomationLog.Enqueue("Compiling: " + this.ActionText);

                var embedding = await Embedding.GetForAsync(this.ActionText);

                var possibleActions = await Embedding.TopThreeCapibilitiesFor(embedding);
                Program.SharedContext.AutomationLog.Enqueue("Top 3:");
                foreach (var possibleAction in possibleActions)
                {
                    Program.SharedContext.AutomationLog.Enqueue(possibleAction.Action);
                }

                Compiled = true;
            });
        }
    }
}
