using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtapp.back.Core.Application.Dto
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public bool IsExist { get; set; }
    }
}