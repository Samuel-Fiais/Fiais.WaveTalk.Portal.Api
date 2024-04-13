using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;
using Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRoomsUser;

namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom;

public interface IChatRoomModule
{
    IGetChatRooms GetChatRooms { get; }
    IGetChatRoomsUser GetChatRoomsUser { get; }
}