using System.Collections;
using System.Collections.Concurrent;
using Fiais.WaveTalk.Portal.Hub.Models;

namespace Fiais.WaveTalk.Portal.Hub.Shared;

public class ConnectionSingleton
{
    private readonly ConcurrentDictionary<string, UserConnection?> _connections = new();

    public ConcurrentDictionary<string, UserConnection?> Connections => _connections;
    
    public void AddConnection(string connectionId, UserConnection? userConnection)
    {
        _connections.TryAdd(connectionId, userConnection);
    }
    
    public void RemoveConnection(string connectionId)
    {
        _connections.TryRemove(connectionId, out _);
    }
    
    public void RemoveConnectionByUserId(Guid userId)
    {
        var connection = _connections.FirstOrDefault(x => x.Value?.UserId == userId);
        
        if (connection.Value is not null)
        {
            _connections.TryRemove(connection.Key, out _);
        }
    }
}