namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRooms;

public interface IGetChatRooms
{
    Task<ICollection<GetChatRoomsDto>> Execute();
}