using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.GRPCData;
using Entities.Concrete;
using Grpc.Core;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {

        private readonly IUnitOfWork _unitOfWork;
        public GRPCService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async IAsyncEnumerable<Base64FrameModel> StartProducer(long id) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new MainServer.MainServerClient(channel);
            var requestData = new StartProcessRequestData() { ProcessId = id };

            var process_entity = await _unitOfWork.GetRepository<Process>().GetByFilter(x => x.Id == id, asNoTracking: true);
            if (process_entity.IsCompleted == true) {
                process_entity.IsCompleted = false;
                await _unitOfWork.SaveChanges();

                using AsyncServerStreamingCall<StartProcessResponseData> response = client.StartProcess(requestData);
                var ResponseCall = response.ResponseStream.ReadAllAsync();

                System.Diagnostics.Stopwatch stopwatch = new();
                var sayac = 0;
                var toplam = 0.0;
                await foreach (var res in ResponseCall) {
                    var data = new Base64FrameModel() {
                        Frame = res.Frame
                    };


                    sayac++;
                    stopwatch.Stop();
                    toplam += stopwatch.Elapsed.TotalSeconds;
                    Console.WriteLine(toplam / sayac);
                    stopwatch.Reset();

                    yield return data;

                    stopwatch.Start();

                }

                //! while yöntemi ile akış
                // while (await response.ResponseStream.MoveNext()) {
                //     var res = response.ResponseStream.Current;
                //     var data = new Base64FrameModel() {
                //         Frame = res.Frame
                //     };
                //     yield return data;
                // }

            }
        }


        public async Task<Response> StopProducer(long id) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new MainServer.MainServerClient(channel);
            var requestData = new StopProcessRequestData() { ProcessId = id };
            var reply = await client.StopProcessAsync(requestData);
            if (reply.Flag) {
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.Success, reply.Message);
        }

    }
}