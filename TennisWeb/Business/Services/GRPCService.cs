using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.GRPCData;
using Entities.Concrete;
using Grpc.Core;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GRPCService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> StartProducer(long id) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new MainServer.MainServerClient(channel);
            var requestData = new StartProcessRequestData() { ProcessId = id };

            var process_entity = await _unitOfWork.GetRepository<Process>().GetByFilter(x => x.Id == id);
            if (process_entity.IsCompleted == false) {
                return new Response(ResponseType.Success, "İşlem Daha Tamamlanmadı.");
            }
            var process_entity_changed = process_entity;
            process_entity_changed.IsCompleted = false;
            _unitOfWork.GetRepository<Process>().Update(process_entity_changed, process_entity);
            var reply = await client.StartProcessAsync(requestData);
            return new Response(ResponseType.Success, reply.Message);
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

        public async IAsyncEnumerable<Base64FrameModel> GetStreamingFrame(long id) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new MainServer.MainServerClient(channel);
            var requestData = new GetStreamingFrameRequestData() { ProcessId = id };
            using var reply = client.GetStreamingFrame(requestData);


            await foreach (var response in reply.ResponseStream.ReadAllAsync()) {
                var data = new Base64FrameModel() {
                    Frame = response.Frame
                };
                yield return data;
            }

        }


        // public async Task<Response<DetectCourtLinesDto>> DetectCourtLines(DetectCourtLinesRequestModel model) {
        //     using var channel = GrpcChannel.ForAddress("http://localhost:50011");
        //     var client = new mainRouterServer.mainRouterServerClient(channel);
        //     var requestData = new detectCourtLinesRequestData() { StreamId = model.StreamId, Force = model.Force };
        //     var reply = await client.detectCourtLinesControllerAsync(requestData);

        //     //! PARSE
        //     var raw = reply.Lines;
        //     float[,] linesList = new float[10, 4];

        //     for (int i = 0; i < 10; i++) {
        //         for (int j = 0; j < 4; j++) {
        //             if (raw.Items.Count > 0) {
        //                 if (raw.Items[i].Items.Count > 0) {
        //                     linesList[i, j] = raw.Items[i].Items[j].Data;
        //                 }
        //             }
        //         }
        //     }

        //     DetectCourtLinesDto data = new() {
        //         Lines = linesList,
        //         Base64Img = reply.Frame
        //     };

        //     return new Response<DetectCourtLinesDto>(ResponseType.Success, data);
        // }


        // public async Task<Response<StartGameObservationDto>> StartGameObservation(StartGameObservationRequestModel model) {
        //     using var channel = GrpcChannel.ForAddress("http://localhost:50011");
        //     var client = new mainRouterServer.mainRouterServerClient(channel);

        //     var requestData = new gameObservationRequestData() {
        //         StreamId = model.StreamId,
        //         AosTypeId = model.AOSTypeId,
        //         CourtId = model.CourtId,
        //         Limit = model.Limit,
        //         PlayerId = model.PlayerId
        //     };

        //     var reply = await client.gameObservationControllerAsync(requestData);
        //     float[,] FallPoints = new float[reply.FallPoints.Count, 2];


        //     for (int i = 0; i < reply.FallPoints.Count; i++) {
        //         FallPoints[i, 0] = reply.FallPoints[i].X;
        //         FallPoints[i, 1] = reply.FallPoints[i].Y;
        //     }

        //     var data = new StartGameObservationDto() {
        //         Score = reply.Score,
        //         Frame = reply.Frame,
        //         FallPoints = FallPoints
        //     };

        //     return new Response<StartGameObservationDto>(ResponseType.Success, data);

        // }



    }
}