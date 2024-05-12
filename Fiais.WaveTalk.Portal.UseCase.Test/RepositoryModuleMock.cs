using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Test.ChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Test;

public class RepositoryModuleMock : IRepositoryModule
{
    public IRepositoryChatRoom ChatRoomRepository { get; }
    public IRepositoryMessage MessageRepository { get; }
    public IRepositoryUser UserRepository { get; }
    
    public RepositoryModuleMock()
    {
        ChatRoomRepository = new RepositoryChatRoomMock();
    }
}