using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChatServer.Hubs
{
    public class ChatHub : Hub
    {

        public async Task newMessage(int userID, string message, string msgType)
        {
            await Clients.All.SendAsync("newMessage", userID, message, msgType);
        }

        public async Task sendBroadcastMessage(string message)
        {
            await Clients.All.SendAsync("broadcastMessage", message);
        }

        public Task sendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("receiveMessage", message);
        }


        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "signalr_users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await base.OnDisconnectedAsync(exception);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }
}
