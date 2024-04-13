namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetMessageByChatRoom;

public interface IGetMessageByChatRoom
{
    Task<ICollection<GetMessageByChatRoomDto>> Execute(Guid id);
}