namespace Core.Entity;
/// <summary>
/// Varlığın silinme belirteci
/// </summary>
public interface ISoftDeleted
{
    public bool IsDeleted { get; set; }
}
