using System.IdentityModel.Tokens.Jwt;
using Fiais.WaveTalk.Portal.Application.Exceptions;

namespace Fiais.WaveTalk.Portal.Api.Middlewares;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<SessionMiddleware> _logger;

    public SessionMiddleware(RequestDelegate next, ILogger<SessionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.GetTypedHeaders().Headers.Authorization;

        try
        {
            if (!string.IsNullOrEmpty(token) && context.Request.Path.Value?.Contains("auth") == false)
            {
                var jwtSecurityToken =
                    new JwtSecurityTokenHandler().ReadJwtToken(token.ToString().Replace("Bearer ", "").Trim());
                var claims = jwtSecurityToken.Claims.ToList();

                context.Session.SetString("id", claims.FirstOrDefault(x => x.Type == "id")?.Value ?? "");
                context.Session.SetString("name", claims.FirstOrDefault(x => x.Type == "name")?.Value ?? "");
                context.Session.SetString("username", claims.FirstOrDefault(x => x.Type == "username")?.Value ?? "");
                context.Session.SetString("email", claims.FirstOrDefault(x => x.Type == "email")?.Value ?? "");

                var exp = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "exp")?.Value;
                if (exp is not null)
                {
                    var expDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp));
                    if (expDate < DateTimeOffset.Now)
                        throw new ApplicationTokenExpiredException();
                }
            }

        }
        catch (Exception e)
        {
            if (e is ApplicationTokenExpiredException) throw;

            throw new ApplicationTokenInvalidException();
        }

        await _next(context);
    }
}