using gesdette15.Models;
using Microsoft.EntityFrameworkCore;

namespace gesdette15.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Dette> Dettes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Dette>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Dettes)
                .HasForeignKey(d => d.ClientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
