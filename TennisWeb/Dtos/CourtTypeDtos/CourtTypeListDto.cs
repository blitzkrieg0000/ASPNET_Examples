using System;
using Dtos.Interface;

namespace Dtos.CourtTypeDtos {
    public class CourtTypeListDto :IDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}