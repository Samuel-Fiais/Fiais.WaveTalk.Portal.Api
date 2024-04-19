namespace Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;

public interface IAuthenticate
{
    Task<string> Execute(AuthenticateRequest model);
}