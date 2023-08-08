using Microsoft.EntityFrameworkCore;
using SharpEcommerce.Core.Entities;
using SharpEcommerce.Core.Interfaces;

namespace SharpEcommerce.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EcommerceDbContext _context;

        public GenericRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
