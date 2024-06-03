namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

public sealed class GetByCodeResponse
{
    public GetByCodeResponse(Guid id, string description, string ownerName, bool isPrivate)
    {
        Id = id;
        Description = description;
        OwnerName = ownerName;
        IsPrivate = isPrivate;
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string OwnerName { get; private set; } = string.Empty;
    public bool IsPrivate { get; private set; }
}
