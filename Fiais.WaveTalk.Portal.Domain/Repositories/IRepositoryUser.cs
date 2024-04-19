using Fiais.WaveTalk.Portal.Domain.Entity;

namespace Fiais.WaveTalk.Portal.Domain.Repositories;

public interface IRepositoryUser
{
    Task<User?> GetByEmailOrUsername(string? email, string? username);
    Task<User?> GetById(Guid id);
    Task<bool> Create(User user);
}