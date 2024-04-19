using AutoMapper;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Cases.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Modules;

public sealed class UserModule : IUserModule
{
    public UserModule(IRepositoryModule module, IMapper mapper)
    {
        Authenticate = new Authenticate(module);
        Create = new Create(module, mapper);
    }

    public IAuthenticate Authenticate { get; }
    public ICreate Create { get; }
}