using Microsoft.EntityFrameworkCore;
using SignalRChatServer.Data;
using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ConnectionDbContext _connectionDbContext;
        public ConnectionService(ConnectionDbContext connectionDbContext)
        {
            this._connectionDbContext = connectionDbContext;
        }
        public async Task<List<Connection>> getAllConnectionsAsync()
        {
            var connections = await this._connectionDbContext.Connection.ToListAsync();
            return connections;
        }

        public async Task<Connection> getConnectionByUserIDAsync(int userID)
        {
            var connection = await this._connectionDbContext.Connection.Where(p => userID == p.UserId).FirstAsync();
            return connection;
        }
    }
}