using System;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {

        public async Task DetectCourtLines(CourtLineDetectRequestModel model) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new mainRouterServer.mainRouterServerClient(channel);
            var reply = await client.detectCourtLinesControllerAsync(new detectCourtLinesRequestData() { Id = model.Id, Force = model.Force });
            Console.WriteLine("Greeting: " + reply.Data);
        }

    }
}