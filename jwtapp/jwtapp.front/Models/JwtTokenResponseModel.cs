using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtapp.front.Models
{
    public class JwtTokenResponseModel
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}