namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

public sealed record GetByCodeResponse
{
    public Guid Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public string OwnerName { get; init; } = string.Empty;
    public bool IsPrivate { get; init; }
}
