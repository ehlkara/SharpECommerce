﻿using SharpEcommerce.Core.Entities;

namespace SharpEcommerce.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(); 
    }
}
