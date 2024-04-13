using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.User;

public sealed class UserModule : IUserModule
{
    public UserModule(IRepositoryModule module)
    {
        Authenticate = new Authenticate(module);
    }

    public IAuthenticate Authenticate { get; }
}