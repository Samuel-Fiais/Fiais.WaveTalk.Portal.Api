namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;

public sealed class GetResponse
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.MinValue;
    public string Description { get; private set; } = string.Empty;
    public Guid OwnerId { get; private set; } = Guid.Empty;
    public bool IsPrivate { get; private set; }

    public GetResponse(Guid id, DateTime createdAt, string description, Guid ownerId, bool isPrivate)
    {
        Id = id;
        CreatedAt = createdAt;
        Description = description;
        OwnerId = ownerId;
        IsPrivate = isPrivate;
    }
}