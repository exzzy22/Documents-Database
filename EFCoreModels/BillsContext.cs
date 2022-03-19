using Microsoft.EntityFrameworkCore;

namespace EFCoreModels
{
    public partial class BillsContext : DbContext
    {
        public BillsContext(DbContextOptions<BillsContext> options)
            : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Document>().Navigation(e => e.Items).AutoInclude(); 
        }
    }
}
