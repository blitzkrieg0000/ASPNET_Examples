using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.GRPCData;
using Dtos.HubDtos;
using Dtos.ProcessDtos;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs {
    public class MasterHub : Hub {

        private readonly IGRPCService _grpcService;

        public MasterHub(IGRPCService grpcService) {
            _grpcService = grpcService;
        }

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

        public async Task DeliverFrame(string user, string message) {
            var data = JsonSerializer.Deserialize<ProcessListDto>(message);
            IAsyncEnumerable<Base64FrameModel> iterator = _grpcService.GetStreamingFrame(data.Id);
            await foreach (var item in iterator) {
                await Clients.All.SendAsync("ReceiveFrame", user, item.Frame);
            }

        }

    }
}