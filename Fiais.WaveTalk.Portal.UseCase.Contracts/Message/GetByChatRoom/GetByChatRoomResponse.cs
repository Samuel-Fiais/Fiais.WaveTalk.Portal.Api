namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

public sealed record GetByChatRoomResponse
{
    public Guid Id { get; set;  } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}