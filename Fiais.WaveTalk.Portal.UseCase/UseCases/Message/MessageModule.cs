using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message;
using Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.Message;

public class MessageModule : IMessageModule
{
    public MessageModule(IRepositoryModule module,  IUserContext userContext, IMapper mapper)
    {
        GetMessageByChatRoom = new GetMessageByChatRoom(module, userContext, mapper);
    }
    
    public IGetMessageByChatRoom GetMessageByChatRoom { get; }
}