using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Common.ResponseObjects;
using Dtos.TennisDtos;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {

        public async Task<Response<DetectCourtLinesDto>> DetectCourtLines(CourtLineDetectRequestModel model) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new mainRouterServer.mainRouterServerClient(channel);
            var reply = await client.detectCourtLinesControllerAsync(new detectCourtLinesRequestData() { Id = model.Id, Force = model.Force });

            var raw = reply.Data.ToBase64();
            DetectCourtLinesDto data = new() {
                Image = raw
            };
            return new Response<DetectCourtLinesDto>(ResponseType.Success, data);
        }

    }
}