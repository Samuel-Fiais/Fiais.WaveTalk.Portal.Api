namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.Create;

public interface ICreate
{
    Task<bool> Execute(CreateRequestChatRoom request);
}
