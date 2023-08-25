using Mango.Services.ProductsAPI.Extensions;
using Mango.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedProducts();
        }
    }
}
