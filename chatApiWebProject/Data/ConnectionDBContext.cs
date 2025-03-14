using Microsoft.EntityFrameworkCore;
using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Data
{
    public class ConnectionDbContext : DbContext
    {
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> context):base(context) { 
        }

        // register the classes
        public DbSet<Connection> Connection { get; set; }
    }
}