using Microsoft.EntityFrameworkCore;
using SignalRChatServer.Data;
using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;
        public UserService(UserDbContext userDbContext)
        {
            this._userDbContext = userDbContext;
        }
        public async Task<List<User>> getAllUsersAsync()
        {
            var users = await this._userDbContext.User.ToListAsync();
            return users;
        }
    }
}