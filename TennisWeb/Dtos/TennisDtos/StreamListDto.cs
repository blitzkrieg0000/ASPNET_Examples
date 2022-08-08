using System;

namespace Dtos.TennisDtos {
    public class StreamListDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public byte[] CourtLineArray { get; set; }
        public string KafkaTopicName { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
    }
}