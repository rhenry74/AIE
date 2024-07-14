using AIE_InterThread;
using Microsoft.ML.OnnxRuntimeGenAI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Broker
{
    public class LargeLanguageModel
    {
        private Model _Model;
        private Tokenizer _Tokenizer;

        private string _Text;
        public string[] Result
        {
            get 
            { 
                return _Text.Split("\n\r"); 
            }            
        }

        public LargeLanguageModel()
        {
            try
            {
                Program.SharedContext.AutomationLog.Enqueue("Loading Llama-3-8B-Instruct");
                var modelPath = ConfigurationManager.AppSettings["modelPath"];
                _Model = new Model(modelPath);
                Program.SharedContext.AutomationLog.Enqueue("Hello, ONNX World! The model loaded.");
                _Tokenizer = new Tokenizer(_Model);
            }
            catch (Exception ex)
            {
                Program.SharedContext.AutomationLog.Enqueue("Loading Llama-3-8B-Instruct failed: " +
                    ex.ToString());
            }
        }

        private string _prompt;

        public string Prompt
        {
            get { return _prompt; }
            set { _prompt = value; }
        }

        public void AssemblePrompt(ApplicationCapibility[] capibilities, ApplicationExample[] examples, 
            KeyValuePair<string, string>[] contextParameters, string userPrompt)
        {
            string systemPrompt = "";
            var systemPromptArray = GenerateSystemPrompt(capibilities);
            foreach (var line in systemPromptArray)
            {
                systemPrompt += line;
                systemPrompt += "\r\n";
            }          

            var prompt = "<|begin_of_text|>\r\n<|start_header_id|>system<|end_header_id|>\r\n";
            prompt = prompt + systemPrompt;

            prompt = prompt + "\r\n<|eot_id|>\r\n";

            foreach (var example in examples)
            {
                prompt = prompt + "<|start_header_id|>user<|end_header_id|>\r\n";
                prompt = prompt + example.Question + "\r\n";
                prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>assistant<|end_header_id|>\r\n";
                foreach (var answerLine in example.Answers)
                {
                    prompt = prompt + answerLine + "\r\n";
                }
                prompt = prompt + "\r\n<|eot_id|>\r\n";
            }

            prompt = prompt + "<|start_header_id|>user<|end_header_id|>\r\n";

            foreach (var contextParameter in contextParameters)
            {
                prompt = prompt + contextParameter.Key + " = " + contextParameter.Value + "\r\n";
            }

            prompt = prompt + "\r\n";
            prompt = prompt + userPrompt;
            prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>assistant<|end_header_id|>\r\n";

            _prompt = prompt;
        }

        private string[] GenerateSystemPrompt(ApplicationCapibility[] capibilities)
        {
            var lines = new List<string>();
            lines.Add(ConfigurationManager.AppSettings["systemPrompt"]);
            lines.Add("");
            //lines.Add("");
            foreach (var capibility in capibilities)
            {
                lines.Add(capibility.Action.Replace("[]", "[?]"));
            }
            return lines.ToArray();
        }

        public void Generate()
        {
            var tokens = _Tokenizer.Encode(_prompt);
            var parms = new GeneratorParams(_Model);
            parms.SetSearchOption("max_length", 8192);
            parms.TryGraphCaptureWithMaxBatchSize(8192);
            parms.SetInputSequences(tokens);
            //parms.SetInputIDs(tokens[0], ((ulong)tokens[0].Length), tokens.NumSequences);

            var outputTokens = _Model.Generate(parms);

            _Text = "";
            for (ulong i = 0; i < outputTokens.NumSequences; i++)
            {
                _Text = _Text + _Tokenizer.Decode(outputTokens[i]);               
            }
        }
    }
}
