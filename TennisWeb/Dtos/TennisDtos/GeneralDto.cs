using System.Collections.Generic;
using Dtos.AOSTypeDtos;
using Dtos.CourtDtos;
using Dtos.Interface;
using Dtos.PlayerDtos;
using Dtos.StreamDtos;

namespace Dtos.TennisDtos {
    public class GeneralDto : IDto {

        public List<CourtListDto> CourtList { get; set; }
        public List<StreamListDto> StreamList { get; set; }
        public List<PlayerListDto> PlayerList { get; set; }
        public List<AOSTypeListDto> AOSTypeList { get; set; }

    }
}