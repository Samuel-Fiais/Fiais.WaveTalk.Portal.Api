namespace Fiais.WaveTalk.Portal.Domain.Repositories;

public interface IRepositoryModule
{
    IRepositoryChatRoom ChatRoomRepository { get; }
    IRepositoryMessage MessageRepository { get; }
    IRepositoryUser UserRepository { get; }
}