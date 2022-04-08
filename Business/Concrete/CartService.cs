using Business.Abstract;
using DataAccess.Context;
using Entity.Dto.Cart;
using Entity.Entity;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class CartService : ICartService
    {
        private readonly ECommerceDbContext _dbContext;

        public CartService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(CartAddDto cartAddDto)
        {
            var cartStockCheck = await _dbContext.Products
                .Where(p => !p.IsDeleted && p.Id == cartAddDto.ProductId)
                .Select(p => new CartStockCheckDto
                {
                    Stock = p.Stock,
                    TotalProductCount = p.Carts.Where(p => !p.IsDeleted).Sum(p => p.TotalProductCount)
                }).FirstOrDefaultAsync();
            var remainedProductCount = cartStockCheck.Stock - (cartAddDto.TotalProductCount + cartStockCheck.TotalProductCount);
            if (remainedProductCount < 0) return -1;
            var newCart = cartAddDto.Adapt<Cart>();
            await _dbContext.Carts.AddAsync(newCart);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
