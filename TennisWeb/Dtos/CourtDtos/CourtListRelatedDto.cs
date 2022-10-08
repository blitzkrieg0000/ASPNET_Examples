using System;
using Dtos.Interface;

namespace Dtos.CourtDtos {

    public class CourtListRelatedDto : IDto{
        public long Id { get; set; }
        public string Name { get; set; }
        public string CourtTypeName { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}