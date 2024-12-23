using Microsoft.EntityFrameworkCore;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Infrastructure
{
    public class ProdDbContext : DbContext
    {
        public ProdDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
