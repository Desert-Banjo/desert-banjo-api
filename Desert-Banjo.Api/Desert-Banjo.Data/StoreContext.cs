using Desert.Banjo.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Desert.Banjo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get ; set; }
    }
}