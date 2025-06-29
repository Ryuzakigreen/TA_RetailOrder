using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Customers;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Repositories.Customers
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly DBDataContext _db;
        private readonly ILogger<CustomersAppService> _logger;
        public CustomerRepository(DBDataContext db, ILogger<CustomersAppService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<Customer>Items, int TotalCount)> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                var qry = _db.Customer
                .Where(c => !c.IsDeleted);

                var totalCount = await qry.CountAsync();
                var items = await qry
                            .Skip((filter.page - 1) * filter.size)
                            .Take(filter.size)
                            .ToListAsync();

                return (items, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute GetAllAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            try
            {
                var qry = await _db.Customer.FindAsync(id);
                if(qry == null)
                {
                    return new Customer();
                }
                return qry.IsDeleted ? new Customer(): qry;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute GetByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task InsertAsync(Customer customer)
        {
            try
            {
                customer.CreationTime = DateTime.UtcNow;
                customer.CreatorUserId = 0;
                customer.IsDeleted = false;
                await _db.Customer.AddAsync(customer);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task UpdateAsync(Customer customer)
        {
            try
            {
                customer.LastModificationTime = DateTime.UtcNow;
                customer.LastModifierUserId = 0;
                _db.Customer.Update(customer);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute UpdateAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task DeleteByIdAsync(Guid id)
        {
            try
            {
                var customer = await _db.Customer.FindAsync(id);
                if (customer != null)
                {
                    customer.IsDeleted = true;
                    customer.DeletionTime = DateTime.UtcNow;
                    customer.DeleterUserId = 0;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute DeleteByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerRepository| Failed to Execute SaveChangesAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }
    }
}
