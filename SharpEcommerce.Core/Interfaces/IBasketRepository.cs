using SharpEcommerce.Core.Entities;

namespace SharpEcommerce.Core.Interfaces
{
    public interface IBasketRepository
	{
		Task<CustomerBasket> GetBasketAsync(string basketId);
		Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
		Task<bool> DeleteBasketAsync(string basketId);	
	}
}

