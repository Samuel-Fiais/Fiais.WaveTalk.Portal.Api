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
            .Where(c => c.Users.Any(u => u.Id == id))
            .ToListAsync();
    }
    
    public async Task<ChatRoom?> GetById(Guid id)
    {
        return await _context.ChatRooms
            .Include(c => c.Users)
            .Include(c => c.Owner)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<ChatRoom> Create(ChatRoom chatRoom)
    {
        await _context.ChatRooms.AddAsync(chatRoom);
        await _context.SaveChangesAsync();

        return chatRoom;
    }
}