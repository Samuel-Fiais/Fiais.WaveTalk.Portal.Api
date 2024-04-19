namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

public interface ICreate
{
    Task<bool> Execute(CreateRequest model);
}