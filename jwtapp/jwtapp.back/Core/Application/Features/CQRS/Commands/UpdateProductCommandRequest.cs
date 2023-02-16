using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommandRequest : IRequest
    {
         public int Id { get; set; }
        public string? Name { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}