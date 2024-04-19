namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

public sealed record GetByLoggedUserResponse
{
    public Guid Id { get; init; } = Guid.Empty;
    public string AlternateId { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.MinValue;
    public string Description { get; init; } = string.Empty;
    public string OwnerUsername { get; init; } = string.Empty;
    public string OwnerName { get; init; } = string.Empty;
    public string OwnerEmail { get; init; } = string.Empty;
    public ICollection<User> Users { get; init; } = new List<User>();
    
    public sealed record User
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string AlternateId { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
    }
}