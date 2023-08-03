using Microsoft.EntityFrameworkCore;
using SharpEcommerce.API.Entities;

namespace SharpEcommerce.API.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
