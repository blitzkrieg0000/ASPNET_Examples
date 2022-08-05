using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.GRPCData {
    public class CourtLineDetectRequestModel {
        public int Id { get; set; }
        public bool Force { get; set; }
    }
}