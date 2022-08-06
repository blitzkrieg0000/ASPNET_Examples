using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.TennisDtos {
    public class StreamCreateDto {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public byte[] CourtLineArray { get; set; }
        public string KafkaTopicName { get; set; }
        public DateTime SaveDate { get; set; }
        public bool? IsActivated { get; set; }
        public bool? IsDeleted { get; set; }

    }
}