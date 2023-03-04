using Microsoft.EntityFrameworkCore;

namespace UserBookEF
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SMN-PC\SQLEXPRESS;Database=UserBook;Trusted_Connection=True; Trust Server Certificate=True;");
        }
    }
}
