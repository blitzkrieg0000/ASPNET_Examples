using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.GRPCData;

namespace Business.Interfaces {
    public interface IGRPCService {
        IAsyncEnumerable<Base64FrameModel> StartProducer(long id);
        Task<Response> StopProducer(long id);
    }
}