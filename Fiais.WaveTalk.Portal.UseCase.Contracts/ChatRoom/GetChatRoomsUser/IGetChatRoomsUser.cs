namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetChatRoomsUser;

public interface IGetChatRoomsUser
{
    public Task<IEnumerable<GetChatRoomsUserDto>> Execute();
}