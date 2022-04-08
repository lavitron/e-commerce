namespace Entity.Dto.Product
{
    /// <summary>
    /// Ürün silme veri transfer objesi
    /// </summary>
    public class ProductDeleteDto
    {
        public int ProductId { get; set; }
        public int ModifiedUserId { get; set; }
    }
}
