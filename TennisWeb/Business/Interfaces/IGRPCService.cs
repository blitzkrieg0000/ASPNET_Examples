using System.Threading.Tasks;
using Common.ResponseObjects;


namespace Business.Interfaces {
    public interface IGRPCService {
        Task<Response> StartProducer(long id);
        Task<Response> StopProducer(long id);
        // Task<Response<DetectCourtLinesDto>> DetectCourtLines(DetectCourtLinesRequestModel model);
        // Task<Response<StartGameObservationDto>> StartGameObservation(GenerateProcessModel model);
    }
}