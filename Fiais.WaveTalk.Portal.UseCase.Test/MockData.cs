using Fiais.WaveTalk.Portal.Domain.Entity;

namespace Fiais.WaveTalk.Portal.UseCase.Test;

public static class MockData
{
    public static readonly ICollection<User> Users = new List<User>
    {
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000011"),
            AlternateId = 1,
            CreatedAt = new DateTime(2021, 1, 1),
            Username = "User1",
            Email = "user1@example.com.br",
            Name = "User 1",
            Password = "7D3695BA52D1871D5260B77CEDDFCD3A889BC271",
            IsActive = true,
        },
        new() {
            Id = new Guid("00000000-0000-0000-0000-000000000012"),
            AlternateId = 2,
            CreatedAt = new DateTime(2021, 1, 2),
            Username = "User2",
            Email = "user2@example.com",
            Name = "User 2",
            Password = "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709",
            IsActive = false,
        }
    };
    
    public static readonly ICollection<Domain.Entity.ChatRoom> ChatRooms = new List<Domain.Entity.ChatRoom>
    {
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            AlternateId = 1,
            CreatedAt = new DateTime(2021, 1, 1),
            Description = "Chat Room 1",
            OwnerId = Users.First().Id,
            IsPrivate = true,
            Password = "7D3695BA52D1871D5260B77CEDDFCD3A889BC271",
            IsActive = true,
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            AlternateId = 2,
            CreatedAt = new DateTime(2021, 1, 2),
            Description = "Chat Room 2",
            OwnerId = Users.First().Id,
            IsPrivate = true,
            Password = "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709",
            IsActive = false,
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000003"),
            AlternateId = 3,
            CreatedAt = new DateTime(2021, 1, 3),
            Description = "Chat Room 3",
            OwnerId = Users.Last().Id,
            IsPrivate = false,
            IsActive = true,
        }
    };
    
    public static readonly ICollection<Message> Messages = new List<Message>
    {
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000111"),
            AlternateId = 1,
            CreatedAt = new DateTime(2021, 1, 1),
            Content = "Message 1",
            UserId = Users.First().Id,
            ChatRoomId = ChatRooms.First().Id,
            IsActive = true,
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000112"),
            AlternateId = 2,
            CreatedAt = new DateTime(2021, 1, 2),
            Content = "Message 2",
            UserId = Users.First().Id,
            ChatRoomId = ChatRooms.First().Id,
            IsActive = false,
        },
        new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000113"),
            AlternateId = 3,
            CreatedAt = new DateTime(2021, 1, 3),
            Content = "Message 3",
            UserId = Users.Last().Id,
            ChatRoomId = ChatRooms.First().Id,
            IsActive = true,
        }
    };
}