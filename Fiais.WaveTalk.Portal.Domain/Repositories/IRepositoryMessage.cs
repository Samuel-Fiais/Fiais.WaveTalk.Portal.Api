using Fiais.WaveTalk.Portal.Domain.Entity;

namespace Fiais.WaveTalk.Portal.Domain.Repositories;

public interface IRepositoryMessage
{
    Task<ICollection<Message>> GetAllByChatRoom(Guid id);
}