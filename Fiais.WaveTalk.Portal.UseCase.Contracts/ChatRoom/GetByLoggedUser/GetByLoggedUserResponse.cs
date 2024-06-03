namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

public sealed class GetByLoggedUserResponse
{
    public GetByLoggedUserResponse(
        Guid id,
        string alternateId,
        DateTime createdAt,
        bool isPrivate,
        string description,
        string ownerUsername,
        string ownerName,
        string ownerEmail
    )
    {
        Id = id;
        AlternateId = alternateId;
        CreatedAt = createdAt;
        IsPrivate = isPrivate;
        Description = description;
        OwnerUsername = ownerUsername;
        OwnerName = ownerName;
        OwnerEmail = ownerEmail;
    }

    public Guid Id { get; private set; } = Guid.Empty;
    public string AlternateId { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.MinValue;
    public bool IsPrivate { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string OwnerUsername { get; private set; } = string.Empty;
    public string OwnerName { get; private set; } = string.Empty;
    public string OwnerEmail { get; private set; } = string.Empty;
    public ICollection<User> Users { get; private set; } = new List<User>();

    public sealed class User
    {
        public User(Guid id, int alternateId, string email, string name, string username)
        {
            Id = id;
            AlternateId = alternateId;
            Email = email;
            Name = name;
            Username = username;
        }

        public Guid Id { get; private set; } = Guid.Empty;
        public int AlternateId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
    }

    public void AddUser(Guid id, int alternateId, string email, string name, string username)
    {
        Users.Add(new User(id, alternateId, email, name, username));
    }
}