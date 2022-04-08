using Core.Entity;

namespace Entity.Dto.Product
{
    /// <summary>
    /// Ürün ekleme veri transfer objesi
    /// </summary>
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int? CreatedUserId { get; set; }
    }
}
