using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fiais.WaveTalk.Portal.Application.Exceptions;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.UseCase.Contracts.User.Authenticate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fiais.WaveTalk.Portal.UseCase.Cases.User;

public sealed class Authenticate : IAuthenticate
{
    private readonly IRepositoryModule _repositoryModule;
    private readonly IConfiguration _configuration;

    public Authenticate(IRepositoryModule repositoryModule, IConfiguration configuration)
    {
        _repositoryModule = repositoryModule;
        _configuration = configuration;
    }

    public async Task<string> Execute(AuthenticateRequest model)
    {
        model.Format();
        var user = await _repositoryModule.UserRepository.GetByEmailOrUsername(model.EmailOrUsername, model.EmailOrUsername);

        if (user is null) throw new ApplicationUserNotFoundException();

        if (!user.MatchPassword(model.Password)) throw new ApplicationUnauthorizedException();

        if (!user.IsActive) throw new ApplicationUserDisabledException();

        return GetToken(user);
    }

    private string GetToken(Domain.Entity.User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var secret = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes(secret ?? throw new System.ApplicationException("Secret not found"));

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
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}