using Azure;
using Azure.AI.Inference;

namespace GPTSMShared
{
    public class GPTSettings : IRetrievable
    {
        public GPTSettings(string settingTitle, string endpoint, string aPIKey, string model, float temperature)
        {
            SettingTitle = string.IsNullOrEmpty(settingTitle) ? Id.ToString() : settingTitle;
            Endpoint = endpoint;
            APIKey = aPIKey;
            Model = model;
            Temperature = temperature;
        }
        public DBType Type { get { return DBType.GPTSettings; } }
        public int Id { get; set; }
        public string? SettingTitle { get; set; }
        public string? Endpoint { get; set; }
        public string? APIKey { get; set; }
        public string? Model { get; set; }
        public float Temperature { get; set; } = 0.8f;
        public void Change(GPTSettings settings)
        {
            SettingTitle = settings.SettingTitle;
            Endpoint = settings.Endpoint;
            APIKey = settings.APIKey;
            Model = settings.Model;
            Temperature = settings.Temperature;
        }
        public bool IsValid(out string errorMessage)
        {
            try
            {
                ChatCompletionsClient client = new ChatCompletionsClient(
                    new Uri(Endpoint),
                    new AzureKeyCredential(APIKey),
                    new AzureAIInferenceClientOptions());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            if (string.IsNullOrWhiteSpace(APIKey))
            {
                errorMessage = "Invalid API key";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Model))
            {
                errorMessage = "Invalid model";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}
