using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.TennisDtos;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {


        public async Task DetectCourtLines(GRPCClientData data) {

            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new mainRouterServer.mainRouterServerClient(channel);
            var reply = await client.detectCourtLinesControllerAsync(new requestData { Data = data });

            Console.WriteLine("Greeting: " + reply.Message);

        }


    }
}