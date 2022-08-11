using System;
using Dtos.Interface;

namespace Dtos.TennisDtos {

    public class CourtListDto : IDto{
        public long Id { get; set; }
        public string Name { get; set; }
        public long CourtTypeId { get; set; }
        public DateTime SaveDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}