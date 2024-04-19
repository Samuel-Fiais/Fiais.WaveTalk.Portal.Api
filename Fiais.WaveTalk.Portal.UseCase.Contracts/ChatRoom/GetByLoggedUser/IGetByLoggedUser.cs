namespace Fiais.WaveTalk.Portal.UseCase.Contracts.ChatRoom.GetByLoggedUser;

public interface IGetByLoggedUser
{
    public Task<ICollection<GetByLoggedUserResponse>> Execute();
}