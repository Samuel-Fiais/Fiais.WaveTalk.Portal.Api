using Fiais.WaveTalk.Portal.Domain.Entity;

namespace Fiais.WaveTalk.Portal.Domain.Repositories;

public interface IRepositoryChatRoom
{
    Task<ICollection<ChatRoom>> GetAll();
    Task<ICollection<ChatRoom>> GetByUser(Guid id);
    Task<ChatRoom?> GetById(Guid id);
}