using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.User;

public sealed class Create : ICreate
{
    private readonly IRepositoryModule _repositoryModule;

    public Create(IRepositoryModule repositoryModule)
    {
        _repositoryModule = repositoryModule;
    }

    public async Task<bool> Execute(CreateRequestUser request)
    {
        request.Format();
        await Validate(request.Email, request.Username);

        var user = new Domain.Entity.User
        (
            request.Username,
            request.Email,
            request.Name,
            request.Password
        );

        await _repositoryModule.UserRepository.Create(user);

        return true;
    }

    private async Task Validate(string email, string username)
    {
        var user = await _repositoryModule.UserRepository.GetByEmailOrUsername(email, username);

        if (user is null) return;

        if (user?.Username == username) throw new ApplicationAlreadyExistsException("Esse nome de usuário já está em uso");

        if (user?.Email == email) throw new ApplicationAlreadyExistsException("Esse e-mail já está em uso");
    }
}