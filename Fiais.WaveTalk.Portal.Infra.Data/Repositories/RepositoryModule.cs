using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Infra.Data.Context;

namespace Fiais.WaveTalk.Portal.Infra.Data.Repositories;

public sealed class RepositoryModule : IRepositoryModule
{
    public RepositoryModule(ContextDatabase context)
    {
        ChatRoomRepository = new RepositoryChatRoom(context);
        MessageRepository = new RepositoryMessage(context);
        UserRepository = new RepositoryUser(context);
    }

    public IRepositoryChatRoom ChatRoomRepository { get; }
    public IRepositoryMessage MessageRepository { get; }
    public IRepositoryUser UserRepository { get; }
}