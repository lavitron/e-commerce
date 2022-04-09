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

        public async Task<CartResultDto> Add(CartAddDto cartAddDto)
        {
            var cartStockCheck = await _dbContext.Products
                .Where(p => !p.IsDeleted && p.Id == cartAddDto.ProductId)
                .Select(p => new CartStockCheckDto
                {
                    Stock = p.Stock,
                    TotalProductCount = p.Carts.Where(p => !p.IsDeleted).Sum(p => p.TotalProductCount)
                }).FirstOrDefaultAsync();
            var remainedProductCount = cartStockCheck.Stock - (cartAddDto.TotalProductCount + cartStockCheck.TotalProductCount);
            if (remainedProductCount < 0) return new CartResultDto { Result = -1, TotalRemainedCount = cartStockCheck.Stock - cartStockCheck.TotalProductCount };
            var newCart = cartAddDto.Adapt<Cart>();
            await _dbContext.Carts.AddAsync(newCart);
            var result = await _dbContext.SaveChangesAsync();
            return new CartResultDto { Result = result, TotalRemainedCount = remainedProductCount };
        }
    }
}
