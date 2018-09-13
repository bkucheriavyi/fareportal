using FPT.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace FPT.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }

        public DbSet<Additive> Additives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./data.db");
        }
    }
}
