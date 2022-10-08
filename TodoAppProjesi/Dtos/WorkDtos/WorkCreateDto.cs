using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Interfaces;

namespace Dtos.WorkDtos {
    public class WorkCreateDto : IDto {
    
        //[Required(ErrorMessage ="Açıklama Gereklidir!")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }

    }
}