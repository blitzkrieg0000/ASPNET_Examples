using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Dto;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
       public string? Username { get; set; } 
        public string? Password { get; set; }
    }
}