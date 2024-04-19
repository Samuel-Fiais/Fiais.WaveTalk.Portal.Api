using AutoMapper;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Create;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.User;

public class Create : ICreate
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IMapper _mapper;
    
    public Create(IRepositoryModule repositoryModule, IMapper mapper)
    {
        _repositoryModule = repositoryModule;
        _mapper = mapper;
    }
    
    public async Task<bool> Execute(CreateRequest model)
    {
        model.Format();
        await Validate(model.Email, model.Username);
        
        var user = _mapper.Map<Domain.Entity.User>(model);
        
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