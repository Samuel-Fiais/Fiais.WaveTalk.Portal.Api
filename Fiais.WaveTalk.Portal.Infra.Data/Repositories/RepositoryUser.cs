using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiais.WaveTalk.Portal.Infra.Data.Repositories;

internal sealed class RepositoryUser : IRepositoryUser
{
    private readonly ContextDatabase _context;

    public RepositoryUser(ContextDatabase context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailOrUsername(string? email, string? username) =>
        await _context.Users.FirstOrDefaultAsync(
            x => x.Email == email || x.Username == username);
    
    public async Task<User?> GetById(Guid id) =>
        await _context.Users.FindAsync(id);

    public async Task<bool> Create(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }
}