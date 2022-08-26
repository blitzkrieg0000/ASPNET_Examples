namespace Dtos.ProcessDtos {
    public class ProcessCreateDto {
        public bool Override { get; set; }
        public long SessionId { get; set; }
        public int StreamId { get; set; }
        public int Limit { get; set; }
    }
}