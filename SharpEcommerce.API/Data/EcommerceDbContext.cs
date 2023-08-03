using Microsoft.EntityFrameworkCore;
using SharpEcommerce.API.Entities;

namespace SharpEcommerce.API.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
