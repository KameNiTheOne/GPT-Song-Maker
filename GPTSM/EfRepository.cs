using Microsoft.EntityFrameworkCore;

namespace GPTSM
{
	public class EfRepository : IRepository
	{

		private GPTSMContext _Context;
		public EfRepository(GPTSMContext context)
		{
			_Context = context;
		}
        public async Task<List<GPTSettings>> GetGPTsSettings()
        {
			return await _Context.GPTsSettings.ToListAsync();
        }
        public async Task<List<Prompt>> GetPrompts()
        {
            return await _Context.Prompts.ToListAsync();
        }
        public async Task<List<Song>> GetSongs()
        {
            return await _Context.Songs.ToListAsync();
        }
        public async Task Add<T>(T item)
        {
            await _Context.AddAsync(item);
            await _Context.SaveChangesAsync();
        }
        public async Task Edit(IRetrievable item)
        {
            switch(item.Type)
            {
                case DBType.Song:
                    {
                        var toChange = await _Context.Songs.SingleAsync(x => x.Id == ((Song)item).Id);
                        toChange.Change((Song)item);
                        break;
                    }
                case DBType.Prompt:
                    {
                        var toChange = await _Context.Prompts.SingleAsync(x => x.Id == ((Prompt)item).Id);
                        toChange.Change((Prompt)item);
                        break;
                    }
                case DBType.GPTSettings:
                    {
                        var toChange = await _Context.GPTsSettings.SingleAsync(x => x.Id == ((GPTSettings)item).Id);
                        toChange.Change((GPTSettings)item);
                        break;
                    }

            }
            await _Context.SaveChangesAsync();
        }
        public async Task Remove<T>(T item)
        {
            _Context.Remove(item);
            await _Context.SaveChangesAsync();
        }
    }
}