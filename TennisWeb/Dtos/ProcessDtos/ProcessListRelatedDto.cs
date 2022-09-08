using Dtos.ProcessResponseDtos;
using Dtos.SessionParameterDtos;
using Dtos.StreamDtos;

namespace Dtos.ProcessDtos {
    public class ProcessListRelatedDto {
        public ProcessListDto Process { get; set; }
        public ProcessResponseListDto ProcessResponse { get; set; }
        public StreamListDto Stream { get; set; }
    }
}