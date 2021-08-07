using Microsoft.EntityFrameworkCore;

namespace game_catalog.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
