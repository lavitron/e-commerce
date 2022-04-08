namespace Core.Entity;
/// <summary>
/// Veritabanı kayıt verileri
/// </summary>
public abstract class Audit
{
    /// <summary>
    /// Varlığı oluşturan kişi Id
    /// </summary>
    public int? CreatedUserId { get; set; }
    /// <summary>
    /// Varlığın oluşturulma tarihi
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Varlığı güncelleyen kişi Id
    /// </summary>
    public int? ModifiedUserId { get; set; }
    /// <summary>
    /// Varlığın güncellenme tarihi
    /// </summary>
    public DateTime? ModifiedDate { get; set; }
}