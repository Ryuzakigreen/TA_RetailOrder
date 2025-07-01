using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Repositories.Products;
using TARetailOrder.ApiService.Services.Products.DTOs;


namespace TARetailOrder.ApiService.Services.Products
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsAppService> _logger;
        private readonly IMapper _mapper;
        public ProductsAppService(
            IProductRepository productRepository, 
            ILogger<ProductsAppService> logger,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetAllProductDto> GetAllByPageAsync(FilterInputDto filter)
        {
            try
            {
                if (filter.page == 0)
                {
                    throw new ArgumentException("Page No. must greater than 0(zero)!", nameof(filter.page));
                }
                if (filter.size == 0)
                {
                    throw new ArgumentException("Page size must greater than 0(zero)!", nameof(filter.size));
                }

                var products = await _productRepository.GetAllByPageAsync(filter);

                if (products.TotalCount == 0)
                {
                    _logger.LogInformation("No Product Record");
                    return new GetAllProductDto()
                    {
                        SummaryResult = new SummaryResult
                        {
                            Page = filter.page,
                            TotalCount = 0
                        },
                        ProductList = new List<ViewProductDto>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {0} products", products.TotalCount);
                return new GetAllProductDto
                {
                    SummaryResult = new SummaryResult
                    {
                        Page = filter.page,
                        TotalCount = products.TotalCount
                    },
                    ProductList = products.Items.Select(o => new ViewProductDto
                        {
                            CategoryName = o.CategoryFk?.Name?.ToString(),
                            Product = new ProductDto
                            {
                                ID = o.ID.ToString(),
                                Name = o.Name,
                                Description = o.Description,
                                CategoryId = o.CategoryId,
                                UnitPrice = o.UnitPrice,
                                Qty = o.Qty,
                                SKU = o.SKU,
                                Status = o.Status,
                            }
                        }).ToList()




                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve products. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task<ViewProductDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(id));
            }
            try
            {
                var products = await _productRepository.GetByIdAsync(id);
                if (products != null)
                {
                    _logger.LogInformation("Successfully retrieved Product.");

                    return new ViewProductDto()
                    {
                        CategoryName = products.CategoryFk?.Name?.ToString(),
                        Product = new ProductDto
                        {
                            ID = products.ID.ToString(),
                            Name = products.Name,
                            Description = products.Description,
                            CategoryId = products.CategoryId,
                            UnitPrice = products.UnitPrice,
                            Qty = products.Qty,
                            SKU = products.SKU,
                            Status = products.Status
                        }
                    };
                }
                else
                {
                    _logger.LogInformation("No record found.");
                    return new ViewProductDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve Product. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(id));
            }
            try
            {
                await _productRepository.DeleteByIdAsync(id);
                _logger.LogInformation("Successfully deleted Product.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Product. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task CreateOrEditAsync(CreateOrEditProductDto input)
        {
            if(input.ID == Guid.Empty)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Create(CreateOrEditProductDto input)
        {
            try
            {
                var Product = _mapper.Map<Product>(input);
                await _productRepository.InsertAsync(Product);
                _logger.LogInformation("Successfully inserted Product.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Product. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        private async Task Update(CreateOrEditProductDto input)
        {
            try
            {
                var Product = _mapper.Map<Product>(input);
                await _productRepository.UpdateAsync(Product);
                _logger.LogInformation("Successfully updated Product.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Product. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

    }
}
