using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteProductCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}