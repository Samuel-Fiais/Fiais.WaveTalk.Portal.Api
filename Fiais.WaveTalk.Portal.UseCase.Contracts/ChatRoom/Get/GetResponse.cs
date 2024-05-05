namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;

public sealed record GetResponse
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;
    public string Description { get; init; } = string.Empty;
    public Guid OwnerId { get; init; } = Guid.Empty;
    public bool IsPrivate { get; init; }
}