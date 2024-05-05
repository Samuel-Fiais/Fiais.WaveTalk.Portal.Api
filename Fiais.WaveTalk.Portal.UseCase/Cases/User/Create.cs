using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.User;

public sealed class Create : ICreate
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IMapper _mapper;
    
    public Create(IRepositoryModule repositoryModule, IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _mapper = mapper;
    }
    
    public async Task<bool> Execute(CreateRequestUser request)
    {
        request.Format();
        await Validate(request.Email, request.Username);
        
        var user = _mapper.Map<Domain.Entity.User>(request);
        
        await _repositoryModule.UserRepository.Create(user);
        
        return true;
    }
    
    private async Task Validate(string email, string username)
    {
        var user = await _repositoryModule.UserRepository.GetByEmailOrUsername(email, username);
        
        if (user is null) return;
        
        if (user?.Username == username) throw new ApplicationAlreadyExistsException("Esse nome de usuário já está em uso.");
        
        if (user?.Email == email) throw new ApplicationAlreadyExistsException("Esse e-mail já está em uso.");
    }
}