namespace GPTSM
{
	public interface IRepository
	{
		Task<List<GPTSettings>> GetGPTsSettings();
		Task<List<Prompt>> GetPrompts();
		Task<List<Song>> GetSongs();
        public Task Add<T>(T item);
        public Task Edit(IRetrievable item);
        public Task Remove<T>(T item);
    }
}