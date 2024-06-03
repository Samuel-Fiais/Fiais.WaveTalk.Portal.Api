namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class Message : EntityBase
{
    public Message(string content, Guid userId, Guid chatRoomId)
    {
        Content = content;
        UserId = userId;
        ChatRoomId = chatRoomId;
    }

    public string Content { get; private set; } = string.Empty;

    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    public Guid ChatRoomId { get; private set; }
    public ChatRoom? ChatRoom { get; private set; }
}