using AIE_InterThread;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ApplicationCapibility CapibilityToExecute { get; private set; }
        public string Error { get; private set; }

        public string Parameter = null;       

        public void Compile()
        {
            Compiling = true;

            Task.Run(async () =>
            {
                try
                {
                    Program.SharedContext.AutomationLog.Enqueue("Compiling: " + this.ActionText);

                    //strip out parameter text
                    string actionText = this.ActionText;
                    var startPosition = this.ActionText.IndexOf('[');
                    if (startPosition > -1)
                    {
                        Program.SharedContext.AutomationLog.Enqueue("Parsing parameter...");
                        var endPosition = this.ActionText.Substring(startPosition + 1).IndexOf("]");
                        this.Parameter = this.ActionText.Substring(startPosition + 1, startPosition + endPosition - startPosition);
                        actionText = this.ActionText.Substring(0, startPosition);
                        actionText = actionText + "[]";
                        if (this.ActionText.Length > startPosition + endPosition)
                        {
                            actionText = actionText + this.ActionText.Substring(startPosition + endPosition + 2,
                                this.ActionText.Length - (startPosition + endPosition) - 2);
                        }
                        Program.SharedContext.AutomationLog.Enqueue("Parameter='" + this.Parameter + "'");
                    }

                    //find best match
                    var embedding = await Embedding.GetForAsync(actionText);

                    var comparisons = await Embedding.TopThreeCapibilitiesFor(embedding);
                    Program.SharedContext.AutomationLog.Enqueue("Top 3:");
                    EmbeddingComparison topChoice = null;
                    foreach (var comparison in comparisons)
                    {
                        Program.SharedContext.AutomationLog.Enqueue(comparison.Capibility.Action + " : " +
                            comparison.DotProduct);
                        if (topChoice == null)
                        {
                            topChoice = comparison;
                        }
                    }

                    if (topChoice.DotProduct > 0.97)
                    {
                        this.CapibilityToExecute = topChoice.Capibility;
                        Program.SharedContext.AutomationLog.Enqueue("Compilation Success.");
                    }
                    else
                    {
                        this.Error = "Ambigous";
                        Program.SharedContext.AutomationLog.Enqueue(this.Error);
                    }
                }
                catch (Exception ex)
                {
                    Program.SharedContext.AutomationLog.Enqueue(ex.ToString());
                    this.Error = ex.ToString();
                }

                Compiled = true;
            });
        }
    }
}
