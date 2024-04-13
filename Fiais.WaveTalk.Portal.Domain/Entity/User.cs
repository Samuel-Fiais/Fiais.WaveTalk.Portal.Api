namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class User : EntityBase
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public ICollection<Message> Messages { get; set; } = [];
    public ICollection<ChatRoom> ChatRooms { get; set; } = [];
    public ICollection<ChatRoom> OwnedChatRooms { get; set; } = [];
}