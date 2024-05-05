using AutoMapper;
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
    public ChatRoomModule(IRepositoryModule module, IUserContext userContext, IMapper mapper)
    {
        Get = new Get(module, mapper);
        GetByLoggedUser = new GetByLoggedUser(module, userContext, mapper);
        GetByCode = new GetByCode(module, mapper);
        Create = new Create(module, userContext, mapper);
    }

    public IGet Get { get; }
    public IGetByLoggedUser GetByLoggedUser { get; }
    public IGetByCode GetByCode { get; }
    public ICreate Create { get; }
}