using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos.WorkDtos {
    public class WorkCreateDto {
    
        [Required(ErrorMessage ="Açıklama Gereklidir!")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }

    }
}