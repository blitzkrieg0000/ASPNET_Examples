using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.GRPCData;

namespace Business.Interfaces {
    public interface IGRPCService {
        Task<Response> StartProducer(long id);
        Task<Response> StopProducer(long id);
        IAsyncEnumerable<Base64FrameModel> GetStreamingFrame(long id);
        // Task<Response<DetectCourtLinesDto>> DetectCourtLines(DetectCourtLinesRequestModel model);
        // Task<Response<StartGameObservationDto>> StartGameObservation(GenerateProcessModel model);
    }
}