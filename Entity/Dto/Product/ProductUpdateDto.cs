namespace Entity.Dto.Product
{
    /// <summary>
    /// Ürün güncelleme veri transfer objesi
    /// </summary>
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
