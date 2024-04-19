namespace Fiais.WaveTalk.Portal.UseCase.Contracts.Message.GetByChatRoom;

public interface IGetByChatRoom
{
    Task<ICollection<GetByChatRoomResponse>> Execute(Guid id);
}