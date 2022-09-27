using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.GRPCData;
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

        public async Task StartProcess(string user, string message) {
            var data = JsonSerializer.Deserialize<ProcessListDto>(message);

            await Clients.All.SendAsync("InfoMessage", user, $"{data.Id} numaralı process işleme alındı.");

            IAsyncEnumerable<Base64FrameModel> iterator = _grpcService.StartProducer(data.Id);
            await foreach (var item in iterator) {
                await Clients.All.SendAsync("ReceiveFrame", user, new { id = data.Id, frame = item.Frame });
            }
        }

        public async Task StopProcess(string user, string message) {
            var data = JsonSerializer.Deserialize<ProcessListDto>(message);
            var response = await _grpcService.StopProducer(data.Id);
            await Clients.All.SendAsync("InfoMessage", user, response.Message);
        }

    }
}