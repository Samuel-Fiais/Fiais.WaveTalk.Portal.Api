namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class Message : EntityBase
{
    public string Content { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ChatRoomId { get; set; }
    public ChatRoom? ChatRoom { get; set; }
}