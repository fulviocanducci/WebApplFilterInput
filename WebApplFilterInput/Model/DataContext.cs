using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplFilterInput.Model
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
                        
        }

        public DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(CarConfiguration.Create());
        }
    }
}
