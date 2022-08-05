using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.TennisDtos {
    public class GRPCClientData {

        public int Id { get; set; }
        public bool Force { get; set; }
        public int Limit { get; set; }
        public int AOSTypeId { get; set; }
        public int CourtId { get; set; }
        public int StreamId { get; set; }
        public byte[] BallPositionArea { get; set; }
        public byte[] BallFallArray { get; set; }
        public byte[] PlayerPositionArray { get; set; }
        public string ConsumerThreadName { get; set; }
        public string ProducerThreadName { get; set; }
    }
}