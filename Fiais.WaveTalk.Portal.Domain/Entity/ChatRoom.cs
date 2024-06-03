namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class ChatRoom : EntityBase
{

    public ChatRoom(string description, bool isPrivate, string? password, Guid ownerId)
    {
        Description = description;
        Password = password;
        IsPrivate = isPrivate;
        OwnerId = ownerId;
    }

    public string Description { get; private set; } = string.Empty;
    public string? Password { get; private set; }
    public bool IsPrivate { get; private set; }

    public Guid OwnerId { get; private set; }
    public User? Owner { get; private set; }

    public ICollection<User> Users { get; private set; } = [];
    public ICollection<Message> Messages { get; private set; } = [];
}