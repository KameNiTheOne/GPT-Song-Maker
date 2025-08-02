using Microsoft.EntityFrameworkCore;

namespace GPTSM
{
    public class GPTSMContext : DbContext
    {
        public GPTSMContext(DbContextOptions options) : base(options) { }
        public DbSet<GPTSettings> GPTsSettings { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}