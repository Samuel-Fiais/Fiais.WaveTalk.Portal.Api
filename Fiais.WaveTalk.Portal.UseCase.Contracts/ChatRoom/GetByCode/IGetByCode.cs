namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

public interface IGetByCode
{
    Task<GetByCodeResponse> ExecuteAsync(string code);
}
