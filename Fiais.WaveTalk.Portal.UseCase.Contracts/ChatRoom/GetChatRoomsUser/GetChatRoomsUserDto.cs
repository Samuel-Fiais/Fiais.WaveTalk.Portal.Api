namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRoomsUser;

public sealed record GetChatRoomsUserDto
{
    public Guid Id { get; }
    public string AlternativeId { get; }
    public DateTime CreatedAt { get; }
    public string Description { get; }
    public string OwnerUsername { get; }
    public string OwnerName { get; }
    public string OwnerEmail { get; }

    public GetChatRoomsUserDto(
        Guid id,
        string alternativeId,
        DateTime createdAt,
        string description,
        string ownerUsername,
        string ownerName,
        string ownerEmail)
    {
        Id = id;
        AlternativeId = alternativeId;
        CreatedAt = createdAt;
        Description = description;
        OwnerUsername = ownerUsername;
        OwnerName = ownerName;
        OwnerEmail = ownerEmail;
    }
}