using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Interface;

namespace Dtos.TennisDtos {
    public class DetectCourtLinesDto : IDto {
        public float[,] Lines { get; set; }
        public string Base64Img { get; set; }
    }
}