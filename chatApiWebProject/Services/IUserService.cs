using SignalRChatServer.Data.Entities;

namespace SignalRChatServer.Services
{
    public interface IUserService
    {
        Task<List<User>> getAllUsersAsync();
    }
}