using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.GRPCData;
using Common.ResponseObjects;
using Dtos.TennisDtos;

namespace Business.Interfaces {
    public interface IGRPCService {
        Task<Response<DetectCourtLinesDto>> DetectCourtLines(DetectCourtLinesRequestModel model);
    }
}