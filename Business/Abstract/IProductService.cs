using Entity.Dto.Product;

namespace Business.Abstract
{
    /// <summary>
    /// Ürün servisleri
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Ürün getirme servisi
        /// </summary>
        Task<ProductGetDto> Get(int productId);
        /// <summary>
        /// Ürün listeleme servisi
        /// </summary>
        Task<List<ProductListDto>> GetList();
        /// <summary>
        /// Ürün ekleme servisi
        /// </summary>
        Task<int> Add(ProductAddDto productAddDto);
        /// <summary>
        /// Ürün güncelleme servisi
        /// </summary>
        Task<int> Update(ProductUpdateDto productUpdateDto);
        /// <summary>
        /// Ürün silme servisi
        /// </summary>
        Task<int> Delete(ProductDeleteDto productDeleteDto);
    }
}
