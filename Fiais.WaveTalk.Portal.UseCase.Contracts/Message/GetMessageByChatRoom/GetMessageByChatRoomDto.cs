namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;

public sealed record GetMessageByChatRoomDto
{
    public Guid Id { get; set;  } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public string Username { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}