using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.CourtTypeDtos {
    public class CourtTypeListDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}