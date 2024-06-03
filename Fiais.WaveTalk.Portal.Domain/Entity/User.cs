namespace Fiais.WaveTalk.Portal.Domain.Entity;

public sealed class User : EntityBase
{
    public User(string username, string email, string name, string password)
    {
        Username = username;
        Email = email;
        Name = name;
        Password = password;
    }

    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public ICollection<Message> Messages { get; private set; } = [];
    public ICollection<ChatRoom> ChatRooms { get; private set; } = [];
    public ICollection<ChatRoom> OwnedChatRooms { get; private set; } = [];

    public bool ChatRoomIsVinculated(Guid chatRoomId) => ChatRooms.Any(x => x.Id == chatRoomId);

    public bool MatchPassword(string password) => Password == password;
}