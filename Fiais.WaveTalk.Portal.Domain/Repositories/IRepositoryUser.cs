using Fiais.WaveTalk.Portal.Domain.Entity;

namespace Fiais.WaveTalk.Portal.Domain.Repositories;

public interface IRepositoryUser
{
    Task<User?> GetByEmailOrUsername(string emailOrUsername);
}