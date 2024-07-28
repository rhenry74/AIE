using AIE_InterThread;
using Microsoft.Extensions.Hosting;
using Microsoft.ML.OnnxRuntimeGenAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Broker
{
    public class LargeLanguageModel
    {
        private Model _Model;

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

        public int Tokens { get; private set; }

        public void AssemblePrompt(ApplicationCapability[] capabilities, ApplicationExample[] examples, 
            KeyValuePair<string, string>[] contextParameters, string userPrompt)
        {
            string systemPrompt = "";
            var systemPromptArray = GenerateSystemPrompt(capabilities);
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

        private string[] GenerateSystemPrompt(ApplicationCapability[] capabilities)
        {
            var lines = new List<string>();
            lines.Add(ConfigurationManager.AppSettings["systemPrompt"]);
            lines.Add("");
            //lines.Add("");
            foreach (var capability in capabilities)
            {
                lines.Add(capability.Action.Replace("[]", "[?]"));
            }
            return lines.ToArray();
        }

        public void Generate()
        {
            _Text = string.Empty;
            using var tokenizer = new Tokenizer(_Model);
            var tokens = tokenizer.Encode(_prompt);
            var parms = new GeneratorParams(_Model);
            parms.SetSearchOption("max_length", 8192);
            parms.TryGraphCaptureWithMaxBatchSize(8192);
            parms.SetInputSequences(tokens);
            //parms.SetInputIDs(tokens[0], ((ulong)tokens[0].Length), tokens.NumSequences);

            //var outputTokens = _Model.Generate(parms);

            using var generator = new Generator(_Model, parms);
            using var tokenizerStream = tokenizer.CreateStream();
            Tokens = 0;

            while (!generator.IsDone())
            {
                generator.ComputeLogits();
                generator.GenerateNextToken();
                var tokenId = generator.GetSequence(0)[^1];
                var sentencePiece = tokenizerStream.Decode(tokenId);
                _Text = _Text + sentencePiece;
                Tokens++;
            }
            

            //_Text = "";
            //for (ulong i = 0; i < outputTokens.NumSequences; i++)
            //{
            //    _Text = _Text + _Tokenizer.Decode(outputTokens[i]);               
            //}
        }



        //public class ResultModel : INotifyPropertyChanged
        //{
        //    private string _content;
        //    private bool _isUserInput;

        //    public string Content
        //    {
        //        get { return _content; }
        //        set { _content = value; NotifyPropertyChanged(); }
        //    }

        //    public bool IsUserInput
        //    {
        //        get { return _isUserInput; }
        //        set { _isUserInput = value; NotifyPropertyChanged(); }
        //    }

        //    public DateTime Timestamp { get; } = DateTime.Now;

        //    #region INotifyPropertyChanged
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    public void NotifyPropertyChanged([CallerMemberName] string property = "")
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        //    }
        //    #endregion
        //}

        //private async Task GenerateAsync()
        //{
        //    try
        //    {
        //        var userInput = new ResultModel
        //        {
        //            Content = Prompt,
        //            IsUserInput = true
        //        };

        //        Prompt = null;
        //        CurrentResult = null;
        //        ResultHistory.Add(userInput);
        //        _cancellationTokenSource = new CancellationTokenSource();
        //        await foreach (var sentencePiece in RunInferenceAsync(userInput.Content, _cancellationTokenSource.Token))
        //        {
        //            if (CurrentResult == null)
        //            {
        //                if (string.IsNullOrWhiteSpace(sentencePiece.Content)) // Ingore preceding '\n'
        //                    continue;

        //                ResultHistory.Add(CurrentResult = new ResultModel());
        //            }
        //            CurrentResult.Content += sentencePiece.Content;
        //        }
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        CurrentResult.Content += "\n\n[Operation Canceled]";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Inference Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private async IAsyncEnumerable<TokenModel> RunInferenceAsync(string prompt, [EnumeratorCancellation] CancellationToken cancellationToken)
        //{
        //    var sequences = await Tokenizer.EncodeAsync($"<|user|>{prompt}<|end|><|assistant|>", cancellationToken);

        //    using var generatorParams = new GeneratorParams(Model);
        //    generatorParams.ApplySearchOptions(SearchOptions);
        //    generatorParams.SetInputSequences(sequences);

        //    using var tokenizerStream = Tokenizer.CreateStream();
        //    using var generator = new Generator(Model, generatorParams);
        //    while (!generator.IsDone())
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();

        //        yield return await Task.Run(() =>
        //        {
        //            generator.ComputeLogits();
        //            generator.GenerateNextToken();

        //            var tokenId = generator.GetSequence(0)[^1];
        //            return new TokenModel(tokenId, tokenizerStream.Decode(tokenId));
        //        }, cancellationToken);
        //    }
        //}
    }
}
