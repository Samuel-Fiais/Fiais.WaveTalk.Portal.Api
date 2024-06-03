namespace Fiais.WaveTalk.Portal.Domain.Entity;

public class EntityBase
{
    public Guid Id { get; }
    public int AlternateId { get; }
    public DateTime CreatedAt { get; }
    public bool IsActive { get; private set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsActive = true;
    }

    public void Deactivate() => IsActive = false;

    public void Activate() => IsActive = true;
}