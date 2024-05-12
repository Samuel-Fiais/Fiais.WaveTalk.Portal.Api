namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByCode;

public interface IGetByCode
{
    Task<GetByCodeResponse> Execute(string code);
}
