namespace Dtos.ProcessDtos {
    public class ProcessCreateDto {
        public long SessionId { get; set; }
        public int StreamId { get; set; }
        public int Limit { get; set; }
    }
}