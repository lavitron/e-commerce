using Core.Entity;

namespace Entity.Dto.Cart
{
    public class CartAddDto : IDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int TotalProductCount { get; set; }
        public int? CreatedUserId { get; set; } 
    }
}
