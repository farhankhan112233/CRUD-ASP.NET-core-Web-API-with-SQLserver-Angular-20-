using Microsoft.EntityFrameworkCore;
using Representational_State_Transfer.Models.Entities;

namespace Representational_State_Transfer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().OwnsOne(p => p.Address);

            base.OnModelCreating(modelBuilder);
        }
    }
}
