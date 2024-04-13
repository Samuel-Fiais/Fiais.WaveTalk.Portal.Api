namespace Fiais.WaveTalk.Portal.Domain.Entity;

public class EntityBase
{
    public Guid Id { get; }
    public int AlternateId { get; set; }
    public DateTime CreatedAt { get; }
    public bool IsActive { get; set; }
    
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsActive = true;
    }
}