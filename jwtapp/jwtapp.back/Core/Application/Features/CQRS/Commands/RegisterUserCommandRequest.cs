using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest
    {
        
        public string? Username { get; set; }
        public string? Password { get; set; }
        
        
    }
}