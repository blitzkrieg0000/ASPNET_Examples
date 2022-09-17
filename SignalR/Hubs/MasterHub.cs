using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs {
    public class MasterHub : Hub {

        public override Task OnConnectedAsync() {
            Console.WriteLine("New Connection: " + Context.ConnectionId);
            Clients.All.SendAsync("NewConnection:", "New connection is detected.", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(System.Exception exception) {
            System.Console.WriteLine("Closed Connection: " + Context.ConnectionId);
            Clients.All.SendAsync("ClosedConnection", "Connection is closed.", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}