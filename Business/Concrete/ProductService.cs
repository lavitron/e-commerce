using Business.Abstract;
using DataAccess.Context;
using Entity.Dto.Product;
using Entity.Entity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductGetDto?> Get(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null || product.IsDeleted) return null;
            return product.Adapt<ProductGetDto>();
        }

        public async Task<List<ProductListDto>> GetList()
        {
            return await _dbContext.Products.Where(p => !p.IsDeleted).Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Description = p.Description
            }).ToListAsync();
        }
        public async Task<int> Add(ProductAddDto productAddDto)
        {
            var newProduct = productAddDto.Adapt<Product>();
            await _dbContext.Products.AddAsync(newProduct);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateDto productUpdateDto)
        {
            var currentProduct = await _dbContext.Products.FindAsync(productUpdateDto.Id);
            if (currentProduct == null || currentProduct.IsDeleted) return -1;
            _dbContext.Products.Attach(currentProduct);
            productUpdateDto.Adapt(currentProduct);
            currentProduct.ModifiedDate = DateTime.Now;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(ProductDeleteDto productDeleteDto)
        {
            var currentProduct = await _dbContext.Products.FindAsync(productDeleteDto.ProductId);
            if (currentProduct == null || currentProduct.IsDeleted) return -1;
            _dbContext.Products.Attach(currentProduct);
            currentProduct.IsDeleted = true;
            currentProduct.ModifiedDate = DateTime.Now;
            currentProduct.ModifiedUserId = productDeleteDto.ModifiedUserId;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
