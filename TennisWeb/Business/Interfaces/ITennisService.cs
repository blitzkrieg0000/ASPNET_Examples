using System.Threading.Tasks;
using Common.ResponseObjects;
using Dtos.GRPCData;

namespace Business.Interfaces {
    public interface ITennisService {
        Task<IResponse<GenerateProcessModel>> Create(GenerateProcessModel dto);
    }
}