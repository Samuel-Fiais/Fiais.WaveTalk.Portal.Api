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

    public async Task<User?> GetByEmailOrUsername(string emailOrUsername) =>
        await _context.Users.FirstOrDefaultAsync(
            x => x != null && (x.Email == emailOrUsername || x.Username == emailOrUsername));
}