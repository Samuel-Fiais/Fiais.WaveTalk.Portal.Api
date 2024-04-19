namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Get;

public interface IGet
{
    Task<ICollection<GetResponse>> Execute();
}