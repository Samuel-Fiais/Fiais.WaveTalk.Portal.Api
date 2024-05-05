namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.EnterChatRoom;

public interface IEnterChatRoom
{
    Task<bool> Execute(EnterChatRoomRequest request);
}
