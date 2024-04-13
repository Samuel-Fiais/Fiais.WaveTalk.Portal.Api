namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;

public sealed record GetChatRoomsDto
{
    public string Id { get; } = string.Empty;
    public DateTime CreatedAt { get; } = DateTime.MinValue;
    public string Description { get; } = string.Empty;
    public Guid OwnerId { get; } = Guid.Empty;
    public bool IsPrivate { get; } = false;
}