using Azure;
using Azure.AI.Inference;

namespace GPTSMShared
{
    public class GPT : IGPT
    {
        private GPTSettings? settings;
        private ChatCompletionsClient client;
        public bool IsConfigured { get; set; } = false;
        public void Initialize(GPTSettings _settings)
        {
            settings = _settings;
            client = new ChatCompletionsClient(
                new Uri(settings.Endpoint),
                new AzureKeyCredential(settings.APIKey),
                new AzureAIInferenceClientOptions());
            IsConfigured = true;
        }
        public async Task<string> Inference(string query)
        {
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage(""),
                    new ChatRequestUserMessage(query),
                },
                Temperature = settings.Temperature,
                NucleusSamplingFactor = 0.1f,
                MaxTokens = 2048,
                Model = settings.Model,
            };

            Console.WriteLine(query);
            Console.WriteLine("GENERATING");
            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            string res = response.Value.Content;
            Console.WriteLine(res);
            return res;
        }
    }
}
