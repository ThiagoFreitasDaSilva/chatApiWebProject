using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Services
{
    public interface IConnectionService
    {
        Task<List<Connection>> getAllConnectionsAsync();
        Task<Connection> getConnectionByUserIDAsync(int userID);
    }
}