using Fiais.WaveTalk.Portal.Domain.Entity;
using Fiais.WaveTalk.Portal.Domain.Repositories;
using Fiais.WaveTalk.Portal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiais.WaveTalk.Portal.Infra.Data.Repositories;

internal sealed class RepositoryMessage : IRepositoryMessage
{
    private readonly ContextDatabase _context;
    
    public RepositoryMessage(ContextDatabase context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Message>> GetAllByChatRoom(Guid id)
    {
        return await _context.Messages
            .Where(m => m.ChatRoomId == id)
            .Include(m => m.User)
            .ToListAsync();
    }
}