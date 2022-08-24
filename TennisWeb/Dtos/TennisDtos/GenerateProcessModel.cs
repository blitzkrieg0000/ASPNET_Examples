namespace Dtos.GRPCData {
    public class GenerateProcessModel {
        public string Id { get; set; }
        public long SessionId { get; set; }
        public int StreamId { get; set; }
        public int PlayerId { get; set; }
        public int AOSTypeId { get; set; }
        public int CourtId { get; set; }
        public int Limit { get; set; }
        public bool? Force { get; set; }
    }
}