using SharpEcommerce.Core.Entities;

namespace SharpEcommerce.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(); 
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync(); 
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync(); 
    }
}
