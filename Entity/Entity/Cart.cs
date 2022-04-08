using Core.Entity;

namespace Entity.Entity;
/// <summary>
/// Sepet Varlığı
/// </summary>
public class Cart : BaseEntity
{
    /// <summary>
    /// Sepete eklenen ürün Id
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// Sepete ait ürün nesnesini getirmek için kullanılan Product nesnesi
    /// </summary>
    public Product? Product{ get; set; }
    /// <summary>
    /// Sepete eklenen toplam ürün adedi
    /// </summary>
    public int TotalProductCount { get; set; }
    /// <summary>
    /// Sepet sahibi kişi Id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Ürünün satın alınma durumu (false: bekliyor, true: satıldı.)
    /// </summary>
    public bool Status { get; set; } = false;
}
