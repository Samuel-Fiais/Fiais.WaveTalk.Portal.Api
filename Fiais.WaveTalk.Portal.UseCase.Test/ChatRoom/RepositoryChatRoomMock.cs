using Fiais.WaveTalk.Portal.Domain.Repositories;

namespace Fiais.WaveTalk.Portal.UseCase.Test.ChatRoom;

public class RepositoryChatRoomMock : IRepositoryChatRoom
{
    private readonly List<Domain.Entity.ChatRoom> _chatRooms;
    private readonly List<Domain.Entity.User> _users;

    public RepositoryChatRoomMock()
    {
        _chatRooms = MockData.ChatRooms.ToList();
        _users = MockData.Users.ToList();
    }

    public Task<ICollection<Domain.Entity.ChatRoom>> GetAll()
    {
        return Task.FromResult<ICollection<Domain.Entity.ChatRoom>>(_chatRooms);
    }

    public Task<ICollection<Domain.Entity.ChatRoom>> GetByUser(Guid id)
    {
        var chatRooms = _chatRooms.ToList();
        chatRooms.ForEach(c => c.Owner = _users.FirstOrDefault(u => u.Id == c.OwnerId));
        chatRooms[0].Users = _users;
        chatRooms[1].Users = [_users[0]];

        return Task.FromResult<ICollection<Domain.Entity.ChatRoom>>(chatRooms
            .Where(c => c.Users.Any(u => u.Id == id)).ToList());
    }

    public Task<Domain.Entity.ChatRoom?> GetById(Guid id)
    {
        return Task.FromResult(_chatRooms.FirstOrDefault(c => c.Id == id));
    }

    public Task<Domain.Entity.ChatRoom?> GetByAlternateId(int alternateId)
    {
        var chatRooms = _chatRooms.ToList();
        chatRooms.ForEach(c => c.Owner = _users.FirstOrDefault(u => u.Id == c.OwnerId));
        return Task.FromResult(chatRooms.FirstOrDefault(c => c.AlternateId == alternateId));
    }

    public Task<Domain.Entity.ChatRoom> Create(Domain.Entity.ChatRoom chatRoom)
    {
        return Task.FromResult(chatRoom);
    }
}