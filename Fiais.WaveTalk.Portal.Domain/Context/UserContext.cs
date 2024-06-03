using System.Text;
using Microsoft.AspNetCore.Http;

namespace Fiais.WaveTalk.Portal.Domain.Context;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id
    {
        get
        {
            byte[]? id = null;
            _httpContextAccessor.HttpContext?.Session.TryGetValue("id", out id);
            return id is null ? null : Guid.Parse(Encoding.UTF8.GetString(id));
        }
    }

    public string? Name
    {
        get
        {
            byte[]? name = null;
            _httpContextAccessor.HttpContext?.Session.TryGetValue("name", out name);
            return name is null ? null : Encoding.UTF8.GetString(name);
        }
    }

    public string? Username
    {
        get
        {
            byte[]? username = null;
            _httpContextAccessor.HttpContext?.Session.TryGetValue("username", out username);
            return username is null ? null : Encoding.UTF8.GetString(username);
        }
    }

    public string? Email
    {
        get
        {
            byte[]? email = null;
            _httpContextAccessor.HttpContext?.Session.TryGetValue("email", out email);
            return email is null ? null : Encoding.UTF8.GetString(email);
        }
    }
}