using Core.Entity;

namespace Entity.Entity;

public class Product : BaseEntity
{
    /// <summary>
    /// Ürün adı
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Ürün Açıklaması
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Ürün toplam adedi
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Ürünün bulunduğu sepetleri getiren Sepet Listesi
    /// </summary>
    public ICollection<Cart>? Carts { get; set; }
}