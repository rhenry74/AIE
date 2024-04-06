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

        private double? _likeness;
        public string Mode { get; set; } = "DotProduct";

        public double Likeness 
        {
            get
            {
                if (_likeness != null)
                {
                    return _likeness.Value;
                }

                if (Mode == "DotProduct")
                {
                    _likeness = DotProduct();                    
                }

                if (Mode == "Cosign")
                {
                    _likeness = CosignSimilarity(Capibility.Vector, ToCompare.Vector);
                }

                return _likeness.Value;
            }
        }

        public double DotProduct()
        {
            double dotProduct = 0;
            for (int count = 0; count < Capibility.Vector.Length; count++)
            {
                dotProduct += Capibility.Vector[count] * ToCompare.Vector[count];
            }
            return dotProduct;
        }

        public double CosignSimilarity(double[] embedding1, double[] embedding2)
        {
            if (embedding1.Length != embedding2.Length)
            {
                return 0;
            }

            double dotProduct = 0.0;
            double magnitude1 = 0.0;
            double magnitude2 = 0.0;

            for (int i = 0; i < embedding1.Length; i++)
            {
                dotProduct += embedding1[i] * embedding2[i];
                magnitude1 += Math.Pow(embedding1[i], 2);
                magnitude2 += Math.Pow(embedding2[i], 2);
            }

            magnitude1 = Math.Sqrt(magnitude1);
            magnitude2 = Math.Sqrt(magnitude2);

            if (magnitude1 == 0.0 || magnitude2 == 0.0)
            {
                throw new ArgumentException
                     ("embedding must not have zero magnitude.");
            }

            double cosineSimilarity = dotProduct / (magnitude1 * magnitude2);

            return cosineSimilarity;

            // Uncomment this if you need a cosin distance instead of similarity
            //double cosineDistance = 1 - cosineSimilarity;

            //return cosineDistance;
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

        public async static Task<IEnumerable<EmbeddingComparison>> TopThreeCapibilitiesForAsync(Embedding embedding)
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
                    Mode = "Cosign",
                    Capibility = capibility,
                    ToCompare = embedding
                };
                comparisons.Add(comparison);
            }

            var selected = comparisons.OrderByDescending(c => c.Likeness).Take(3);
            return selected.AsEnumerable();
        }
    }

}
