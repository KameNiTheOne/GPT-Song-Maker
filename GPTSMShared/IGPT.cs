namespace GPTSMShared
{
    public interface IGPT
    {
        public bool IsConfigured { get; set; }
        public void Initialize(GPTSettings _settings);
        public Task<string> Inference(string query);
    }
}
