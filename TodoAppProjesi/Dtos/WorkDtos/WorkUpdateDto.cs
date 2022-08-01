using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Interfaces;

namespace Dtos.WorkDtos {
    public class WorkUpdateDto : IDto {

        //[Range(1, int.MaxValue, ErrorMessage = "Id is not in range!")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Açıklama Gereklidir!")]
        public string Definition { get; set; }

        public bool IsCompleted { get; set; }
    }
}