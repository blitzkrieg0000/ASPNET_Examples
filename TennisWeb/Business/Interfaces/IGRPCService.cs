using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.GRPCData;

namespace Business.Interfaces {
    public interface IGRPCService {
        Task DetectCourtLines(CourtLineDetectRequestModel model);
    }
}