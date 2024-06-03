namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

public sealed class GetByChatRoomResponse
{
    public GetByChatRoomResponse(Guid id, int alternateId, Guid chatRoomId, Guid userId, string username, string content, DateTime createdAt)
    {
        Id = id;
        AlternateId = alternateId;
        ChatRoomId = chatRoomId;
        UserId = userId;
        Username = username;
        Content = content;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; } = Guid.Empty;
    public int AlternateId { get; set; }
    public Guid ChatRoomId { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}