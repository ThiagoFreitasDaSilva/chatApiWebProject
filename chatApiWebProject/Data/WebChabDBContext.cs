using Microsoft.EntityFrameworkCore;
using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> context):base(context) { 
        }

        // register the classes
        public DbSet<User> User { get; set; }
    }
}