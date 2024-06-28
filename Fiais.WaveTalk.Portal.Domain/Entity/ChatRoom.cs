namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class ChatRoom : EntityBase
{

    public ChatRoom(string description, string? password, Guid ownerId)
    {
        Description = description;
        Password = password;
        IsPrivate = !string.IsNullOrEmpty(password);
        OwnerId = ownerId;
    }

    public string Description { get; private set; }
    public string? Password { get; private set; }
    public bool IsPrivate { get; private set; }

    public Guid OwnerId { get; private set; }
    public User? Owner { get; }

    public ICollection<User> Users { get; private set; } = [];
    public ICollection<Message> Messages { get; private set; } = [];
}