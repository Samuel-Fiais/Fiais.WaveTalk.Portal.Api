namespace Fiais.WaveTalk.Portal.Hub.Models;

internal class MessageResponse
{
    public MessageResponse(Guid id, int alternateId, Guid chatRoomId, Guid userId, string username, string content, DateTime createdAt)
    {
        Id = id;
        AlternateId = alternateId;
        ChatRoomId = chatRoomId;
        UserId = userId;
        Username = username;
        Content = content;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; } = Guid.Empty;
    public int AlternateId { get; private set; }
    public Guid ChatRoomId { get; private set; } = Guid.Empty;
    public Guid UserId { get; private set; } = Guid.Empty;
    public string Username { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.MinValue;
}