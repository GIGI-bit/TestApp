using Entities;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Data
{
    public class ProductDb_Testing:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDb_Testing(DbContextOptions<ProductDb_Testing> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p=>p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
