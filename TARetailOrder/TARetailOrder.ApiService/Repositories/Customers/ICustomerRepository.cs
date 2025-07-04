﻿using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<(IEnumerable<Customer> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter);
        Task<Customer> GetByIdAsync(Guid id);
        Task InsertAsync(Customer input);
        Task UpdateAsync(Customer input);
        Task DeleteByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}