using Microsoft.ML.OnnxRuntimeGenAI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            var modelPath = ConfigurationManager.AppSettings["modelPath"];
            _Model = new Model(modelPath);
            Console.WriteLine("Hello, ONNX World! The model loaded.");
            _Tokenizer = new Tokenizer(_Model);
        }

        public void Generate(string systemPrompt, string userPrompt, string contextPrompt)
        {           
            var prompt = "<|begin_of_text|>\r\n<|start_header_id|>system<|end_header_id|>\r\n";
            prompt = prompt + systemPrompt;
            prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>user<|end_header_id|>\r\n";
            prompt = prompt + ConfigurationManager.AppSettings["userExample"];
            prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>assistant<|end_header_id|>\r\n";
            prompt = prompt + ConfigurationManager.AppSettings["assistantExample"];
            prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>user<|end_header_id|>\r\n";
            prompt = prompt + $"The current date and time is: {DateTime.Now.ToString()}\r\n";
            prompt = prompt + $"The user's name is: Robert Henry\r\n";
            prompt = prompt + userPrompt;
            prompt = prompt + "\r\n<|eot_id|>\r\n<|start_header_id|>assistant<|end_header_id|>\r\n";
            
            Console.WriteLine(prompt);

            var tokens = _Tokenizer.Encode(prompt);
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
