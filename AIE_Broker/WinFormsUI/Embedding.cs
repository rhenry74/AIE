using AIE_InterThread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsUI
{
    public class EmbeddingComparison
    {
        public ApplicationCapibility Capibility { get; set; }
        public Embedding ToCompare { get; set; }

        private double? _DotProduct;
        public double DotProduct 
        {
            get
            {
                if (_DotProduct != null)
                {
                    return _DotProduct.Value;
                }

                _DotProduct = 0;
                for(int count = 0; count < Capibility.Vector.Length; count++)
                {
                    _DotProduct += Capibility.Vector[count] * ToCompare.Vector[count];
                }
                return _DotProduct.Value;
            }
        } 
    }

    public class Embedding
    {
        public double[] Vector { get; set; }

        public static async Task<Embedding> GetForAsync(string text)
        {
            var embeddingsService = Program.PortMappings.First(pm => pm.Name == "Embeddings");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + embeddingsService.Server + ":" + embeddingsService.Port);
            var response = await client.GetAsync("embedding/" + text);

            var embedding = await response.Content.ReadFromJsonAsync<Embedding>();

            return embedding;
        }

        public async static Task<IEnumerable<EmbeddingComparison>> TopThreeCapibilitiesFor(Embedding embedding)
        {
            var comparisons = new List<EmbeddingComparison>();

            foreach (var capibility in Program.Capabilities)
            {
                if (capibility.Vector == null)
                {
                    //hmm we need need to get the embeddings for these capibilities
                    await Program.InitializeCapibilityVectorsAsync();
                }

                var comparison = new EmbeddingComparison
                {
                    Capibility = capibility,
                    ToCompare = embedding
                };
                comparisons.Add(comparison);
            }

            var selected = comparisons.OrderByDescending(c => c.DotProduct).Take(3);
            return selected.AsEnumerable();
        }
    }

}
