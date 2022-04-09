using Entity.Dto.Cart;

namespace Business.Abstract
{
    /// <summary>
    /// Sepet servisleri
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Sepete ürün ekler
        /// </summary>
        /// <param name="cartAddDto">cartAddDto</param>
        /// <returns>SaveChangesAsync result</returns>
        Task<CartResultDto> Add(CartAddDto cartAddDto);
    }
}
