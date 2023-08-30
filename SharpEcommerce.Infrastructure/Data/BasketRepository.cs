using System;
using SharpEcommerce.Core.Entities;
using SharpEcommerce.Core.Interfaces;

namespace SharpEcommerce.Infrastructure.Data
{
	public class BasketRepository : IBasketRepository
	{
		public BasketRepository()
		{
		}

        public Task<bool> DeleteBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}

