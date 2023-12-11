using Microsoft.EntityFrameworkCore;
using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class ProductsService : BaseService
    {
        public ProductsService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ProductReadDto> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductReadDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().Price : 0,
                    ProductCategoryId = p.ProductCategoryId,
                    ProductCategoryName = p.ProductCategory != null ? p.ProductCategory.Name : string.Empty,
                    IsOrganic = p.IsOrganic,
                    IsDiscountProduct = p.IsDiscountProduct,
                    BrandId = p.BrandProducts.FirstOrDefault() != null ? p.BrandProducts.FirstOrDefault().BrandId : 0,
                    BrandName = p.BrandProducts.FirstOrDefault() != null && p.BrandProducts.FirstOrDefault().Brand != null ? p.BrandProducts.FirstOrDefault().Brand.Name : string.Empty,
                    MarketId = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().MarketId : 0,
                    MarketName = p.MarketProducts.FirstOrDefault() != null && p.MarketProducts.FirstOrDefault().Market != null ? p.MarketProducts.FirstOrDefault().Market.Name : string.Empty,
                    IconName = p.IconName
                })
                .FirstOrDefaultAsync();
        }


        public async Task<List<ProductReadDto>> GetAllProductsAsync()
        {

            return await _context.Products
                .Select(p => new ProductReadDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().Price : 0,
                    ProductCategoryId = p.ProductCategoryId,
                    ProductCategoryName = p.ProductCategory != null ? p.ProductCategory.Name : string.Empty,
                    IsOrganic = p.IsOrganic,
                    IsDiscountProduct = p.IsDiscountProduct,
                    BrandId = p.BrandProducts.FirstOrDefault() != null ? p.BrandProducts.FirstOrDefault().BrandId : 0,
                    BrandName = p.BrandProducts.FirstOrDefault() != null && p.BrandProducts.FirstOrDefault().Brand != null ? p.BrandProducts.FirstOrDefault().Brand.Name : string.Empty,
                    MarketId = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().MarketId : 0,
                    MarketName = p.MarketProducts.FirstOrDefault() != null && p.MarketProducts.FirstOrDefault().Market != null ? p.MarketProducts.FirstOrDefault().Market.Name : string.Empty,
                    IconName = p.IconName
                }).ToListAsync();
        }


        public async Task<IEnumerable<ProductReadDto>> GetProductsByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(name))
                .Select(p => new ProductReadDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().Price : 0,
                    ProductCategoryId = p.ProductCategoryId,
                    ProductCategoryName = p.ProductCategory != null ? p.ProductCategory.Name : string.Empty,
                    IsOrganic = p.IsOrganic,
                    IsDiscountProduct = p.IsDiscountProduct,
                    BrandId = p.BrandProducts.FirstOrDefault() != null ? p.BrandProducts.FirstOrDefault().BrandId : 0,
                    BrandName = p.BrandProducts.FirstOrDefault() != null && p.BrandProducts.FirstOrDefault().Brand != null ? p.BrandProducts.FirstOrDefault().Brand.Name : string.Empty,
                    MarketId = p.MarketProducts.FirstOrDefault() != null ? p.MarketProducts.FirstOrDefault().MarketId : 0,
                    MarketName = p.MarketProducts.FirstOrDefault() != null && p.MarketProducts.FirstOrDefault().Market != null ? p.MarketProducts.FirstOrDefault().Market.Name : string.Empty,
                    IconName = p.IconName
                })
                .ToListAsync();
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
