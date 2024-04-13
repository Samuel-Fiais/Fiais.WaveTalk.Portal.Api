using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiais.WaveTalk.Portal.Infra.Data.Repositories;

internal sealed class RepositoryChatRoom : IRepositoryChatRoom
{
    private readonly ContextDatabase _context;
    
    public RepositoryChatRoom(ContextDatabase context)
    {
        _context = context;
    }
    
    public async Task<ICollection<ChatRoom>> GetAll()
    {
        return await _context.ChatRooms.ToListAsync();
    }
    
    public async Task<ICollection<ChatRoom>> GetByUser(Guid id)
    {
        return await _context.ChatRooms
            .Include(c => c.Users)
            .Include(c => c.Owner)
            .Where(c => c.Users.Any(u => u.Id == new Guid("f230187d-6de9-4a0a-8618-d22976f0772e")))
            .ToListAsync();
    }
}