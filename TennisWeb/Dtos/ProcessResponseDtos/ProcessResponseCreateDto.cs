using System;

namespace Dtos.ProcessResponseDtos {
    public class ProcessResponseCreateDto {
        public string Description { get; set; }
        public string Canvas { get; set; }
        public string BallPositionArray { get; set; }
        public string BallFallArray { get; set; }
        public string PlayerPositionArray { get; set; }
        public long? Score { get; set; }
        public string KafkaTopicName { get; set; }
        public DateTime? SaveDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}