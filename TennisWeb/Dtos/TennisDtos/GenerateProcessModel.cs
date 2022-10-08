namespace Dtos.GRPCData {
    public class GenerateProcessModel {
        public long SessionId { get; set; }
        public int StreamId { get; set; }
        public int Limit { get; set; }
    }
}