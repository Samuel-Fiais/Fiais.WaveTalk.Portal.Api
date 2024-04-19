using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Cases.Message;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.Modules;

public class MessageModule : IMessageModule
{
    public MessageModule(IRepositoryModule module,  IUserContext userContext, IMapper mapper)
    {
        GetByChatRoom = new GetByChatRoom(module, userContext, mapper);
    }
    
    public IGetByChatRoom GetByChatRoom { get; }
}