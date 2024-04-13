using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Context;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRoomsUser;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.ChatRoom;

public sealed class ChatRoomModule : IChatRoomModule
{
    public ChatRoomModule(IRepositoryModule module,  IUserContext userContext, IMapper mapper)
    {
        GetChatRooms = new GetChatRooms(module, mapper);
        GetChatRoomsUser = new GetChatRoomsUser(module, userContext);
    }
    
    public IGetChatRooms GetChatRooms { get; }
    public IGetChatRoomsUser GetChatRoomsUser { get; }
}