using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Microsoft.IdentityModel.Tokens;

namespace Fiais.WaveTalk.Portal.UseCase.UseCases.User;

internal sealed class Authenticate : IAuthenticate
{
    private readonly IRepositoryModule _repositoryModule;
    
    public Authenticate(IRepositoryModule repositoryModule)
    {
        _repositoryModule = repositoryModule;
    }
    
    public async Task<string> Execute(AuthenticateDto model)
    {
        model.Format();
        var user = await _repositoryModule.UserRepository.GetByEmailOrUsername(model.EmailOrUsername);

        if (user?.Password != model.Password) throw new ApplicationUnauthorizedException();

        if (!user.IsActive) throw new ApplicationUserDisabledException();

        return GetToken(user);
    }

    private string GetToken(Domain.Entity.User user)
    {

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("id", user.Id.ToString()),
                new("name", user.Name),
                new("username", user.Username),
                new("email", user.Email),
            }),
            Expires = DateTime.UtcNow.AddHours(24),
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}