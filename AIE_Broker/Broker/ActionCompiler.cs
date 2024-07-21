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

namespace Broker
{
    public class ActionCompiler : BrokerWorker
    {
        public string ActionText;

        public ActionCompiler(string actionText)
        {
            this.ActionText = actionText;
        }

        public bool Compiled { get; set; } = false;
        public EmbeddingComparison? TopChoice { get; private set; } = null;
        public string Error { get; private set; }

        public BrokerWorker.Status Status { get; private set; } = Status.Ready;
        public string Parameter { get; private set; }

        public void Compile()
        {
            this.Status = Status.Compiling;

            Task.Run(async () =>
            {
                try
                {
                    LogMessage("Compiling: " + this.ActionText);

                    //strip out parameter text
                    string actionText = this.ActionText;
                    var startPosition = this.ActionText.IndexOf('[');
                    if (startPosition > -1)
                    {
                        LogMessage("Parsing parameter...");
                        var endPosition = this.ActionText.Substring(startPosition + 1).IndexOf("]");
                        this.Parameter = this.ActionText.Substring(startPosition + 1, startPosition + endPosition - startPosition);
                        actionText = this.ActionText.Substring(0, startPosition);
                        actionText = actionText + "[]";
                        if (this.ActionText.Length > startPosition + endPosition)
                        {
                            actionText = actionText + this.ActionText.Substring(startPosition + endPosition + 2,
                                this.ActionText.Length - (startPosition + endPosition) - 2);
                        }
                        LogMessage("Parameter='" + this.Parameter + "'");

                    }

                    //find best match
                    var embedding = await Embedding.GetForAsync(actionText);

                    var comparisons = await Embedding.TopThreeCapabilitiesForAsync(embedding);
                    LogMessage("Top 3:");
                    EmbeddingComparison nextChoice = null;
                    foreach (var comparison in comparisons)
                    {
                        LogMessage(comparison.Capability.Action + " : " +
                            comparison.Likeness);
                        if (TopChoice == null)
                        {
                            TopChoice = comparison;
                        }
                        else
                        {
                            nextChoice = comparison;
                        }
                    }

                    if (TopChoice.Likeness > 0.99)
                    {
                        this.Status = Status.Success;
                        LogMessage("Compilation Success.");
                    }
                    else
                    {
                        if (nextChoice != null && TopChoice.Likeness - nextChoice.Likeness < 0.01)
                        {
                            this.Status = Status.Ambigous;
                            this.Error = "Ambigous: TopChoice.Likeness - nextChoice.Likeness < 0.01";
                        }
                        else
                        {
                            this.Status = Status.Weak;
                            this.Error = "Weak Likeness: execute with caution";
                        }
                        LogMessage(this.Error);
                    }
                }
                catch (Exception ex)
                {
                    LogMessage(ex.ToString());
                    this.Error = ex.ToString();
                    this.Status = Status.Failure;
                }

                Compiled = true;
            });
        }
    }
}
