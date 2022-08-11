using System.Collections.Generic;
using Dtos.Interface;
using Dtos.TennisDtos;

namespace Dtos.TennisDtos {
    public class GeneralDto : IDto {

        public List<CourtListDto> CourtList { get; set; }
        public List<StreamListDto> StreamList { get; set; }
        public List<PlayerListDto> PlayerList { get; set; }
        public List<AOSTypeListDto> AOSTypeList { get; set; }

    }
}