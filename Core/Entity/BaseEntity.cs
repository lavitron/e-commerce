namespace Core.Entity;
/// <summary>
/// Ana varlık nesnesi
/// </summary>
public class BaseEntity : Audit, ISoftDeleted
{
    public BaseEntity() { IsDeleted = false; }
    /// <summary>
    /// Varlık Id
    /// </summary>
    public int Id { get; set; }
    public bool IsDeleted { get; set; } // = false;
}