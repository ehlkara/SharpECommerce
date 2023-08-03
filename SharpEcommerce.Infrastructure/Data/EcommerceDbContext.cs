using Microsoft.EntityFrameworkCore;
using SharpEcommerce.Core.Entities;

namespace SharpEcommerce.Infrastructure.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
