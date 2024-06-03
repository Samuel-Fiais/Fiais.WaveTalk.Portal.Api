using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Cases.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

namespace Fiais.WaveTalk.Portal.UseCase.Modules;

public sealed class ChatRoomModule : IChatRoomModule
{
    public ChatRoomModule(IRepositoryModule module, IUserContext userContext)
    {
        Get = new Get(module);
        GetByLoggedUser = new GetByLoggedUser(module, userContext);
        GetByCode = new GetByCode(module);
        Create = new Create(module, userContext);
    }

    public IGet Get { get; }
    public IGetByLoggedUser GetByLoggedUser { get; }
    public IGetByCode GetByCode { get; }
    public ICreate Create { get; }
}