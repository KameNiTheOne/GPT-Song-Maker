namespace GPTSMShared
{
    public enum DBType
    {
        Song = 0,
        Prompt = 1,
        GPTSettings = 2
    }
    public interface IRetrievable
    {
        public DBType Type { get; }
        public bool IsValid(out string errorMessage);
    }
}
