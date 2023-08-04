using Microsoft.EntityFrameworkCore;
using SharpEcommerce.Core.Entities;
using SharpEcommerce.Core.Interfaces;

namespace SharpEcommerce.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
