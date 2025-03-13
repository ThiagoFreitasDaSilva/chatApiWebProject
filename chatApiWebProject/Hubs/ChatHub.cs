using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections = 
            new ConnectionMapping<string>();

        public async Task newMessage(int userID, string message, string msgType)
        {
            await Clients.All.SendAsync("newMessage", userID, message, msgType);
        }


        public override async Task OnConnectedAsync()
        {
            string name = Context.ConnectionId;
            _connections.Add(name, Context.ConnectionId);
           

            // This newMessage call is what is not being received on the front end
            await Clients.All.SendAsync("connections", _connections);

            // This console.WriteLine does print when I bring up the component in the front end.
            Console.WriteLine("Test");

            await base.OnConnectedAsync();
        }
    }
}
