using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class DBApp : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection.Connection);
        }

        public DbSet<Client> Clients { get; set; }
    }
}