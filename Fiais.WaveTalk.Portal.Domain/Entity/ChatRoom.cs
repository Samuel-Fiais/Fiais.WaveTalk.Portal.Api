namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class ChatRoom : EntityBase
{
    public string Description { get; set; } = string.Empty;
    public string? Password { get; set; }
    public bool IsPrivate { get; set; }
    
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }
    
    public List<User?> Users { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}