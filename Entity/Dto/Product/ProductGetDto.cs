using Core.Entity;

namespace Entity.Dto.Product
{
    /// <summary>
    /// Ürün getirme veri transfer objesi
    /// </summary>
    public class ProductGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}
