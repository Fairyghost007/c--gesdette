using Microsoft.EntityFrameworkCore;

namespace gesdette15.Models
{
    public class GesDetteContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dette> Dettes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual connection string
            optionsBuilder.UseNpgsql("Server=localhost;Database=gesDette3;User Id=postgres;Password=ghost;");
        }
    }
}
