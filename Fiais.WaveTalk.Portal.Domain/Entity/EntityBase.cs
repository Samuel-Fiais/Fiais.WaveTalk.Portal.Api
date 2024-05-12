namespace Fiais.WaveTalk.Portal.Domain.Entity;

public class EntityBase
{
    public Guid Id { get; set; }
    public int AlternateId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsActive = true;
    }
}